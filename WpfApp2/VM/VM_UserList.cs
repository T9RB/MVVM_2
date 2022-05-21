using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2;

namespace MVVM_WPF
{
    public class VM_UserList : VM_Super
    {
        private ObservableCollection<User> _user_list = new(Service.db.Users);
        public ObservableCollection<User> User_List
        {
            get => _user_list;
            set
            {
                _user_list = value;
                OnPropertyChanged();
            }
        }
    }
}
