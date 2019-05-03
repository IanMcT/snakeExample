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

namespace snakeLogic
{

    public enum Direction {left, right, up, down};
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Snake snake;
        public System.Windows.Threading.DispatcherTimer gameTimer;
        int framesUntilMove = 1000/120 ;
        int frameCount = 0;


        public MainWindow()
        {
            InitializeComponent();
            snake = new Snake(canvas);
            gameTimer = new System.Windows.Threading.DispatcherTimer(); ;
            //start Timer
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60);//fps
            gameTimer.Start();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            
            frameCount++;
            if (frameCount >= framesUntilMove)
            {
                frameCount = 0;
                snake.update();
            }
        }
    }
}
