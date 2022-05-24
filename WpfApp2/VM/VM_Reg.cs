using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace WpfApp2;

public class VM_Reg : VM_Super
{
    private RelayCommand _register;
    private string _fname;
    private string _sname;
    private string _lname;
    private string _login;
    private string _password;
    private string _number;
    private RelayCommand _back;
    private ObservableCollection<User> _user = new(Service.db.Users);
    public RelayCommand Register => _register ??
                                    (_register = new RelayCommand((x) =>
                                    {
                                        if (FName == null || SName == null || LName == null || Login == null || Password == null || Number == null)
                                        {
                                            MessageBox.Show("Заполните полностью все поля регистрации");
                                            return;
                                        }

                                        if (FName != null && SName != null && LName != null && Login != null && Password != null && Number != null)
                                        {
                                            var userscol = UsersCol.FirstOrDefault(x => x.Login == Login);
                                            if (Number.Length > 11 || Number.Length < 11 || userscol != null)
                                            {
                                                MessageBox.Show("Номер введен неправильно или повторяющийся логин!");
                                            }
                                            if(Number.Length == 11 && userscol == null)
                                            {
                                                User user = new User()
                                                {
                                                    FName = FName,
                                                    SName = SName,
                                                    LName = LName,
                                                    Login = Login,
                                                    Password = Password,
                                                    NumberPhone = Number
                                                };
                                                Service.db.Users.Add(user);
                                                Service.db.SaveChanges();
                                                OnPropertyChanged();
                                                MessageBox.Show("Регистрация прошла успешно!");
                                                Service.frame.Navigate(new Page1());
                                            }
                                           
                                        }
                                    }));
    public RelayCommand Back => _back ??
                        (_back = new RelayCommand((x) =>
                        {
                            Service.frame.Navigate(new Page1());
                        }));

    public ObservableCollection<User> UsersCol
    {
        get => _user;
        set
        {
            _user = value;
            OnPropertyChanged();
        }
    }
    public string FName
    {
        get => _fname;
        set
        {
            _fname = value;
            OnPropertyChanged();
        }
    }

    public string SName
    {
        get => _sname;
        set
        {
            _sname = value;
            OnPropertyChanged();
        }
    }

    public string LName
    {
        get => _lname;
        set
        {
            _lname = value;
            OnPropertyChanged();
        }
    }

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

    public string Number
    {
        get => _number;
        set
        {
            _number = value;
            OnPropertyChanged();
        }
    }
}