using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Lib.Context;
using Lib.Models;

namespace HotelDesktop;

public class NewReservation : INotifyPropertyChanged
{

    readonly MyDbContext ctx = new();

    public ObservableCollection<customer> Customers { get; set; }
    public int roomNr { get; set; }
    public customer SelectedCustomer { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public NewReservation()
    {
        Customers = new ObservableCollection<customer>(ctx.customer.ToList());
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public void CreateReservation()
    {
        reservations reservation = new() {
            roomNr = roomNr,
            customerId = SelectedCustomer.id,
            start = StartDate,
            end = EndDate,
            status = ReservationStatus.Booked.ToString()
        };

        ctx.reservations.Add(reservation);
        ctx.SaveChanges();
    }
}
