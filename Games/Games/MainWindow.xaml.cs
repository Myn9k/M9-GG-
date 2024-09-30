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

namespace Games
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int game_id;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void JumpingGame(object sender, RoutedEventArgs e)
        {
            game_id = 1;
            games.Text = "JumpingGame";
        }

        private void PingPong(object sender, RoutedEventArgs e)
        {
            game_id = 2;
            games.Text = "PingPong";
        }

        private void Start(object sender, RoutedEventArgs e)
        {
            if(game_id == 1)
            {
                JumpingGame window = new JumpingGame();
                window.Show();
                this.Close();
            }
            if (game_id == 2)
            {
                Ping_Pong window = new Ping_Pong();
                window.Show();
                this.Close();
            }
        }
    }
}
