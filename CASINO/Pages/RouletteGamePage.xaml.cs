using CASINO.Classes;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CASINO.Pages
{
    /// <summary>
    /// Логика взаимодействия для RouletteGamePage.xaml
    /// </summary>
    public partial class RouletteGamePage : Page
    {
        private double _currentAngle = 0;
        private readonly double[] _prizes = { 100, 200, 300, 400, 500, 600, 700, 800 };
        private double _balance = 0;
        private DispatcherTimer _timer;
        private double _spinSpeed = 0;
        private double _targetAngle = 0;
        private bool _isSpinning = false; // Контроль вращения
        private bool _isUsed = false;

        public RouletteGamePage()
        {
            InitializeComponent();
            DrawWheel();
            _timer = new DispatcherTimer(); // Инициализируем таймер один раз
            _timer.Interval = TimeSpan.FromMilliseconds(20);
            _timer.Tick += RotateWheel;
        }

        // Метод для рисования колеса с секторами
        private void DrawWheel()
        {
            double angleStep = 360.0 / _prizes.Length;
            for (int i = 0; i < _prizes.Length; i++)
            {
                // Создаем сегменты колеса
                PathFigure segment = new PathFigure
                {
                    StartPoint = new Point(150, 150) // Центр колеса
                };

                // Первая линия от центра к краю колеса
                LineSegment line1 = new LineSegment(
                    new Point(150 + 150 * Math.Cos(Math.PI * i * angleStep / 180),
                              150 + 150 * Math.Sin(Math.PI * i * angleStep / 180)),
                    true);

                // Дуга по кругу колеса
                ArcSegment arc = new ArcSegment(
                    new Point(150 + 150 * Math.Cos(Math.PI * (i + 1) * angleStep / 180),
                              150 + 150 * Math.Sin(Math.PI * (i + 1) * angleStep / 180)),
                    new Size(150, 150), 0, false, SweepDirection.Clockwise, true);

                // Вторая линия от края колеса обратно к центру
                segment.Segments.Add(line1);
                segment.Segments.Add(arc);

                PathGeometry geometry = new PathGeometry(new[] { segment });
                Path path = new Path
                {
                    Fill = i % 2 == 0 ? Brushes.LightBlue : Brushes.LightGreen,
                    Data = geometry
                };

                wheelCanvas.Children.Add(path);

                // Добавляем текст с призами
                AddPrizeText(i, angleStep);
            }
        }

        // Метод для добавления текста с призами на колесо
        private void AddPrizeText(int index, double angleStep)
        {
            double angle = (index + 0.5) * angleStep; // Считаем угол для текста в центре сектора
            double radius = 100; // Радиус, на котором будет расположен текст

            // Координаты для текста с призом
            double x = 150 + radius * Math.Cos(Math.PI * angle / 180);
            double y = 150 + radius * Math.Sin(Math.PI * angle / 180);

            // Создаем текстовый блок для отображения приза
            TextBlock prizeText = new TextBlock
            {
                Text = _prizes[index].ToString(),
                FontSize = 16,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.Black
            };

            // Устанавливаем положение текста относительно колеса
            Canvas.SetLeft(prizeText, x - 15); // Смещаем текст, чтобы он был в центре относительно точки
            Canvas.SetTop(prizeText, y - 10);  // Немного корректируем Y для лучшего расположения

            // Добавляем текстовый блок на холст
            wheelCanvas.Children.Add(prizeText);
        }

        // Метод для запуска вращения колеса
        private void SpinWheel(object sender, RoutedEventArgs e)
        {
            if (_isUsed)
            {
                CustomMessageBox successMessage = new CustomMessageBox("На сегодня все!\nВозвращайтесь завтра!");
                successMessage.ShowDialog();
                return;
            }
                

            if (!_isSpinning) // Проверяем, что колесо не вращается в данный момент
            {
                _isUsed = true;
                _isSpinning = true;
                Random rand = new Random();
                _targetAngle = rand.Next(360, 720); // Целевая точка для остановки колеса
                _spinSpeed = 10;
                _timer.Start(); // Запускаем таймер
            }
        }

        // Метод вращения колеса
        private void RotateWheel(object sender, EventArgs e)
        {
            _currentAngle += _spinSpeed;
            if (_currentAngle >= _targetAngle)
            {
                _currentAngle = _targetAngle % 360; // Ограничиваем углы до 360°
                _timer.Stop();
                CalculatePrize(); // Приз рассчитывается только после остановки колеса
                _isSpinning = false; // Сбрасываем флаг после завершения вращения
            }

            wheelCanvas.RenderTransform = new RotateTransform(_currentAngle, 150, 150);  // Вращаем колесо относительно его центра
            _spinSpeed *= 0.98; // Постепенное замедление
        }

        // Метод расчета приза
        private void CalculatePrize()
        {
            double angleStep = 360.0 / _prizes.Length;
            // Рассчитываем сектор на основе текущего угла
            int index = (int)((_currentAngle % 360) / angleStep);
            _balance += _prizes[index];  // Добавляем выигрыш на баланс
            balanceText.Text = $"Баланс: {_balance}";  // Обновляем текст баланса
            MessageBox.Show($"Вы выиграли {_prizes[index]}!");
        }

    }
}
