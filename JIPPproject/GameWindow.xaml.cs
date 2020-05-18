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
using System.Windows.Threading;
using System.Threading;
using System.Runtime.Remoting.Channels;
using System.Data.SqlClient;

namespace JIPPproject
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        string nickname = "";
        int gravity = 5;
        int entryPause = 0;
        DispatcherTimer gameTimer = new DispatcherTimer();
        double score = 0;
        Rect FlappyRect;
        bool gameover = false;
        int[,] array = new int[3, 2] { { -600, 400 }, { -350, 650 }, { -100, 900 } };
        


        public GameWindow(MainWindow window)
        {
            InitializeComponent();


            window.NicknameSelected += (sender, args) =>
            {
                MainWindow mainWindow = sender as MainWindow;
                if (mainWindow != null)
                {
                    nickname += mainWindow.NicknameSend;
                }
            };

            gameTimer.Tick += gameEngine;
            gameTimer.Interval = TimeSpan.FromMilliseconds(1);
            
            startGame();
        }
        private int randomizer()
        {

            Random rnd = new Random();
            return rnd.Next(0,2);
        }

        private void MyCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                flappyBird.RenderTransform = new RotateTransform(-20, flappyBird.Width / 2, flappyBird.Height / 2);
                gravity = -20;
            }
            else if(e.Key == Key.B && gameover == true)
            {
                startGame();
            }
            else if(e.Key == Key.Down)
            {
                flappyBird.RenderTransform = new RotateTransform(5, flappyBird.Width / 2, flappyBird.Height / 2);
                gravity = 20;
            }
        }

        private void MyCanvas_KeyUp(object sender, KeyEventArgs e)
        {
            flappyBird.RenderTransform = new RotateTransform(5, flappyBird.Width / 2, flappyBird.Height / 2);
            gravity = 5;
        }
        private void startGame()
        {
            
            //loading default settings - for safety
            score = 0;
            Canvas.SetTop(flappyBird, 260);
            gameover = false;
            entryPause = 0;
            Canvas.SetLeft(obs11, 1920);
            Canvas.SetTop(obs11, -600);
            Canvas.SetLeft(obs12, 1920);
            Canvas.SetTop(obs12, 400);
            Canvas.SetLeft(obs21, 480);
            Canvas.SetTop(obs21, -600);
            Canvas.SetLeft(obs22, 480);
            Canvas.SetTop(obs22, 400);
            Canvas.SetLeft(obs31, 960);
            Canvas.SetTop(obs31, -350);
            Canvas.SetLeft(obs32, 960);
            Canvas.SetTop(obs32, 650);
            Canvas.SetLeft(obs41, 1440);
            Canvas.SetTop(obs41, -100);
            Canvas.SetLeft(obs42, 1440);
            Canvas.SetTop(obs42, 900);
            Canvas.SetLeft(endGameButton, 1920);
            gameTimer.Start();
            
            


        }
        private void gameEngine(object sender, EventArgs e)
        {
            if(entryPause == 0) //przerwa na starcie gry
            {
                gameTimer.Stop();
                Thread.Sleep(2000);
                gameTimer.Start();
                entryPause = 1;
            }
            scoreText.Content = "Score: " + score; //wyswietlanie wyniku i nicku
            nicknameText.Content = "Nick: " + nickname;
            FlappyRect = new Rect(Canvas.GetLeft(flappyBird)+31, Canvas.GetTop(flappyBird)+11, 77, 64); //creating hitbox on top of the flappy bird
            Canvas.SetTop(flappyBird, Canvas.GetTop(flappyBird) + gravity); //obnizanie flappy birda co tick zegara
            if(Canvas.GetTop(flappyBird)>1000 || Canvas.GetTop(flappyBird) < -50) //jezeli wyjdzie za gore lub dol ekranu stop
            {
                scoreText.Content += " press B to try again";
                gameTimer.Stop();
                gameover = true;
                Canvas.SetLeft(endGameButton, 860);
                new Thread(delegate () { //wywolywanie funkcji zapisu w bazie danych w nowym wątku
                    sendDatatoDB(nickname, score);
                }).Start();
                
            }
            foreach(var x in MyCanvas.Children.OfType<Image>()) // dla kazdego x ktory jest typem obrazu
            {
                if((string)x.Tag == "obs1" || (string)x.Tag == "obs2" || (string)x.Tag == "obs3" || (string)x.Tag == "obs4")
                {
                    Canvas.SetLeft(x, Canvas.GetLeft(x) - 5); 
                    Rect pillar = new Rect(Canvas.GetLeft(x),Canvas.GetTop(x),x.Width,x.Height);
                    if (FlappyRect.IntersectsWith(pillar))
                    {
                        gameTimer.Stop();
                        gameover = true;
                        scoreText.Content += " press B to try again";
                        Canvas.SetLeft(endGameButton, 860);
                        new Thread(delegate () {
                            sendDatatoDB(nickname, score);
                        }).Start();
                        
                    }


                }
                if ((string)x.Tag == "cld")
                {
                    Canvas.SetLeft(x, Canvas.GetLeft(x) - 1);
                    if(Canvas.GetLeft(x) < -400)
                    {
                        Canvas.SetLeft(x, 1920);
                    }
                }
                int random = randomizer();
                if((string)x.Name == "obs21" && Canvas.GetLeft(x) < -116)
                {
                    Canvas.SetLeft(x, 1920);
                    Canvas.SetTop(x, array[random, 0]);
                    score += 0.5;
                }
                if ((string)x.Name == "obs22" && Canvas.GetLeft(x) < -116)
                {
                    Canvas.SetLeft(x, 1920);
                    Canvas.SetTop(x, array[random, 1]);
                    score += 0.5;
                }
                if ((string)x.Name == "obs11" && Canvas.GetLeft(x) < -120)
                {
                    Canvas.SetLeft(x, 1920);
                    Canvas.SetTop(x, array[random, 0]);
                    score += 0.5;
                }
                if ((string)x.Name == "obs12" && Canvas.GetLeft(x) < -120)
                {
                    Canvas.SetLeft(x, 1920);
                    Canvas.SetTop(x, array[random, 1]);
                    score += 0.5;
                }
                if ((string)x.Name == "obs31" && Canvas.GetLeft(x) < -112)
                {
                    Canvas.SetLeft(x, 1920);
                    Canvas.SetTop(x, array[random, 0]);
                    score += 0.5;
                }
                if ((string)x.Name == "obs32" && Canvas.GetLeft(x) < -112)
                {
                    Canvas.SetLeft(x, 1920);
                    Canvas.SetTop(x, array[random, 1]);
                    score += 0.5;
                }
                if ((string)x.Name == "obs41" && Canvas.GetLeft(x) < -116)
                {
                    Canvas.SetLeft(x, 1920);
                    Canvas.SetTop(x, array[random, 0]);
                    score += 0.5;
                }
                if ((string)x.Name == "obs42" && Canvas.GetLeft(x) < -116)
                {
                    Canvas.SetLeft(x, 1920);
                    Canvas.SetTop(x, array[random, 1]);
                    score += 0.5;
                }
            }
            
        }

        private void endGameButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void sendDatatoDB(string nickname, double score) //funkcja zapisu do bazy danych
        {
            D4042020DataSetTableAdapters.ScoreTableAdapter scoreTableAdapter = new D4042020DataSetTableAdapters.ScoreTableAdapter();
            scoreTableAdapter.Insert(nickname, (int)score);
            


            //SqlConnection connection = new SqlConnection("Data Source=sqltester2018.wwsi.edu.pl;Initial Catalog=D4042020;Persist Security Info=True;User ID=d4042020;Password=wwsi2020d404");
            //SqlDataAdapter da = new SqlDataAdapter();
            //da.InsertCommand = new SqlCommand("Insert into cgdowski.score values(@nickname, @score)", connection);

            //da.InsertCommand.Parameters.Add("@nickname", System.Data.SqlDbType.VarChar).Value = nickname;
            //da.InsertCommand.Parameters.Add("@score", System.Data.SqlDbType.Int).Value = score;
            //connection.Open();
            //da.InsertCommand.ExecuteNonQuery();
            //connection.Close();
        }
        private void aaa()
        {

        }
    }
}
