using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WpfApp2
{
    public class VM_AvaibleTaskList : VM_Super
    {
        private ObservableCollection<Task> _avaibletasklist =
            new(Service.db.Tasks.Include(x => x.Status).Where(x => x.Status.NameStatus == "Не готов"));
        public ObservableCollection<Task> AvaibleTaksList
        {
            get => _avaibletasklist;
            set
            {
                _avaibletasklist = value;
                OnPropertyChanged();
            }
        }

    }
}
