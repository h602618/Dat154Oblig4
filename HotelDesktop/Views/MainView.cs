using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Lib.Context;
using Lib.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelDesktop;

public class MainView
{
    readonly MyDbContext ctx = new();
    ObservableCollection<room> _rooms;

    public ObservableCollection<room> Rooms {
        get => _rooms;
        set {
            _rooms = value;
            OnPropertyChanged();
        }
    }

    public MainView()
    {
        ctx.reservations.Load();
        Rooms = new ObservableCollection<room>(ctx.room.ToList());

    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
