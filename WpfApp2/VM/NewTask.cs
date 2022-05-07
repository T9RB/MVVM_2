using System;
using System.Windows;

namespace WpfApp2;

public class NewTask : VM_Super
{
    private RelayCommand newtask;
    private string nametask;
    private string discriptask;

    public RelayCommand NewTask1 => newtask ??
                                   (newtask = new RelayCommand((x) =>
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
        get => nametask;
        set
        {
            nametask = value;
            OnPropertyChanged();
        }
    }

    public string DiscripTask
    {
        get => discriptask;
        set
        {
            discriptask = value;
            OnPropertyChanged();
        }
    }
}