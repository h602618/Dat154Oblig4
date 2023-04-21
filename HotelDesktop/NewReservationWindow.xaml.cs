using System.Windows;

namespace HotelDesktop;

public partial class NewReservationWindow
{
    public NewReservationWindow()
    {
        InitializeComponent();
    }

    void CreateButton_Click(object sender, RoutedEventArgs e)
    {
        var viewModel = DataContext as NewReservation;
        viewModel?.CreateReservation();
        Close();
    }
}
