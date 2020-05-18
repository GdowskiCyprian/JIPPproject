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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace JIPPproject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public event EventHandler NicknameSelected;
        public String NicknameSend { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void StartGameButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.nicknameTextBox.Text == "Enter your nickname to play game")
            {
                MessageBox.Show("Enter your nickname to play");
            }
            else if (this.nicknameTextBox.Text.Length > 14)
            {
                MessageBox.Show("Your nickname is too long (>14!)");
            }
            else
            {

                NicknameSend = this.nicknameTextBox.Text;

                GameWindow gameWindow = new GameWindow(this);

                gameWindow.Show();
                NicknameSelected?.Invoke(this, EventArgs.Empty);
            }
        }

        private void HighScoresButton_Click(object sender, RoutedEventArgs e)
        {
            HighScoresWindow highScoresWindow = new HighScoresWindow();
            highScoresWindow.ShowDialog();
        }

      
    }
}
/* zatrzymanie na chwile gry po otworzeniu okna
 * jakas klase delegata
 * wysylanie wyniku do bazy danych
 * przesylanie informacji o nicku i wyniku pomiedzy oknami
 * 
 * 
 * 
 */
