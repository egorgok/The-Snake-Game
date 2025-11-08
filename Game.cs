using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TheSnakeGame
{
    public partial class Game : Form
    {
        private char currentDirection = 'd';
        private char nextDirection = 'd';
        private Timer movementTimer;
        private int baseSpeed = 150;
        private int speedIncreaseInterval = 5; 
        private int minSpeed = 50; 
        private Random rnd = new Random();

        private List<Point> snakeSegments = new List<Point>();
        private List<PictureBox> bodySegments = new List<PictureBox>();
        private const int SegmentSize = 10;
        private int score = 0;

        public Game()
        {
            InitializeComponent();

            // Инициализация змейки с 3 сегментами
            for (int i = 0; i < 3; i++)
            {
                snakeSegments.Add(new Point(100 - i * SegmentSize, 100));
            }

            // Настройка обработки клавиш
            this.KeyPreview = true;
            this.KeyDown += ChangeDirection;
            this.DoubleBuffered = true;

            // Настройка таймера
            movementTimer = new Timer();
            movementTimer.Interval = 100; // Увеличиваем интервал для стабильности
            movementTimer.Tick += Move;
            movementTimer.Start();

            // Инициализируем голову
            bodySegments.Add(body1);
            body1.Size = new Size(SegmentSize, SegmentSize);
            body1.Location = snakeSegments[0];

            // Создаем начальные визуальные сегменты
            CreateInitialSegments();

            // Спавним яблоки
            SpawnApple1();
            SpawnApple2();
        }

        private void CreateInitialSegments()
        {
            // Создаем сегменты начиная с индекса 1 (голова уже есть)
            for (int i = 1; i < snakeSegments.Count; i++)
            {
                AddVisualSegment(i);
            }
        }

        private void ChangeDirection(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W && currentDirection != 's') nextDirection = 'w';
            else if (e.KeyCode == Keys.S && currentDirection != 'w') nextDirection = 's';
            else if (e.KeyCode == Keys.A && currentDirection != 'd') nextDirection = 'a';
            else if (e.KeyCode == Keys.D && currentDirection != 'a') nextDirection = 'd';
        }

        private void Move(object sender, EventArgs e)
        {
            currentDirection = nextDirection;

            // Вычисляем новую позицию головы
            Point newHead = GetNewHeadPosition();

            // Проверяем столкновение с собой
            if (CheckSelfCollision(newHead))
            {
                GameOver();
                return;
            }

            // Проверяем столкновение с яблоками
            bool ateApple = CheckAppleCollision(newHead);

            // Обновляем позиции сегментов
            UpdateSnakePosition(newHead, ateApple);

            // Обновляем визуальное представление
            UpdateVisualSegments();

            // Проверяем столкновение с границами
            CheckBoundaries();

            // Скорость
            UpdateGameSpeed();
        }

        private Point GetNewHeadPosition()
        {
            Point head = snakeSegments[0];
            switch (currentDirection)
            {
                case 'w': return new Point(head.X, head.Y - SegmentSize);
                case 's': return new Point(head.X, head.Y + SegmentSize);
                case 'a': return new Point(head.X - SegmentSize, head.Y);
                case 'd': return new Point(head.X + SegmentSize, head.Y);
                default: return head;
            }
        }

        private bool CheckSelfCollision(Point newHead)
        {
            // Проверяем столкновение головы с телом (начиная с 4 сегмента)
            for (int i = 4; i < snakeSegments.Count; i++)
            {
                if (newHead == snakeSegments[i])
                    return true;
            }
            return false;
        }

        private bool CheckAppleCollision(Point newHead)
        {
            Rectangle headBounds = new Rectangle(newHead, new Size(SegmentSize, SegmentSize));

            if (headBounds.IntersectsWith(apple1.Bounds))
            {
                SpawnApple(apple1);
                score++;
                return true;
            }
            if (headBounds.IntersectsWith(apple2.Bounds))
            {
                SpawnApple(apple2);
                score++;
                return true;
            }
            return false;
        }

        private void UpdateSnakePosition(Point newHead, bool ateApple)
        {
            // Добавляем новую голову
            snakeSegments.Insert(0, newHead);

            // Если не съели яблоко - удаляем хвост
            if (!ateApple)
            {
                snakeSegments.RemoveAt(snakeSegments.Count - 1);
            }
        }

        private void UpdateVisualSegments()
        {
            // Обновляем голову
            body1.Location = snakeSegments[0];

            // Синхронизируем количество визуальных сегментов с логическими
            while (bodySegments.Count < snakeSegments.Count)
            {
                AddVisualSegment(bodySegments.Count);
            }

            while (bodySegments.Count > snakeSegments.Count)
            {
                RemoveLastSegment();
            }

            // Обновляем позиции сегментов
            for (int i = 1; i < snakeSegments.Count; i++)
            {
                bodySegments[i].Location = snakeSegments[i];
            }

            this.Text = $"Snake Game - Score: {score} - Length: {snakeSegments.Count}";
        }

        private void AddVisualSegment(int index)
        {
            PictureBox segment = new PictureBox();
            segment.Size = new Size(SegmentSize, SegmentSize);
            segment.BackColor = (index % 2 == 0) ? Color.Green : Color.LightGreen; // Чередуем цвета для красоты
            segment.Location = snakeSegments[index];

            this.Controls.Add(segment);
            segment.BringToFront();
            bodySegments.Add(segment);

            // Убедимся, что яблоки поверх змейки
            apple1.BringToFront();
            apple2.BringToFront();
        }
        private void RestartGame()
        {
            // Останавливаем таймер
            movementTimer.Stop();

            // Очищаем сегменты змейки (кроме головы)
            for (int i = bodySegments.Count - 1; i >= 1; i--)
            {
                var segment = bodySegments[i];
                bodySegments.RemoveAt(i);
                this.Controls.Remove(segment);
                segment.Dispose();
            }

            // Сбрасываем переменные
            snakeSegments.Clear();
            currentDirection = 'd';
            nextDirection = 'd';
            score = 0;

            // Восстанавливаем начальную змейку
            for (int i = 0; i < 3; i++)
            {
                snakeSegments.Add(new Point(100 - i * SegmentSize, 100));
            }

            // Обновляем голову
            body1.Location = snakeSegments[0];

            // Создаем остальные сегменты
            for (int i = 1; i < snakeSegments.Count; i++)
            {
                AddVisualSegment(i);
            }

            // Переспавниваем яблоки
            SpawnApple1();
            SpawnApple2();

            // Сбрасываем скорость
            movementTimer.Interval = baseSpeed;

            // Запускаем игру заново
            movementTimer.Start();

            this.Text = $"Snake Game - Score: {score}";
        }
        private void RemoveLastSegment()
        {
            if (bodySegments.Count > 1) // Не удаляем голову
            {
                var lastSegment = bodySegments[bodySegments.Count - 1];
                bodySegments.RemoveAt(bodySegments.Count - 1);
                this.Controls.Remove(lastSegment);
                lastSegment.Dispose();
            }
        }

        private void CheckBoundaries()
        {
            if (body1.Left < 0 || body1.Right > this.ClientSize.Width ||
            body1.Top < 0 || body1.Bottom > this.ClientSize.Height)
            {
                GameOver();
            }
        }
        private void UpdateGameSpeed()
        {
            int newSpeed = baseSpeed - (score / speedIncreaseInterval) * 10;
            newSpeed = Math.Max(newSpeed, minSpeed); // Не даем скорости стать меньше минимума

            if (movementTimer.Interval != newSpeed)
            {
                movementTimer.Interval = newSpeed;
                Console.WriteLine($"Speed updated: {newSpeed}ms");
            }
        }
        private void GameOver()
        {
            movementTimer.Stop();
            MessageBox.Show($"Конец! Счёт: {score}\nДлинна змеи: {snakeSegments.Count}", "Game Over");
            var result = MessageBox.Show($"Конец! Счёт: {score}\nДлинна змеи: {snakeSegments.Count}", "Game Over",MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                RestartGame();
            }
            else
            {
                this.Close();
            }
        }

        private void SpawnApple1()
        {
            SpawnApple(apple1);
        }

        private void SpawnApple2()
        {
            SpawnApple(apple2);
        }

        private void SpawnApple(PictureBox apple)
        {
            int maxX = (this.ClientSize.Width - apple.Width) / 5;
            int maxY = (this.ClientSize.Height - apple.Height) / 5;

            int x = rnd.Next(0, Math.Max(1, maxX)) * 5;
            int y = rnd.Next(0, Math.Max(1, maxY)) * 5;

            // Проверяем, чтобы яблоко не появилось на змейке
            Point applePos = new Point(x, y);
            while (snakeSegments.Contains(applePos))
            {
                x = rnd.Next(0, Math.Max(1, maxX)) * 5;
                y = rnd.Next(0, Math.Max(1, maxY)) * 5;
                applePos = new Point(x, y);
            }

            apple.Location = applePos;
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            movementTimer?.Stop();
            movementTimer?.Dispose();
            base.OnFormClosed(e);
        }
    }
}







