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
            else
            {

                NicknameSend = this.nicknameTextBox.Text;

                GameWindow gameWindow = new GameWindow(this);

                gameWindow.Show();

                NicknameSelected(this, EventArgs.Empty);
            }
        }

        private void HighScoresButton_Click(object sender, RoutedEventArgs e)
        {
            HighScoresWindow highScoresWindow = new HighScoresWindow();
            highScoresWindow.ShowDialog();
        }

        private void test1_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=sqltester2018.wwsi.edu.pl;Initial Catalog=D4042020;Persist Security Info=True;User ID=d4042020;Password=wwsi2020d404");
            SqlDataAdapter da = new SqlDataAdapter();
            da.InsertCommand = new SqlCommand("Insert into cgdowski.score values(@nickname, @score)",connection);
            da.InsertCommand.Parameters.Add("@nickname", System.Data.SqlDbType.VarChar).Value = "jd";
            da.InsertCommand.Parameters.Add("@score", System.Data.SqlDbType.Int).Value = 69;
            connection.Open();
            da.InsertCommand.ExecuteNonQuery();
            connection.Close();
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
