using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MaterialDesignThemes.Wpf;

namespace WpfApp2
{
    public class VM_Authorization : VM_Super
    {
        private string _login;
        private string _password;
        private RelayCommand _authorization;
        private RelayCommand _registr;

        public RelayCommand Auth => _authorization ??
                                    (_authorization = new RelayCommand((x) =>
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
                                            OnPropertyChanged();
                                            Service.frame.Navigate(new ClearPage());
                                        }
                                    }));

        public RelayCommand Registr => _registr ??
                                       (_registr = new RelayCommand((x) =>
                                       {
                                           Service.frame.Navigate(new Page11());
                                       }));

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

    }
}
