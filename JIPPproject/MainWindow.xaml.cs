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

namespace JIPPproject
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

        private void StartGameButton_Click(object sender, RoutedEventArgs e)
        {
            GameWindow gameWindow = new GameWindow();
            gameWindow.Show();
        }

        private void HighScoresButton_Click(object sender, RoutedEventArgs e)
        {
            HighScoresWindow highScoresWindow = new HighScoresWindow();
            highScoresWindow.ShowDialog();
        }

        private void test1_Click(object sender, RoutedEventArgs e)
        {
            //SqlConnection cn = new SqlConnection("Server=sqltester2018.wwsi.edu.pl; Database=cgdowski.score; User Id=d4042020; Password=wwsi2020d404;");
            
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
