using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.ForestManagement.DTOs;
using Hogwarts.Core.Models.ForestManagement.Services;
using Hogwarts_MVVM;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Input;

namespace Hogwarts.Views.AdminViews.Popups
{
    /// <summary>
    /// Interaction logic for AddPlantPopup.xaml
    /// </summary>
    public partial class AddPlantPopup : Window, IPopup
    {
        private readonly IForestService forestService;
        private string SelectedImagePath = "";

        public AddPlantPopup()
        {
            InitializeComponent();
            SessionManager.AuthorizeMethodAccess(AccessLevels.Admin);

            // Dependency Injection
            var serviceProvider = (Application.Current as App ?? throw new ArgumentNullException(nameof(Application))).ServiceProvider;
            forestService = serviceProvider.GetRequiredService<IForestService>();
        }

        private async void AddPlant_Click(object sender, RoutedEventArgs e)
        {
            PlantDTO DTO = new()
            {
                Name = txtName.Text,
                Description = txtDescription.Text,
                Quantity = txtQuantity.Text,
                GrowthTimeSpan = TimeSpan.FromMinutes(growthRateComboBox.SelectedIndex + 1),
                ImagePath = SelectedImagePath
            };

            try
            {
                await forestService.AddPlantAsync(DTO);

                MessageBox.Show("Plant Added successfully.", "Operation Successful!", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
