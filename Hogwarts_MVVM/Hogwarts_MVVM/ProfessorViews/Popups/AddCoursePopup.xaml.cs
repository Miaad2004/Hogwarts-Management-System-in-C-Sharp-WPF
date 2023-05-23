using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.CourseManagement.DTOs;
using Hogwarts.Core.Models.CourseManagement.Exceptions;
using Hogwarts.Core.Models.CourseManagement.Services;
using Hogwarts_MVVM;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Hogwarts.Views.ProfessorViews.Popups
{
    /// <summary>
    /// Interaction logic for AddCoursePopup.xaml
    /// </summary>
    public partial class AddCoursePopup : Window, IPopup
    {
        private readonly ICourseService courseService;

        public AddCoursePopup()
        {
            InitializeComponent();
            SessionManager.AuthorizeMethodAccess(AccessLevels.Professor);

            // Dependency Injection
            var serviceProvider = (Application.Current as App ?? throw new ArgumentNullException(nameof(Application))).ServiceProvider;
            courseService = serviceProvider.GetRequiredService<ICourseService>();
        }

        private async void AddCourse_Click(object sender, RoutedEventArgs e)
        {
            var selectedDate = endDatePicker.SelectedDate ?? throw new ArgumentNullException(nameof(endDatePicker.SelectedDate));

            CourseDTO DTO = new()
            {
                Title = txtTitle.Text,
                EndDate = DateOnly.FromDateTime((DateTime)selectedDate),
                Schedule = (DayOfWeek)scheduleComboBox.SelectedIndex,
                ClassStartTime = Combo2TimeOnly(startHourComboBox, startAmPmComboBox),
                ClassEndTime = Combo2TimeOnly(endHourComboBox, endAmPmComboBox),
                Capacity = txtCapacity.Text,
                Classroom = txtClassroom.Text,
            };

            try
            {
                await courseService.AddCourseAsync(DTO);
                MessageBox.Show("Course Added.", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }

            catch (Exception ex)
            {
                if (ex is ArgumentException ||
                    ex is CourseException)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    throw;
                }
            }
        }

        private static TimeOnly Combo2TimeOnly(ComboBox hourCombo, ComboBox amPmCombo)
        {
            int selectedHour = hourCombo.SelectedIndex + 1;
            string selectedAmPm = amPmCombo.SelectedIndex == 0 ? "am" : "pm";

            string timeString = $"{selectedHour:00}:00 {selectedAmPm}";
            DateTime dateTime = DateTime.ParseExact(timeString, "hh:mm tt", null);

            return TimeOnly.FromDateTime(dateTime);
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
