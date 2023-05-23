using Hogwarts.Core.Data;
using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.TrainManagement;
using Hogwarts.Core.Models.TrainManagement.Exceptions;
using Hogwarts.Core.Models.TrainManagement.Services;
using Hogwarts.Core.SharedServices;
using Hogwarts.Core.SharedServices.Exceptions;
using Hogwarts_MVVM;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Hogwarts.Views.StudentViews.Pages
{
    /// <summary>
    /// Interaction logic for HogwartsExpressView.xaml
    /// </summary>
    public partial class HogwartsExpressView : Page
    {
        private readonly HogwartsDbContext dbContext;
        private readonly ITrainService trainService;
        private readonly ILetterService letterService;

        public HogwartsExpressView()
        {
            InitializeComponent();
            SessionManager.AuthorizeMethodAccess(AccessLevels.Student);

            // Dependency Injection
            var serviceProvider = (Application.Current as App ?? throw new ArgumentNullException(nameof(Application))).ServiceProvider;
            dbContext = serviceProvider.GetRequiredService<HogwartsDbContext>();
            trainService = serviceProvider.GetRequiredService<ITrainService>();
            letterService = serviceProvider.GetRequiredService<ILetterService>();

            Loaded += OnLoaded;
        }

        private async void ReserveSeat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User? ticketOwner = SessionManager.CurrentSession?.User ?? throw new ArgumentNullException(nameof(SessionManager.CurrentSession));
                Button? button = sender as Button;
                Train selectedTrain = button?.DataContext as Train ?? throw new ArgumentNullException();

                TrainTicket trainTicket = await trainService.GetTrainTicketAsync(selectedTrain.Id, ticketOwner);

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
                    await letterService.SendTrainTicketAsync(trainTicket, ticketOwner);
                    MessageBox.Show("Ticket sent successfully",
                                    "Success!",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                }

                await PopulateDataGrid();
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
                    throw;
                }
            }
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            await PopulateDataGrid();
        }

        private async Task PopulateDataGrid()
        {
            ObservableCollection<Train> trains = await dbContext.GetListAsync<Train>(orderBy: t => t.DepartureTime);
            trainsDataGrid.ItemsSource = trains;
        }
    }
}
