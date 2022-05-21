using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace WpfApp2;

public class FiltDate : VM_Super
{
    private ObservableCollection<Task> _tasks;
    private RelayCommand _filter;
    private DateTime _date1;
    private DateTime _date2;

    public RelayCommand Filter => _filter ??
                                  (_filter = new RelayCommand((x) =>
                                  {
                                      FiltTask = new ObservableCollection<Task>(Service.db.Tasks.Include(x => x.Status)
                                          .Where(x => x.DatePub >= Date1 && x.DatePub <= Date2));
                                      if (FiltTask.Count >= 5)
                                      {
                                          MessageBox.Show($"Найдено {FiltTask.Count} задач!");
                                      }
                                      if (FiltTask.Count <= 4)
                                      {
                                          MessageBox.Show($"Найдено {FiltTask.Count} задачи!");
                                      }

                                  }));

    public ObservableCollection<Task> FiltTask
    {
        get => _tasks;
        set
        {
            _tasks = value;
            OnPropertyChanged();
        }
    }

    public DateTime Date1
    {
        get => _date1;
        set
        {
            _date1 = value;
            OnPropertyChanged();
        }
    }

    public DateTime Date2
    {
        get => _date2;
        set
        {
            _date2 = value;
            OnPropertyChanged();
        }
    }
}