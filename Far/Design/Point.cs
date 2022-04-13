namespace Far
{
    /// <summary>
    /// Точка на консоли
    /// </summary>
    public class Point
    {
        /// <summary>
        /// Кордината по Х
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Кордината по у
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Символ для отрисовки
        /// </summary>
        public char Symbol { get; set; }

        /// <summary>
        /// Конструктор для инициализации координат и символа
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="symbol"></param>
        public Point(int x, int y, char symbol)
        {
            X = x;
            Y = y;
            Symbol = symbol;
        }

        /// <summary>
        /// Отрисовка по координатам
        /// </summary>
        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Symbol);
        }
    }

}
