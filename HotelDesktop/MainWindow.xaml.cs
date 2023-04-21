using System.Windows.Input;
using Lib.Models;

namespace HotelDesktop
{
    /// <summary>
    /// Interaction logic for MainView.cs.xaml
    /// </summary>
    public partial class MainWindow
    {
        MainWindow()
        {
            InitializeComponent();
            DataContext = new MainView();
        }

        void RoomsListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (RoomsListView.SelectedItem is room selectedRoom)
            {
                new RoomDetailsWindow(selectedRoom).Show();
            }
        }
    }
}
