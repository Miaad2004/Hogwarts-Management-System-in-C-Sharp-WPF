using Hogwarts.Core.Models.DormitoryManagement;
using Hogwarts.Core.Models.Forest;
using Hogwarts.Core.SharedServices;
using Hogwarts.Views.AdminViews.Popups;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
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

namespace Hogwarts.Views.AdminViews.Pages
{
    /// <summary>
    /// Interaction logic for DormitoryView.xaml
    /// </summary>
    public partial class DormitoryView : Page
    {
        private ObservableCollection<Dormitory> Dormitories
        {
            get { return StaticServiceProvidor.facultyService.GetList<Dormitory>(orderBy: p => p.House); }
        }
        public DormitoryView()
        {
            InitializeComponent();
            OnDataGridChanged();
        }

        private void AddDormitory_Click(object sender, RoutedEventArgs e)
        {
            // Deactivate this window
            IsEnabled = false;

            AddDormitoryPopup popup = new();
            _ = popup.ShowDialog();

            // Refresh the page
            OnDataGridChanged();

            // Reactivate this window
            IsEnabled = true;
        }
        private void OnDataGridChanged()
        {
            dormitoriesDataGrid.ItemsSource = Dormitories;
            dormitoriesDataGrid.Items.Refresh();
        }
    }
}
