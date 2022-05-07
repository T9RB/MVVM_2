using Microsoft.EntityFrameworkCore;
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
    /// <summary>
    /// Логика взаимодействия для Page8.xaml
    /// </summary>
    public partial class Page8 : Page
    {
        public Page8()
        {
            InitializeComponent();
            DataContext = new FiltDate();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var fdt = calendar1.SelectedDate;
            //var sdt = calendar2.SelectedDate;
            //var CollectionTasks1 = CollectionTasks.Where(x => x.DatePub >= fdt && x.DatePub <= sdt).OrderBy(x => x.DatePub).ToList();
            //lbox5.ItemsSource = CollectionTasks1;
            //MessageBox.Show($"Найдено {CollectionTasks1.Count} задач!");
        }


    }
}
