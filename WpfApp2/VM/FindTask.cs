using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace WpfApp2;

public class FindTask : VM_Super
{
    private RelayCommand _find;
    private ObservableCollection<Task> _findedtask;
    private string _login;

    public RelayCommand Find => _find ?? 
                                (_find = new RelayCommand((x) =>
                                {
                                    FindedTask = new ObservableCollection<Task>(Service.db.Tasks.Include(x => x.Status).Where(x => x.Creator.Login == Login));
                                    if (FindedTask.Count >= 5)
                                    {
                                        MessageBox.Show($"Найдено {FindedTask.Count} задач!");
                                    }
                                    if (FindedTask.Count <= 4)
                                    {
                                        MessageBox.Show($"Найдено {FindedTask.Count} задачи!");
                                    }
                                }));

    public ObservableCollection<Task> FindedTask
    {
        get => _findedtask;
        set
        {
            _findedtask = value;
            ;
            OnPropertyChanged();
        }
    }

    public string Login
    {
        get => _login;
        set
        {
            _login = value;
            OnPropertyChanged();
        }
    }
}