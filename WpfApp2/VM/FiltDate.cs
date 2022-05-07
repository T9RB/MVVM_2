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
    private DateTime calendar1;
    private DateTime calendar2;

    public RelayCommand Filter => filter ??
                                  (filter = new RelayCommand((x) =>
                                  {
                                      FiltTask = new ObservableCollection<Task>(Service.db.Tasks.Include(x => x.Status)
                                          .Where(x => x.DatePub >= Calendar1 && x.DatePub <= Calendar2));
                                      if (FiltTask.Count >= 5)
                                      {
                                          MessageBox.Show($"Найдено {FiltTask.Count} задач!");
                                      }
                                      if (FiltTask.Count <= 4)
                                      {
                                          MessageBox.Show($"Найдено {FiltTask.Count} задачи!");
                                      }
                                    
                                  }));

    public DateTime Calendar1
    {
        get => calendar1;
        set
        {
            calendar1 = value;
            OnPropertyChanged();
        }
    }

    public DateTime Calendar2
    {
        get => calendar2;
        set
        {
            calendar2 = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<Task> FiltTask
    {
        get => tasks;
        set
        {
            tasks = value;
            OnPropertyChanged();
        }
    }
}