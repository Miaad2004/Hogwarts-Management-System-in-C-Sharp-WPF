using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.DormitoryManagement.Services;
using Hogwarts.Core.Models.HouseManagement;
using Hogwarts_MVVM;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using System.Windows.Input;

namespace Hogwarts.Views.AdminViews.Popups
{
    /// <summary>
    /// Interaction logic for AddDormitoryPopup.xaml
    /// </summary>
    public partial class AddDormitoryPopup : Window, IPopup
    {
        private readonly IDormitoryService dormitoryService;

        public AddDormitoryPopup()
        {
            InitializeComponent();
            SessionManager.AuthorizeMethodAccess(AccessLevels.Admin);

            // Dependency Injection
            var serviceProvider = (Application.Current as App ?? throw new ArgumentNullException(nameof(Application))).ServiceProvider;
            dormitoryService = serviceProvider.GetRequiredService<IDormitoryService>();

        }

        private void AddDormitory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dormitoryService.AddDormitoryAsync(title: txtTitle.Text,
                                                   house: (HouseType)houseCombo.SelectedIndex,
                                                   floorsCount: floorsCountCombo.SelectedIndex + 1,
                                                   roomsPerFloor: roomsPerFloorCombo.SelectedIndex + 1,
                                                   bedsPerRoom: bedsPerRoomCombo.SelectedIndex + 1);

                MessageBox.Show("Dormitory Added.", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }

            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
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
