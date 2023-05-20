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
    /// Interaction logic for AddCoursePopup.xaml
    /// </summary>
    public partial class AddCoursePopup : Window
    {
        public AddCoursePopup()
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

        private static TimeOnly Combo2TimeOnly(ComboBox hourCombo, ComboBox amPmCombo)
        {
            int selectedHour = hourCombo.SelectedIndex + 1;
            string selectedAmPm = amPmCombo.SelectedIndex == 0 ? "am" : "pm";

            string timeString = $"{selectedHour.ToString("00")}:00 {selectedAmPm}";
            DateTime dateTime = DateTime.ParseExact(timeString, "hh:mm tt", null);

            return TimeOnly.FromDateTime(dateTime);
        }
        private void AddCourse_Click(object sender, RoutedEventArgs e)
        {
            CourseDTO DTO = new()
            {
                Title = txtTitle.Text,
                EndDate = DateOnly.FromDateTime((DateTime)endDatePicker.SelectedDate),
                Schedule = (DayOfWeek)scheduleComboBox.SelectedIndex,
                ClassStartTime = Combo2TimeOnly(startHourComboBox, startAmPmComboBox),
                ClassEndTime = Combo2TimeOnly(endHourComboBox, endAmPmComboBox),
                Capacity = txtCapacity.Text,
                Classroom = txtClassroom.Text,
            };

            try
            {
                StaticServiceProvidor.courseService.AddCourse(DTO);
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
                    throw ex;
                }
            }
        }
    }
}
