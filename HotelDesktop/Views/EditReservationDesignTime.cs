using System;
using System.Collections.Generic;
using Lib.Models;

namespace HotelDesktop;

public class EditReservationDesignTime : EditReservation
{
    public EditReservationDesignTime() : base(new() {
        start = DateTime.Now,
        end = DateTime.Now,
        customerId = 1,
        roomNr = 1,
        status = ReservationStatus.Booked.ToString()
    })
    {
    }
}
