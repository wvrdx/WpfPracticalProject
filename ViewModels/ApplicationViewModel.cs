using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using WpfPracticalProject.Models;

namespace WpfPracticalProject
{
    class TableViewModel : INotifyPropertyChanged
    {
        private Table _selectedTable;
        private AppDataBaseContext db;
        private List<Table> _tablesList;
        private List<Booking> _tableBookingsList;
        public Table SelectedTable
        {
            get
            {
                return _selectedTable;
            }
            set
            {
                _selectedTable = value;
                db.Bookings.Load();
                _tableBookingsList = db.Bookings.Local.ToList();
                if (_selectedTable != null)
                {
                    var tableBookingsList = from b in _tableBookingsList
                                            where b.TableID.Equals(_selectedTable.ID)
                                            select b;
                    _tableBookingsList = tableBookingsList.ToList();
                }
                else
                {
                    _tableBookingsList = new List<Booking> { };
                }
                OnPropertyChanged("TableBookingsList");
                OnPropertyChanged("SelectedTable");
            }
        }
        public List<Table> TablesList
        {
            get
            {
                _tablesList = GetTablesList();
                return _tablesList;
            }
            set
            {
                _tablesList = value;
                OnPropertyChanged("TablesList");
            }
        }
        private List<Table> GetTablesList()
        {
            db = new AppDataBaseContext();
            db.Tables.Load();
            return db.Tables.Local.ToList();
        }
        public List<Booking> TableBookingsList
        {
            get
            {
                return _tableBookingsList;
            }
            set
            {
                _tableBookingsList = value;
                OnPropertyChanged("TableBookingsList");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
