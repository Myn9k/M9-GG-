using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Games
{
    public partial class JumpingGame : Window
    {
        private bool isJumping = false;
        private DispatcherTimer gameTimer = new DispatcherTimer();
        private double obstacleSpeed = 8;
        private double gravity = 0.5;
        private double jumpVelocity = 10;
        private double currentJumpVelocity = 0;
        private MediaPlayer _hitSoundPlayer;

        public JumpingGame()
        {
            InitializeComponent();
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Tick += GameLoop;
            gameTimer.Start();
            this.KeyDown += OnKeyDown;
            _hitSoundPlayer = new MediaPlayer();
            _hitSoundPlayer.Open(new Uri("music\\metallicheskaya-truba-padayuschiy-zvuk.wav", UriKind.Relative));
        }
        private void PlayHitSound()
        {
            _hitSoundPlayer.Position = TimeSpan.Zero;
            _hitSoundPlayer.Play();
        }

        private void GameLoop(object sender, EventArgs e)
        {
            // Двигаем препятствие
            double obstacleLeft = Canvas.GetLeft(Obstacle);
            Canvas.SetLeft(Obstacle, obstacleLeft - obstacleSpeed);

            // Если препятствие вышло за экран, возвращаем его в начало
            if (Canvas.GetLeft(Obstacle) + Obstacle.Width < 0)
            {
                Canvas.SetLeft(Obstacle, GameCanvas.ActualWidth);
            }

            // Логика прыжка
            if (isJumping)
            {
                Canvas.SetBottom(Player, Canvas.GetBottom(Player) + currentJumpVelocity);
                currentJumpVelocity -= gravity; // Применяем гравитацию

                // Если достигли максимальной высоты, начинаем падение
                if (currentJumpVelocity <= 0)
                {
                    isJumping = false;
                }
            }
            else if (Canvas.GetBottom(Player) > 50) // Падение, если не на земле
            {
                Canvas.SetBottom(Player, Canvas.GetBottom(Player) - gravity * 5); // Плавное падение
            }

            // Проверка столкновения с препятствием
            if (CheckCollision(Player, Obstacle))
            {
                gameTimer.Stop();
                PlayHitSound();
                MessageBox.Show("Игра окончена!");
                MainWindow window = new MainWindow();
                window.Show();
                this.Close();
            }

            // Пауза емаё
            if (Keyboard.IsKeyDown(Key.Q))
            {
                StopGame();
            }
        }
        private void StopGame()
        {
            gameTimer.Stop();
            Menu.Visibility = Visibility.Visible;
        }

        private bool CheckCollision(Image player, Image obstacle)
        {
            double playerLeft = Canvas.GetLeft(player);
            double playerRight = playerLeft + player.Width;
            double playerBottom = Canvas.GetBottom(player);
            double playerTop = playerBottom + player.Height;

            double obstacleLeft = Canvas.GetLeft(obstacle);
            double obstacleRight = obstacleLeft + obstacle.Width;
            double obstacleBottom = Canvas.GetBottom(obstacle);
            double obstacleTop = obstacleBottom + obstacle.Height;

            return playerRight >= obstacleLeft && playerLeft <= obstacleRight &&
                   playerBottom <= obstacleTop && playerTop >= obstacleBottom;
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            // Начинаем прыжок
            if (e.Key == Key.Space && !isJumping && Canvas.GetBottom(Player) <= 50)
            {
                isJumping = true;
                currentJumpVelocity = jumpVelocity;
            }
        }
        private void menus(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void continues(object sender, RoutedEventArgs e)
        {
            gameTimer.Start();
            Menu.Visibility = Visibility.Hidden;
        }
    }
}
