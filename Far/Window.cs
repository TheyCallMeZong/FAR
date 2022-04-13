namespace Far
{
    public class Window
    {
        /// <summary>
        /// Открыта ли менюшка
        /// </summary>
        public static bool MessageIsOpen;

        /// <summary>
        /// Лист команд
        /// </summary>
        private List<ICommand<ConsoleKeyInfo>> commands = new List<ICommand<ConsoleKeyInfo>>()
            {
                new DownMove(),
                new UpMove(),
                new ChangePanel(),
                new Open(),
                new Quit(),
                new Help(),
                new CreateFile()
            };

        /// <summary>
        /// Точка выполнения программы
        /// </summary>
        public void Run()
        {
            bool quit = false;
            while (!quit)
            {
                var t = Console.ReadKey();
                if (MessageIsOpen)
                {
                    HideMessage();
                    MessageIsOpen = false;
                }
                foreach (var item in commands)
                {
                    if (item.CanExecute(t))
                    {
                        quit = item.Execute();
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Убрать окно сообщений
        /// </summary>
        public static void HideMessage()
        {
            View view = View.GetInstance();
            if (!MessageIsOpen)
            {
                return;
            }
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            if (view.DriversOnLeftPanel.Count == 0 && view.DriversOnRightPanel.Count == 0)
            {
                view.ShowFiles(new Panel(view.PathOnLeftPanel, FilePanel.Left));
                view.ShowFiles(new Panel(view.PathOnRightPanel, FilePanel.Right));
            }
            else if (view.DriversOnLeftPanel.Count == 0 && view.DriversOnRightPanel.Count != 0)
            {
                view.ShowFiles(new Panel(view.PathOnLeftPanel, FilePanel.Left));
                view.ShowDisk(FilePanel.Right);
            }
            else if (view.DriversOnLeftPanel.Count != 0 && view.DriversOnRightPanel.Count == 0)
            {
                view.ShowFiles(new Panel(view.PathOnRightPanel, FilePanel.Right));
                view.ShowDisk(FilePanel.Left);
            }
            else
            {
                view.ShowDisk(FilePanel.Right);
                view.ShowDisk(FilePanel.Left);
            }

            VerticalLine verticalLine = new VerticalLine();
            verticalLine.DrawLine(1, view.ConsoleHeight - 3, view.ConsoleWidht / 2, '|');
        }
    }
}