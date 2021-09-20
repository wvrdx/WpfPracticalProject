using System.Collections.Generic;
using System.Linq;
using WpfPracticalProject.Common;
using WpfPracticalProject.Models;

namespace WpfPracticalProject.ViewModels
{
    internal class BookingsListViewModel : ViewModelBase
    {
        private TableToView _selectedTable;
        private List<BookingToView> _selectedTableBookingToView;

        public TableToView SelectedTable
        {
            get => _selectedTable;
            set
            {
                _selectedTable = value;
                SelectedTableBookingToView = GetTableBookings(_selectedTable);
                NotifyPropertyChanged("SelectedTable");
            }
        }

        public List<BookingToView> SelectedTableBookingToView
        {
            get => _selectedTableBookingToView;
            set
            {
                _selectedTableBookingToView = value;
                NotifyPropertyChanged("SelectedTableBookingToView");
            }
        }

        private List<BookingToView> GetTableBookings(TableToView selectedTable)
        {
            var toReturn = new List<BookingToView>();
            using (var db = new AppDataBaseContext())
            {
                var _loadedBookings =
                    (from i in db.Bookings
                     where i.TableId == selectedTable.Id && i.BookingStatusId != 3 && i.BookingStatusId != 4
                     select i).ToList();
                foreach (var tableBooking in _loadedBookings)
                {
                    var tableBookingToView = new BookingToView
                    {
                        Id = tableBooking.Id,
                        TableId = selectedTable.Id,
                        TableName = selectedTable.TableName,
                        BookerId = tableBooking.BookerId,
                        BookerName = (from i in db.Clients where i.Id == tableBooking.BookerId select i.ClientName)
                            .ToString(),
                        BookingStatusId = tableBooking.BookingStatusId,
                        BookingStatusName =
                            (from i in db.BookingStatuses where i.Id == tableBooking.BookingStatusId select i.StausName)
                            .ToString()
                    };
                    toReturn.Add(tableBookingToView);
                }
            }

            return toReturn;
        }
    }
}