// private void OnFormClosed(object sender, FormClosedEventArgs e)
/*using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheSnakeGame
{
    public partial class Game : Form
    {
        private Timer movementTimer;
        private List<PictureBox> snakeBody = new List<PictureBox>();
        private int segmentSize = 10;
        private int score = 0;
        private char currentDirection = 'w';
        private char nextDirection = 'w';
        private int speedms = 300; // Настройка скорости
        private Random rnd;
        private int xa;
        private int ya;
        
        public Game()
        {

            InitializeComponent();

            rnd = new Random();
            snakeBody.Add(body1);

            // Настройка обработки клавиш
            this.KeyPreview = true;
            this.KeyDown += ChangeDirection;

            // Настройка таймера для постоянного движения
            movementTimer = new Timer();
            movementTimer.Interval = speedms; // Скорость движения (можно настроить)
            movementTimer.Tick += Move;
            movementTimer.Start();

            SpawnApple1();
            SpawnApple2();
        }
        char mv = 'w';
        private void ChangeDirection(object sender, KeyEventArgs e)
        {
            // Запоминаем следующее направление (применяется в следующем тике таймера)
            if (e.KeyCode == Keys.W && currentDirection != 's')
            {
                nextDirection = 'w';
            }
            else if (e.KeyCode == Keys.S && currentDirection != 'w')
            {
                nextDirection = 's';
            }
            else if (e.KeyCode == Keys.A && currentDirection != 'd')
            {
                nextDirection = 'a';
            }
            else if (e.KeyCode == Keys.D && currentDirection != 'a')
            {
                nextDirection = 'd';
            }
        }
        private void Move(object sender, EventArgs e)
        {

            
            CheckBoundaries();
            movementTimer.Interval = speedms - score * 2;

            List <Point> previousPositions = new List<Point>();
            foreach (var segment in snakeBody)
            {
                previousPositions.Add(segment.Location);
            }
            currentDirection = nextDirection;
            Point newHeadPosition = GetNewHeadPosition();
            bool ateApple = false;
            // Двигаем объект в текущем направлении
            switch (currentDirection)
            {
                case 'w': // Вверх
                    body1.Location = new Point(body1.Left, body1.Top - 10);
                    break;
                case 's': // Вниз
                    body1.Location = new Point(body1.Left, body1.Top + 10);
                    break;
                case 'a': // Влево
                    body1.Location = new Point(body1.Left - 10, body1.Top);
                    break;
                case 'd': // Вправо
                    body1.Location = new Point(body1.Left + 10, body1.Top);
                    break;
            }
            if (body1.Bounds.IntersectsWith(apple1.Bounds))
            {
                SpawnApple1();
                ateApple = true;
                score++;
            }
            if (body1.Bounds.IntersectsWith(apple2.Bounds))
            {
                SpawnApple2();
                ateApple = true;
                score++;
            }
            body1.Location = newHeadPosition;

            // Двигаем остальные сегменты
            for (int i = 1; i < snakeBody.Count; i++)
            {
                snakeBody[i].Location = previousPositions[i - 1];
            }

            // Если съели яблоко - добавляем новый сегмент
            if (ateApple)
            {
                AddSegment();
            }
            Console.WriteLine($"Score: {score} | Segments: {snakeBody.Count}");
            Console.WriteLine($"Position: {body1.Left}, {body1.Top} | Direction: {currentDirection}");
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            movementTimer?.Stop();
            base.OnFormClosed(e);
        }

        private void SpawnApple1()
        {
            // Учитываем размер формы для спавна яблок
            int maxX = 98;
            int maxY = 98;

            xa = rnd.Next(0, Math.Max(2, maxX)) * 5;
            ya = rnd.Next(0, Math.Max(2, maxY)) * 5;
            apple1.Location = new Point(xa, ya);

            Console.WriteLine($"Apple1 spawned at: {xa}, {ya}");
        }
        private void SpawnApple2()
        {
            int maxX = 98;
            int maxY = 98;

            xa = rnd.Next(0, Math.Max(2, maxX)) * 5;
            ya = rnd.Next(0, Math.Max(2, maxY)) * 5;
            apple2.Location = new Point(xa, ya);

            Console.WriteLine($"Apple2 spawned at: {xa}, {ya}");
        }
        private void CheckBoundaries()
        {
            
            if (body1.Left < 0 || body1.Right > this.ClientSize.Width ||
            body1.Top < 0 || body1.Bottom > this.ClientSize.Height)
            {
                movementTimer.Stop();
                MessageBox.Show("Ты ударился =(");
                Start start = new Start();
                start.Show();
                this.Close();
            }
        }
        private Point GetNewHeadPosition()
        {
            Point newPosition = body1.Location;
            switch (currentDirection)
            {
                case 'w': newPosition.Y -= segmentSize; break;
                case 's': newPosition.Y += segmentSize; break;
                case 'a': newPosition.X -= segmentSize; break;
                case 'd': newPosition.X += segmentSize; break;
            }
            return newPosition;
        }
        private void AddSegment()
        {
            PictureBox newSegment = new PictureBox();
            newSegment.Size = new Size(segmentSize, segmentSize);
            newSegment.Image = Image.FromFile("C:\\Users\\egorgok\\source\\repos\\TheSnakeGame\\TheSnakeGame\\images\\game\\body.png"); // или любой другой цвет
            newSegment.Location = snakeBody[snakeBody.Count - 1].Location; // Позиция последнего сегмента

            this.Controls.Add(newSegment);
            snakeBody.Add(newSegment);
            newSegment.BringToFront();
        }
    }

}
*/ // OLD VERSION