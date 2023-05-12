using Hogwarts.Core.SharedServices;
using System;
using System.Windows;
using System.Windows.Input;

namespace Hogwarts.Views.AdminViews.Popups
{
    /// <summary>
    /// Interaction logic for AddTrainPopup.xaml
    /// </summary>
    public partial class AddTrainPopup : Window
    {
        public AddTrainPopup()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddTrain_Click(object sender, RoutedEventArgs e)
        {
            int selectedHour = hourComboBox.SelectedIndex + 1;
            string selectedAmPm = amPmComboBox.SelectedIndex == 0 ? "am" : "pm";

            string dateString = depaurtureDatePicker.SelectedDate.Value.ToString("MM/dd/yyyy");
            string timeString = $"{selectedHour} {selectedAmPm}";
            string dateTimeString = $"{dateString} {timeString}";
            DateTime depaurtureTime = DateTime.Parse(dateTimeString);

            try
            {
                _ = StaticServiceProvidor.trainService.AddTrain(depaurtureTime,
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
    }
}
