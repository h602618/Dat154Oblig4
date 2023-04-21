using System.Windows;
using Lib.Models;

namespace HotelDesktop;

public partial class EditReservationWindow
{
    public EditReservationWindow(reservations reservation)
    {
        InitializeComponent();
        DataContext = new EditReservation(reservation);
    }
    void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        //var viewModel = DataContext as EditReservation;
        //viewModel?.save();
    }
}
