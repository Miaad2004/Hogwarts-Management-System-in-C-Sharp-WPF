using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.TrainManagement.Services;
using Hogwarts_MVVM;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Hogwarts.Views.AdminViews.Popups
{
    /// <summary>
    /// Interaction logic for AddTrainPopup.xaml
    /// </summary>
    public partial class AddTrainPopup : Window, IPopup
    {
        private readonly ITrainService trainService;

        public AddTrainPopup()
        {
            InitializeComponent();
            SessionManager.AuthorizeMethodAccess(AccessLevels.Admin);

            // Dependency Injection
            var serviceProvider = (Application.Current as App ?? throw new ArgumentNullException(nameof(Application))).ServiceProvider;
            trainService = serviceProvider.GetRequiredService<ITrainService>();
        }

        private static DateTime DateTimeCombo2DateTime(DatePicker datePicker, ComboBox hourCombo, ComboBox amPmCombo)
        {
            int selectedHour = hourCombo.SelectedIndex + 1;
            string selectedAmPm = amPmCombo.SelectedIndex == 0 ? "am" : "pm";

            string dateString = datePicker.SelectedDate.Value.ToString("MM/dd/yyyy");
            string timeString = $"{selectedHour} {selectedAmPm}";
            string dateTimeString = $"{dateString} {timeString}";

            return DateTime.Parse(dateTimeString);
        }

        private async void AddTrain_Click(object sender, RoutedEventArgs e)
        {
            DateTime depaurtureTime = DateTimeCombo2DateTime(depaurtureDatePicker, hourComboBox, amPmComboBox);

            try
            {
                await trainService.AddTrainAsync(depaurtureTime,
                                                 txtTitle.Text,
                                                 txtOrigin.Text,
                                                 txtDestination.Text,
                                                 txtPlatform.Text,
                                                 compartmentCountCombo.SelectedIndex + 1,
                                                 seatsPerCompartmentCombo.SelectedIndex + 1);

                _ = MessageBox.Show("Train Added.", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }

            catch (ArgumentException ex)
            {
                _ = MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        public void Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        public void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
