using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using Lib.Context;
using Lib.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelDesktop;

public class RoomDetails
    : INotifyPropertyChanged
{
    readonly MyDbContext ctx = new();
    ObservableCollection<reservations> _reservations;

    public ObservableCollection<reservations> Reservations {
        get => _reservations;
        set {
            _reservations = value;
            OnPropertyChanged();
        }
    }

    public RoomDetails(room room)
    {
        ctx.reservations.Load();
        Reservations =
            new ObservableCollection<reservations>(ctx.reservations.Where(r => r.roomNr == room.nr).ToList());
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public void RemoveReservation(reservations reservation)
    {
        ctx.reservations.Remove(reservation);
        ctx.SaveChanges();
    }
}
