using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{

    
    public partial class Page11 : Page
    {
        public Page11()
        {
            InitializeComponent();
            DataContext = new VM_Reg();
        }

        private void Tb5_OnPasswordChangedReg(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((VM_Reg)this.DataContext).Password = ((PasswordBox)sender).Password; }
        }
    }
}
