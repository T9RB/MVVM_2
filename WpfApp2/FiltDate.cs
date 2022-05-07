using System.Globalization;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace WpfApp2;

public class FiltDate : VM_Super
{
    private RelayCommand filter;
    private Calendar calendar1;
    private Calendar calendar2;

    public RelayCommand Filter => filter ??
                                  (filter = new RelayCommand((x) =>
                                  {
                                      
                                  }));

    public Calendar Calendar1
    {
        get => calendar1;
        set
        {
            calendar1 = value;
            OnPropertyChanged();
        }
    }

    public Calendar Calendar2
    {
        get => calendar2;
        set
        {
            calendar2 = value;
            OnPropertyChanged();
        }
    }
}