using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.CourseManagement;
using Hogwarts.Core.Models.CourseManagement.DTOs;
using Hogwarts.Core.Models.CourseManagement.Exceptions;
using Hogwarts.Core.Models.CourseManagement.Services;
using Hogwarts_MVVM;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace Hogwarts.Views.ProfessorViews.Popups
{
    /// <summary>
    /// Interaction logic for AddAssignmentPopup.xaml
    /// </summary>
    public partial class AddAssignmentPopup : Window, IPopup
    {
        private readonly IAssignmentService assignmentService;
        private static Guid CurrentProfessorId => SessionManager.CurrentSession?.User.Id ?? throw new ArgumentNullException(nameof(SessionManager.CurrentSession));
        private Course Course { get; set; }

        public AddAssignmentPopup(Course course)
        {
            InitializeComponent();
            SessionManager.AuthorizeMethodAccess(AccessLevels.Professor);

            // Dependency Injection
            var serviceProvider = (Application.Current as App ?? throw new ArgumentNullException(nameof(Application))).ServiceProvider;
            assignmentService = serviceProvider.GetRequiredService<IAssignmentService>();

            Course = course;
        }

        private async void AddAssignment_Click(object sender, RoutedEventArgs e)
        {
            string description = new TextRange(txtDescription.Document.ContentStart, txtDescription.Document.ContentEnd).Text;

            AssignmentDTO DTO = new()
            {
                Title = txtTitle.Text,
                Description = description,
                StartDate = DateTimeCombo2DateTime(startDatePicker, startHourComboBox, startAmPmComboBox),
                DueDate = DateTimeCombo2DateTime(dueDatePicker, dueHourComboBox, dueAmPmComboBox),
                RequireForestAccess = (bool)(forestAccessCheckBox?.IsChecked ?? throw new ArgumentNullException(nameof(forestAccessCheckBox.IsChecked))),
            };

            try
            {
                await assignmentService.AddAssignmentAsync(DTO, Course.Id, CurrentProfessorId);
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
                    throw;
                }
            }
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
