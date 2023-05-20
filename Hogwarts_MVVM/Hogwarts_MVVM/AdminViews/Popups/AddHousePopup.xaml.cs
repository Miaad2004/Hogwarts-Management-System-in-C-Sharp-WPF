using Hogwarts.Core.Models.ForestManagement.DTOs;
using Hogwarts.Core.Models.HouseManagement;
using Hogwarts.Core.Models.HouseManagement.Exceptions;
using Hogwarts.Core.SharedServices;
using Microsoft.Win32;
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
    /// Interaction logic for AddHousePopup.xaml
    /// </summary>
    public partial class AddHousePopup : Window
    {
        private string SelectedImagePath = "";
        public AddHousePopup()
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

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new()
            {
                Multiselect = false,
                Filter = "Image Files(*.JPG; *.JPEG; *.PNG; *.GIF)| *.JPG; *.JPEG; *.PNG; *.GIF",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            };
            _ = openFileDialog.ShowDialog();
            txtOpenFile.Text = openFileDialog.FileName;
            SelectedImagePath = openFileDialog.FileName;
        }

        private void AddHouse_Click(object sender, RoutedEventArgs e)
        {
            HouseType selectedHouseType = (HouseType)houseCombo.SelectedIndex;

            try
            {
                StaticServiceProvidor.houseService.AddHouse(selectedHouseType, SelectedImagePath);

                MessageBox.Show("House Addes Successfully.", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }

            catch (Exception ex)
            {
                if (ex is ArgumentException ||
                    ex is HouseException)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                else
                {
                    throw ex;
                }
            }

        }
    }
}
