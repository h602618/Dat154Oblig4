using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Lib.Context;
using Lib.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelDesktop;

public class EditReservation
    : INotifyPropertyChanged
{
    readonly MyDbContext ctx = new();
    readonly reservations? Reservation;

    public ObservableCollection<string> ReservationStatuses { get; } = new(Enum.GetNames(typeof(ReservationStatus)));

    public EditReservation(reservations reservation)
    {
        ctx.reservations.Load();
        Reservation = ctx.reservations.FirstOrDefault(r => r.roomNr == reservation.roomNr);
    }


    public string Status {
        get => Reservation?.status ?? ReservationStatus.Booked.ToString();
        set {
            if (Reservation != null)
            {
                Reservation.status = value;
                OnPropertyChanged();
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
