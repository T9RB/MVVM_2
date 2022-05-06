using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp2
{
    public class VM_Authorization : VM_Super
    {
        private string login;
        private string password;
        private RelayCommand authorization;
        private RelayCommand registr;

        public RelayCommand Auth => authorization ??
                                    (authorization = new RelayCommand((x) =>
                                    {
                                        User? selUser = Service.db.Users.FirstOrDefault(x =>
                                            x.Login == Login && x.Password == Password);
                                        if (selUser == null)
                                        {
                                            MessageBox.Show("Вы ввели неверный логин или пароль");
                                            return;
                                        }

                                        if (selUser != null)
                                        {
                                            Service.user = selUser;
                                            MessageBox.Show("Вы вошли!");
                                            Page1 pg1 = new();
                                            OnPropertyChanged();
                                        }
                                    }));

        public RelayCommand Registr => registr ??
                                       (registr = new RelayCommand((x) =>
                                       {
                                           Service.frame.Navigate(new Page11());
                                       }));

        public string Login
        {
            get => login;
            set
            {
                login = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

    }
}
