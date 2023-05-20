using Hogwarts.Core.Models.CourseManagement;
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

namespace Hogwarts.Views.StudentViews.Popups
{
    /// <summary>
    /// Interaction logic for ViewAssignmentDescriptionPopup.xaml
    /// </summary>
    public partial class ViewAssignmentDescriptionPopup : Window
    {
        private StudentAssignment StudentAssignment { get; set; }
        public ViewAssignmentDescriptionPopup(StudentAssignment studentAssignment)
        {
            InitializeComponent();
            StudentAssignment = studentAssignment;
            UpdateTextBox();
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

        private void UpdateTextBox()
        {
            string[] lines = StudentAssignment.Assignment.Description.Split('\n');
            foreach (string line in lines)
            {
                txtDescription.Document.Blocks.Add(new Paragraph(new Run(line)));
            }
        }
    }
}
