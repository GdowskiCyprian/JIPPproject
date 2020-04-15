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

namespace JIPPproject
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        int gravity = 5;
        DispatcherTimer gameTimer = new DispatcherTimer();
        double score = 0;
        Rect FlappyRect;
        bool gameover = false;

        public GameWindow()
        {
            InitializeComponent();
        }
        private int randomizer()
        {
            Random rnd = new Random();
            return rnd.Next(1,4);
        }

        private void MyCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            gravity = -15;
        }

        private void MyCanvas_KeyUp(object sender, KeyEventArgs e)
        {
            gravity = 5;
        }
        private void startGame()
        {
            //loading default settings - for safety
            score = 0;
            Canvas.SetTop(flappyBird, 260);
            gameover = false;
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

        }
        private void gameEngine(object sender, EventArgs e)
        {
            scoreText.Content = "Score: " + score;

        }
    }
}
