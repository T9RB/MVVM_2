using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls.Ribbon;
using System.Windows.Documents.DocumentStructures;
using Microsoft.EntityFrameworkCore;

namespace WpfApp2;

public class ChangeStatusTask : VM_Super
{
    private RelayCommand _changestatus;
    private Task _selectedtask;
    private ObservableCollection<Task> _tasks = new(Service.db.Tasks.Include(x => x.Status).Where(x => x.CreatorId == Service.user.Userid && x.Statusid == 2));

    public RelayCommand ChangeStatus => _changestatus ??
                                       (_changestatus = new RelayCommand((x) =>
                                       {
                                           Task? selTask = SelectedTask;
                                           if (selTask == null)
                                           {
                                               MessageBox.Show("Выберите задау!");
                                               return;
                                           }

                                           if (selTask != null)
                                           {
                                               SelectedTask.Statusid = 3;
                                               Service.db.SaveChanges();
                                               OnPropertyChanged();
                                               TaskCollection = new(Service.db.Tasks.Include(x => x.Status).Where(x => x.CreatorId == Service.user.Userid && x.Statusid == 2));
                                               MessageBox.Show("Статус успешно изменен!");
                                           }
                                           
                                       }));

    public ObservableCollection<Task> TaskCollection
    {
        get => _tasks;
        set
        {
            _tasks = value;
            OnPropertyChanged();
        }
    }

    public Task SelectedTask
    {
        get => _selectedtask;
        set
        {
            _selectedtask = value;
            OnPropertyChanged();
        }
    }

}