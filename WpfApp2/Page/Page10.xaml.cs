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
    /// Логика взаимодействия для Page10.xaml
    /// </summary>
    public partial class Page10 : Page
    {
        public Page10()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tb1.Text == null || tb2.Text == null)
            {
                MessageBox.Show("Введите имя и описание задачи!");
                return;
            }
            if (tb1.Text != null && tb2.Text != null)
            {
                Task task = new()
                {
                    NameTask = tb1.Text,
                    DescriptionTask = tb2.Text,
                    DatePub = DateTime.Now,
                    CreatorId = Service.user.Userid,
                    AcceptorId = Service.user.Userid,
                    Statusid = 1
                };
                Service.db.Tasks.Add(task);
                Service.db.SaveChanges();
                MessageBox.Show("Данные добавлены");

            }
        }
    }
}
