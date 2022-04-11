namespace Far
{
    public class Clear
    {
        /// <summary>
        /// Ширина консоли
        /// </summary>
        private int consoleWidht;

        /// <summary>
        /// Высота консоли
        /// </summary>
        private int consoleHidht;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="widh"></param>
        /// <param name="heid"></param>
        public Clear(int widh, int hid)
        {
            consoleWidht = widh;
            consoleHidht = hid;
        }

        /// <summary>
        /// очистка панели
        /// </summary>
        /// <param name="panel"></param>
        public void ClearPanel(FilePanel panel)
        {
            if (panel == FilePanel.Left)
            {
                Console.SetCursorPosition(1, 1);
                Console.Write(string.Concat(Enumerable.Repeat(' ', consoleWidht / 2 - 1)));
                for (int i = 3; i < consoleHidht - 4; i++)
                {
                    Console.SetCursorPosition(1, i);
                    Console.Write(string.Concat(Enumerable.Repeat(' ', consoleWidht / 2 - 1)));
                }
            }
            else
            {
                Console.SetCursorPosition(consoleWidht / 2 + 1, 1);
                Console.Write(string.Concat(Enumerable.Repeat(' ', consoleWidht / 2 - 2)));
                for (int i = 3; i < consoleHidht - 4; i++)
                {
                    Console.SetCursorPosition(consoleWidht / 2 + 1, i);
                    Console.Write(string.Concat(Enumerable.Repeat(' ', consoleWidht / 2 - 2)));
                }
            }
        }
    }
}
