using Hogwarts.Core.Models.Forest;
using Hogwarts.Core.Models.Forest.DTOs;
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
    /// Interaction logic for AddPlantPopup.xaml
    /// </summary>
    public partial class AddPlantPopup : Window
    {
        private string SelectedPlantImagePath;
        public AddPlantPopup()
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
            SelectedPlantImagePath = openFileDialog.FileName;
        }

        private void AddPlant_Click(object sender, RoutedEventArgs e)
        {
            PlantDTO DTO = new()
            {
                Name = txtName.Text,
                Description = txtDescription.Text,
                Quantity = int.Parse(txtQuantity.Text),
                GrowthTimeSpan = TimeSpan.FromMinutes(growthRateComboBox.SelectedIndex + 1)

            };

            try
            {
                StaticServiceProvidor.forestService.AddPlant(DTO);

                MessageBox.Show("Plant Added successfully.", "Operation Successful!", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
