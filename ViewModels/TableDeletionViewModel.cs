using System.Data.Entity;
using WpfPracticalProject.Common;
using WpfPracticalProject.Models;

namespace WpfPracticalProject.ViewModels
{
    public class TableDeletionViewModel : CloseableViewModelBase
    {
        private string _activeTableName;
        private int _activeTableID;
        private string _windowTitle;
        private string _configrationMessage;
        private RelayCommand _deleteTableCommand;

        public string WindowTitle
        {
            get
            {
                return _windowTitle;
            }
            private set { }
        }
        public string ConfigrationMessage
        {
            get
            {
                return _configrationMessage;
            }
            private set { }
        }
        public TableDeletionViewModel(TableToView SelectedTable)
        {
            _activeTableName = SelectedTable.TableName;
            _activeTableID = SelectedTable.ID;
            _configrationMessage = $"Are you sure want to delete table \"{_activeTableName}\"?";
            _windowTitle = $"Delete Table \"{_activeTableName}\"?";
        }
        public RelayCommand DeleteTableCommand
        {
            get
            {
                AppDataBaseContext db = new AppDataBaseContext();
                return _deleteTableCommand ?? (_deleteTableCommand = new RelayCommand(obj =>
                {
                    Table table = new Table()
                    {
                        ID = _activeTableID
                    };
                    db.Entry(table).State = EntityState.Deleted;
                    db.SaveChanges();
                    this.OnClosingRequest();
                }));
            }
        }
    }
}
