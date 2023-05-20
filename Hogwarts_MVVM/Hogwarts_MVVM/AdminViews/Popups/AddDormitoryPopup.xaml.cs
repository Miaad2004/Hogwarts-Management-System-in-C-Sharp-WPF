using Hogwarts.Core.Models.HouseManagement;
using Hogwarts.Core.SharedServices;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Hogwarts.Views.AdminViews.Popups
{
    /// <summary>
    /// Interaction logic for AddDormitoryPopup.xaml
    /// </summary>
    public partial class AddDormitoryPopup : Window
    {
        public AddDormitoryPopup()
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

        private void AddDormitory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StaticServiceProvidor.dormitoryService.AddDormitory(title: txtTitle.Text,
                                                                    house: (HouseType)houseCombo.SelectedIndex,
                                                                    floorsCount: floorsCountCombo.SelectedIndex + 1,
                                                                    roomsPerFloor: roomsPerFloorCombo.SelectedIndex + 1,
                                                                    bedsPerRoom: bedsPerRoomCombo.SelectedIndex + 1);

                MessageBox.Show("Dormitory Added.", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }

            catch (ArgumentException ex)
            {
                _ = MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
