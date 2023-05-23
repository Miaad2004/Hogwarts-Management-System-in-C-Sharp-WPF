using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.CourseManagement;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace Hogwarts.Views.ProfessorViews.Popups
{
    /// <summary>
    /// Interaction logic for ViewAssingmentDescription.xaml
    /// </summary>
    public partial class ViewAssignmentDescriptionPopup : Window, IPopup
    {
        private Assignment Assignment { get; set; }

        public ViewAssignmentDescriptionPopup(Assignment assignment)
        {
            InitializeComponent();
            SessionManager.AuthorizeMethodAccess(AccessLevels.Professor);

            Assignment = assignment;

            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            UpdateTextBox();
        }

        private void UpdateTextBox()
        {
            string[] lines = Assignment.Description.Split('\n');
            foreach (string line in lines)
            {
                txtDescription.Document.Blocks.Add(new Paragraph(new Run(line)));
            }
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
