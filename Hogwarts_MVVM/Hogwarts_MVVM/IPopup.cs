using System.Windows;
using System.Windows.Input;

namespace Hogwarts.Views
{
    public interface IPopup
    {
        void Window_MouseDown(object sender, MouseButtonEventArgs e);
        void Minimize_Click(object sender, RoutedEventArgs e);
        void Close_Click(object sender, RoutedEventArgs e);
    }
}
