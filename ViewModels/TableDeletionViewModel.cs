using System.Data.Entity;
using WpfPracticalProject.Common;
using WpfPracticalProject.Models;

namespace WpfPracticalProject.ViewModels
{
    public class TableDeletionViewModel : CloseableViewModelBase
    {
        private readonly int _activeTableID;
        private readonly string _activeTableName;
        private readonly string _configrationMessage;
        private readonly string _windowTitle;
        private RelayCommand _deleteTableCommand;

        public TableDeletionViewModel(TableToView SelectedTable)
        {
            _activeTableName = SelectedTable.TableName;
            _activeTableID = SelectedTable.ID;
            _configrationMessage = $"Are you sure want to delete table \"{_activeTableName}\"?";
            _windowTitle = $"Delete Table \"{_activeTableName}\"?";
        }

        public string WindowTitle
        {
            get => _windowTitle;
            private set { }
        }

        public string ConfigrationMessage
        {
            get => _configrationMessage;
            private set { }
        }

        public RelayCommand DeleteTableCommand
        {
            get
            {
                return _deleteTableCommand ?? (_deleteTableCommand = new RelayCommand(obj =>
                {
                    using (var db = new AppDataBaseContext())
                    {
                        var table = new Table
                        {
                            ID = _activeTableID
                        };
                        db.Entry(table).State = EntityState.Deleted;
                        db.SaveChanges();
                        OnClosingRequest();
                    }
                }));
            }
        }
    }
}