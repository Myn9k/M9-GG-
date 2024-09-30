using System;
using System.Security.Claims;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace Games
{
    public partial class Ping_Pong : Window
    {
        // Скорость движения мяча по оси X и Y
        private double _ballXSpeed = 4;
        private double _ballYSpeed = 4;

        // Таймер для обновления состояния игры (движение мяча и проверка столкновений)
        private DispatcherTimer _gameTimer;

        // Счетчики очков для каждого игрока
        private int _leftScore = 0;
        private int _rightScore = 0;

        // Позиции ракеток (верхней и нижней) на оси X
        private double _bottomPaddlePosition = 360;
        private double _topPaddlePosition = 360;

        // Анимации для плавного движения ракеток
        private DoubleAnimation _bottomPaddleAnimation;
        private DoubleAnimation _topPaddleAnimation;
        private MediaPlayer _hitSoundPlayer;

        public Ping_Pong()
        {
            InitializeComponent();

            // Настройка анимации для нижней и верхней ракеток (продолжительность 0.3 секунды)
            _bottomPaddleAnimation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(0.1))
            };
            _topPaddleAnimation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(0.1))
            };

            // Настройка таймера для обновления состояния игры
            _gameTimer = new DispatcherTimer();
            _gameTimer.Interval = TimeSpan.FromMilliseconds(20); // Частота обновления — каждые 20 мс
            _gameTimer.Tick += Ball; // Привязка метода для обновления мяча
            _gameTimer.Start();

            // Добавляем обработчик рендеринга для отслеживания нажатий клавиш и движения ракеток
            CompositionTarget.Rendering += HandlePaddleMovement;

            _hitSoundPlayer = new MediaPlayer();
            _hitSoundPlayer.Open(new Uri("music\\metallicheskaya-truba-padayuschiy-zvuk.wav", UriKind.Relative));
        }

        // Метод для обработки движения ракеток
        private void HandlePaddleMovement(object sender, EventArgs e)
        {
            // Движение нижней ракетки влево (если нажата клавиша Left и ракетка не выходит за пределы канавы)
            if (Keyboard.IsKeyDown(Key.Left) && _bottomPaddlePosition > 0)
            {
                _bottomPaddlePosition -= 6;
                _bottomPaddleAnimation.To = _bottomPaddlePosition;
                BottomRectangle.BeginAnimation(Canvas.LeftProperty, _bottomPaddleAnimation);
            }
            // Движение нижней ракетки вправо (если нажата клавиша Right и ракетка не выходит за пределы канавы)
            else if (Keyboard.IsKeyDown(Key.Right) && _bottomPaddlePosition < GameCanvas.ActualWidth - BottomRectangle.Width)
            {
                _bottomPaddlePosition += 6;
                _bottomPaddleAnimation.To = _bottomPaddlePosition;
                BottomRectangle.BeginAnimation(Canvas.LeftProperty, _bottomPaddleAnimation);
            }

            // Движение верхней ракетки влево (если нажата клавиша A)
            if (Keyboard.IsKeyDown(Key.A) && _topPaddlePosition > 0)
            {
                _topPaddlePosition -= 6;
                _topPaddleAnimation.To = _topPaddlePosition;
                TopRectangle.BeginAnimation(Canvas.LeftProperty, _topPaddleAnimation);
            }
            // Пауза емаё
            if (Keyboard.IsKeyDown(Key.Q))
            {
                StopGame();
            }
            // Движение верхней ракетки вправо (если нажата клавиша S)

            else if (Keyboard.IsKeyDown(Key.S) && _topPaddlePosition < GameCanvas.ActualWidth - TopRectangle.Width)
            {
                _topPaddlePosition += 6;
                _topPaddleAnimation.To = _topPaddlePosition;
                TopRectangle.BeginAnimation(Canvas.LeftProperty, _topPaddleAnimation);
            }
        }
        private void StopGame()
        {
            _gameTimer.Stop();
            Menu.Visibility = Visibility.Visible;
        }
        private void PlayHitSound()
        {
            _hitSoundPlayer.Position = TimeSpan.Zero;
            _hitSoundPlayer.Play();
        }

        // Метод для проверки коллизии мяча с ракетками
        private bool CheckCollisionTOP(Rectangle rectangle)
        {
            // Получаем координаты мяча
            double ballLeft = Canvas.GetLeft(Shar);
            double ballTop = Canvas.GetTop(Shar);
            double ballRight = ballLeft + Shar.Width;
            double ballBottom = ballTop + Shar.Height;

            // Получаем координаты ракетки
            double rectangleLeft = Canvas.GetLeft(rectangle);
            double rectangleTop = Canvas.GetTop(rectangle);
            double rectangleRight = rectangleLeft + rectangle.Width;
            double rectangleBottom = rectangleTop + rectangle.Height;

            // Проверка коллизии: если мяч находится внутри области ракетки
            return ballRight >= rectangleLeft && ballLeft <= rectangleRight &&
                   ballBottom >= rectangleTop && ballTop <= rectangleBottom;
        }
        private bool CheckCollisionBottom(Rectangle rectangle)
        { 
            // Получаем координаты мяча
            double ballLeft = Canvas.GetLeft(Shar);
            double ballTop = Canvas.GetTop(Shar);
            double ballRight = ballLeft + Shar.Width;
            double ballBottom = ballTop + Shar.Height;

            // Получаем координаты ракетки
            double rectangleLeft = Canvas.GetLeft(rectangle);
            double rectangleTop = GameCanvas.ActualHeight - rectangle.ActualHeight - 10;
            double rectangleRight = rectangleLeft + rectangle.Width;
            double rectangleBottom = rectangleTop + rectangle.Height;

            // Проверка коллизии: если мяч находится внутри области ракетки
            return ballRight >= rectangleLeft && ballLeft <= rectangleRight &&
                   ballBottom >= rectangleTop && ballTop <= rectangleBottom;
        }

        // Метод для обновления движения мяча и проверки его коллизий
        private void Ball(object sender, EventArgs e)
        {
            // Обновляем положение мяча по X и Y
            Canvas.SetLeft(Shar, Canvas.GetLeft(Shar) + _ballXSpeed);
            Canvas.SetTop(Shar, Canvas.GetTop(Shar) + _ballYSpeed);

            // Столкновение мяча с верхней стеной
            if (Canvas.GetTop(Shar) <= 0)
            {
                _leftScore++; // Увеличиваем счет нижнего игрока
                LeftScoreText.Text = _leftScore.ToString(); // Обновляем текст счета
                _ballYSpeed = -_ballYSpeed; // Меняем направление мяча
            }
            // Столкновение мяча с нижней стеной
            else if (Canvas.GetTop(Shar) + Shar.Height >= GameCanvas.ActualHeight - BottomRectangle.Height)
            {
                _rightScore++; // Увеличиваем счет верхнего игрока
                RightScoreText.Text = _rightScore.ToString(); // Обновляем текст счета
                _ballYSpeed = -_ballYSpeed; // Меняем направление мяча
            }

            // Проверка коллизий с нижней ракеткой
            if (CheckCollisionBottom(BottomRectangle))
            {
                // Меняем направление мяча и ускоряем его после столкновения с нижней ракеткой
                _ballYSpeed = -Math.Abs(_ballYSpeed); // Устанавливаем отрицательное значение скорости Y
                _ballXSpeed *= 1.2;
                _ballYSpeed *= 1.2;
                PlayHitSound();
            }

            // Проверка коллизий с верхней ракеткой
            if (CheckCollisionTOP(TopRectangle))
            {
                // Меняем направление мяча и ускоряем его после столкновения с верхней ракеткой
                _ballYSpeed = Math.Abs(_ballYSpeed); // Устанавливаем положительное значение скорости Y
                _ballXSpeed *= 1.2;
                _ballYSpeed *= 1.2;
                PlayHitSound();
            }

            // Проверка выхода мяча за границы слева
            if (Canvas.GetLeft(Shar) <= 0)
            {
                _ballXSpeed = -_ballXSpeed;
            }
            // Проверка выхода мяча за границы справа
            else if (Canvas.GetLeft(Shar) + Shar.Width >= GameCanvas.ActualWidth)
            {
                _ballXSpeed = -_ballXSpeed;
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
            _gameTimer.Start();
            Menu.Visibility = Visibility.Hidden;
        }
    }
}

