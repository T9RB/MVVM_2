using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            DataContext = new VM_Authorization();
        }
        //localdbContext db = new();
        //public User? selUs;
        //private void Button1_Click(object sender, RoutedEventArgs e)
        //{
        //    selUs = db.Users.FirstOrDefault(x => x.Login == Log_Box.Text && x.Password == PassBox.Text);
        //    if (selUs == null)
        //    {
        //        MessageBox.Show("Неверный логин или пароль!");
        //        return;
        //    }

        //    if (selUs != null)
        //    {
        //        Service.user = selUs;
        //        MessageBox.Show("Вы вошли");
        //        Visibility = Visibility.Hidden;

        //    }
        //}

        //private void Buttno2_Click(object sender, RoutedEventArgs e)
        //{
        //    Service.frame.Navigate(new Uri("Page/Page11.xaml", UriKind.Relative));
        //}
    }
}
