using System.Windows;

namespace Character_Making_File_Tool
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class WIPBox : Window
    {
        public WIPBox(string message)
        {
            this.Hide();
            InitializeComponent();
            messageLabel.BeginInit();
            messageLabel.Content = message;
            messageLabel.EndInit();
        }

        public void CenterWindowOnScreen()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }
    }
}
