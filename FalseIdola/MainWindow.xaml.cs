using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FalseIdola
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

        public void ClickOpen(object sender, RoutedEventArgs e)
        {
            var a = new AudioPlayer();
        }

        public void compositionsCB_SelectionChanged(object sender, RoutedEventArgs e)
        {
        }

        public void partsCB_SelectionChanged(object sender, RoutedEventArgs e)
        {
        }

        public void movementsCB_SelectionChanged(object sender, RoutedEventArgs e)
        {
        }
    }
}