using System;
using System.Windows;

namespace WpfApp2;

public class NewTask : VM_Super
{
    private RelayCommand _newtask;
    private string _nametask;
    private string _discriptask;

    public RelayCommand NewTask1 => _newtask ??
                                   (_newtask = new RelayCommand((x) =>
                                   {
                                       Page10 pg10 = new();
                                       if (NameTask == null || NameTask == null)
                                       {
                                           MessageBox.Show("Введите имя и описание задачи!");
                                           return;
                                       }
                                       if (DiscripTask != null && DiscripTask != null)
                                       {
                                           Task task = new()
                                           {
                                               NameTask = NameTask,
                                               DescriptionTask = DiscripTask,
                                               DatePub = DateTime.Now,
                                               CreatorId = Service.user.Userid,
                                               AcceptorId = Service.user.Userid,
                                               Statusid = 1
                                           };
                                           Service.db.Tasks.Add(task);
                                           Service.db.SaveChanges();
                                           MessageBox.Show("Данные добавлены");
                                           OnPropertyChanged();
                                       }
                                   }));

    public string NameTask
    {
        get => _nametask;
        set
        {
            _nametask = value;
            OnPropertyChanged();
        }
    }

    public string DiscripTask
    {
        get => _discriptask;
        set
        {
            _discriptask = value;
            OnPropertyChanged();
        }
    }
}