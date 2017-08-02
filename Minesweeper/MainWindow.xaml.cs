using System.Windows;
using System.Windows.Media.Animation;

namespace Minesweeper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void SettingsControl_Loaded(object sender, RoutedEventArgs e)
        {
            Storyboard sb = new Storyboard();
            sb.Begin();

              
        }
    }
}
