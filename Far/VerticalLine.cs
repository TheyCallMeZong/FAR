namespace Far
{
    /// <summary>
    /// Отрисовка вертикальных линий
    /// </summary>
    public class VerticalLine
    {
        /// <summary>
        /// Точка на консоли и символ для закраски
        /// </summary>
        private Point point;

        /// <summary>
        /// Отрисовка линии
        /// </summary>
        /// <param name="ystart">начальная коорината по y</param>
        /// <param name="yfinish">конечная координата по x</param>
        /// <param name="x">уровен на котором будет отрисована линия</param>
        /// <param name="symbol">символ, который нужно отрисовать</param>
        public void DrawLine(int ystart, int yfinish, int x, char symbol)
        {
            for (int i = ystart; i < yfinish; i++)
            {
                point = new Point(x, i, symbol);
                point.Draw();
            }
        }
    }
}