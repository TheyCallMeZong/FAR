namespace Far
{
    public class HorizontalLine
    {
        /// <summary>
        /// Точка для отрисовки
        /// </summary>
        private Point point;


        /// <summary>
        /// Отрисовка линии
        /// </summary>
        /// <param name="xstart">начальная коорината по х</param>
        /// <param name="xfinish">конечная координата по x</param>
        /// <param name="y">уровен на котором будет отрисована линия</param>
        /// <param name="symbol">символ, который нужно отрисовать</param>
        public void DrawLine(int xstart, int xfinish, int y, char symbol)
        {
            for (int i = xstart; i < xfinish; i++)
            {
                point = new Point(i, y, symbol);
                point.Draw();
            }
        }
    }

}