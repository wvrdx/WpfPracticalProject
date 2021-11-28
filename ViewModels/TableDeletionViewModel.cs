using System.Data.Entity;
using WpfPracticalProject.Common;
using WpfPracticalProject.Models;

namespace WpfPracticalProject.ViewModels
{
    public class TableDeletionViewModel : CloseableViewModelBase
    {
        private readonly int _activeTableID;
        private readonly string _activeTableName;
        private RelayCommand _deleteTableCommand;

        public TableDeletionViewModel(TableToView SelectedTable)
        {
            _activeTableName = SelectedTable.TableName;
            _activeTableID = SelectedTable.Id;
            ConfigrationMessage = $"Ви точно хочете видалити стіл \"{_activeTableName}\"?";
            WindowTitle = $"Delete Table \"{_activeTableName}\"?";
        }

        public string WindowTitle { get; }

        public string ConfigrationMessage { get; }

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
                            Id = _activeTableID
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