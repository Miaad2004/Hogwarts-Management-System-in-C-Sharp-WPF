using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.CourseManagement;
using Hogwarts.Core.Models.CourseManagement.DTOs;
using Hogwarts.Core.Models.CourseManagement.Exceptions;
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

namespace Hogwarts.Views.ProfessorViews.Popups
{
    /// <summary>
    /// Interaction logic for AddAssignmentPopup.xaml
    /// </summary>
    public partial class AddAssignmentPopup : Window
    {
        private Guid CurrentProfessorId => SessionManager.CurrentSession.User.Id;
        private Course Course { get; set; }
        public AddAssignmentPopup(Course course)
        {
            InitializeComponent();
            Course = course;
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
        private static DateTime DateTimeCombo2DateTime(DatePicker datePicker, ComboBox hourCombo, ComboBox amPmCombo)
        {
            int selectedHour = hourCombo.SelectedIndex + 1;
            string selectedAmPm = amPmCombo.SelectedIndex == 0 ? "am" : "pm";

            string dateString = datePicker.SelectedDate.Value.ToString("MM/dd/yyyy");
            string timeString = $"{selectedHour} {selectedAmPm}";
            string dateTimeString = $"{dateString} {timeString}";

            return DateTime.Parse(dateTimeString);
        }
        private void AddAssignment_Click(object sender, RoutedEventArgs e)
        {
            string description = new TextRange(txtDescription.Document.ContentStart, txtDescription.Document.ContentEnd).Text;

            AssignmentDTO DTO = new()
            {
                Title = txtTitle.Text,
                Description = description,
                StartDate = DateTimeCombo2DateTime(startDatePicker, startHourComboBox, startAmPmComboBox),
                DueDate = DateTimeCombo2DateTime(dueDatePicker, dueHourComboBox, dueAmPmComboBox),
                RequireForestAccess = (bool)forestAccessCheckBox.IsChecked,
            };

            try
            {
                StaticServiceProvidor.assignmentService.AddAssignment(DTO, Course.Id, CurrentProfessorId);
                MessageBox.Show("Assignment Added.", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }

            catch (Exception ex)
            {
                if (ex is ArgumentException ||
                    ex is AssignmentException)
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
