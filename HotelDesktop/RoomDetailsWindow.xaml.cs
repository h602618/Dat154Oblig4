using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Lib.Models;

namespace HotelDesktop;

public partial class RoomDetailsWindow
{
    public RoomDetailsWindow(room room)
    {
        InitializeComponent();
        DataContext = new RoomDetails(room);
    }
    void NewReservation_Click(object sender, RoutedEventArgs e)
    {
        new NewReservationWindow().Show();
        Close();
    }
    void EditReservation_Click(object sender, MouseButtonEventArgs e)
    {
        var reservation = (reservations)ReservationsListView.SelectedItem;
        new EditReservationWindow(reservation).Show();
        Close();
    }
    void DeleteReservation_Click(object sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        if (button?.Tag is reservations reservation)
        {
            var viewModel = DataContext as RoomDetails;
            viewModel?.RemoveReservation(reservation);
        }
        Close();
    }
}
