using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfApp2;

namespace MVVM_WPF
{
    public class VM_Profile_User : VM_Super
    {
        private RelayCommand profile_loading;

        public RelayCommand Profile_Loading => profile_loading ??
                                               (profile_loading = new RelayCommand((x) =>
                                               {
                                                   var user = Service.user;
                                                   Page2 pg2 = new();
                                                   pg2.tb1.Text = user.FName;
                                                   pg2.tb2.Text = user.SName;
                                                   pg2.tb3.Text = user.LName;
                                                   pg2.tb4.Text = user.NumberPhone;
                                               }));


    }
}
