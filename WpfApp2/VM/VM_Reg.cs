using System.Windows;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace WpfApp2;

public class VM_Reg : VM_Super
{
    private RelayCommand register;
    private string fname;
    private string sname;
    private string lname;
    private string login;
    private string password;
    private string number;
    public RelayCommand Register => register ??
                                    (register = new RelayCommand((x) =>
                                    {
                                        if (FName == null || SName == null || LName == null || Login == null || Password == null || Number == null)
                                        {
                                            MessageBox.Show("Заполните полностью все поля регистрации");
                                            return;
                                        }

                                        if (FName != null && SName != null && LName != null && Login != null && Password != null && Number != null)
                                        {
                                            if (Number.Length > 11 || Number.Length < 11)
                                            {
                                                MessageBox.Show("Номер введен неправильно!");
                                            }
                                            if(Number.Length == 11)
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

    public string FName
    {
        get => fname;
        set
        {
            fname = value;
            OnPropertyChanged();
        }
    }

    public string SName
    {
        get => sname;
        set
        {
            sname = value;
            OnPropertyChanged();
        }
    }

    public string LName
    {
        get => lname;
        set
        {
            lname = value;
            OnPropertyChanged();
        }
    }

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

    public string Number
    {
        get => number;
        set
        {
            number = value;
            OnPropertyChanged();
        }
    }
}