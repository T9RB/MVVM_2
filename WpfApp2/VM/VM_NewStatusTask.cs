using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace WpfApp2
{
    public class VM_NewStatusTask : VM_Super
    {
        public ObservableCollection<Task> tasklist =
            new(Service.db.Tasks.Include(x => x.Status).Where(x => x.Status.NameStatus == "Не готов"));
        private RelayCommand newstatus;
        private Task selectedtask;
        public RelayCommand NewStatus => newstatus ??
                                         (newstatus = new RelayCommand((x) =>
                                         {
                                             Task? selTask = SelectedTask;
                                             if (selTask == null)
                                             {
                                                 MessageBox.Show("Выберите задачу!");
                                                 return;
                                             }

                                             if (selTask != null)
                                             {
                                                 SelectedTask.Statusid = 2;
                                                 SelectedTask.AcceptorId = Service.user.Userid;
                                                 Service.db.SaveChanges();
                                                 OnPropertyChanged();
                                                 TaksList = new(Service.db.Tasks.Include(x => x.Status).Where(x => x.Status.NameStatus == "Не готов"));
                                                 MessageBox.Show("Статус задачи изменен!");
                                             }
                                            
                                         }));

        public ObservableCollection<Task> TaksList
        {
            get => tasklist;
            set
            {
                tasklist = value;
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
}
