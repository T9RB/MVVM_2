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
    private ObservableCollection<Task> tasks;
    private RelayCommand filter;
    private DateTime date1;
    private DateTime date2;

    public RelayCommand Filter => filter ??
                                  (filter = new RelayCommand((x) =>
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
        get => tasks;
        set
        {
            tasks = value;
            OnPropertyChanged();
        }
    }

    public DateTime Date1
    {
        get => date1;
        set
        {
            date1 = value;
            OnPropertyChanged();
        }
    }

    public DateTime Date2
    {
        get => date2;
        set
        {
            date2 = value;
            OnPropertyChanged();
        }
    }
}