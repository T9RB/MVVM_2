using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WpfApp2;

public class HistoryTasks : VM_Super
{
    private ObservableCollection<Task> _historyusertasks = new(Service.db.Tasks.Include(x => x.Status).Where(x => x.AcceptorId == Service.user.Userid && x.Statusid == 3));

    public ObservableCollection<Task> HistoryUserTasks
    {
        get => _historyusertasks;
        set
        {
            _historyusertasks = value;
            OnPropertyChanged();
        }
    }
}