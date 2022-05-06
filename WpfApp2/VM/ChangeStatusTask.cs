using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls.Ribbon;
using System.Windows.Documents.DocumentStructures;
using Microsoft.EntityFrameworkCore;

namespace WpfApp2;

public class ChangeStatusTask : VM_Super
{
    private RelayCommand changestatus;
    private Task selectedtask;
    private ObservableCollection<Task> Tasks = new(Service.db.Tasks.Include(x => x.Status).Where(x => x.CreatorId == Service.user.Userid && x.Statusid == 2));

    public RelayCommand ChangeStatus => changestatus ??
                                       (changestatus = new RelayCommand((x) =>
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
                                               MessageBox.Show("Статус успешно изменен!");
                                           }
                                           
                                       }));

    public ObservableCollection<Task> TaskCollection
    {
        get => Tasks;
        set
        {
            Tasks = value;
            OnPropertyChanged();
        }
    }

    public Task SelectedTask
    {
        get => selectedtask;
        set
        {
            selectedtask = value;
            OnPropertyChanged();
        }
    }

}