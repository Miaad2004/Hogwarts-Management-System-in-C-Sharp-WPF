using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.TrainManagement;
using Hogwarts.Core.Models.TrainManagement.Exceptions;
using Hogwarts.Core.SharedServices;
using Hogwarts.Core.SharedServices.Exceptions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hogwarts.Views.StudentViews.Pages
{
    /// <summary>
    /// Interaction logic for HogwartsExpressView.xaml
    /// </summary>
    public partial class HogwartsExpressView : Page
    {
        private ObservableCollection<Train> Trains
        {
            get { return StaticServiceProvidor.facultyService.GetList<Train>(t => t.DepartureTime); }
        }
        public HogwartsExpressView()
        {
            InitializeComponent();
            OnDataGridChanged();
        }
        private void ReserveSeat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User? ticketOwner = SessionManager.CurrentSession.User;
                Button button = sender as Button;
                Train selectedTrain = button.DataContext as Train;
                TrainTicket trainTicket = StaticServiceProvidor.trainService.GetTrainTicket(selectedTrain, ticketOwner);

                MessageBox.Show("Seat Reserved Successfully.",
                                "Success!",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);

                MessageBoxResult choice = MessageBox.Show("Would you like the ticket to be sent to your email?",
                                                          "Question!",
                                                          MessageBoxButton.YesNo,
                                                          MessageBoxImage.Question);
                if (choice == MessageBoxResult.Yes)
                {
                    StaticServiceProvidor.letterService.SendTrainTicket(trainTicket, ticketOwner);
                    MessageBox.Show("Ticket sent successfully",
                                    "Success!",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                }
            }

            catch (Exception ex)
            {
                if (ex is ArgumentException ||
                    ex is TrainException ||
                    ex is NetworkConnectionException)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                else
                {
                    throw ex;
                }
            }

            OnDataGridChanged();
        }
        private void OnDataGridChanged()
        {
            trainsDataGrid.ItemsSource = Trains;
            trainsDataGrid.Items.Refresh();
        }
    }
}
