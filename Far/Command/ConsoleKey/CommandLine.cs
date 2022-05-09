namespace Far.Command
{
    /// <summary>
    /// открытие командной строки
    /// </summary>
    public class CommandLine : ICommand<ConsoleKeyInfo>
    {
        /// <summary>
        /// переменная с текстом об ошибках или успехаха
        /// </summary>
        public static string Text = "good";

        /// <summary>
        /// цвет
        /// </summary>
        public static ConsoleColor BackColor = ConsoleColor.Green;

        /// <summary>
        /// список команд
        /// </summary>
        private List<ICommand<string>> commands = new List<ICommand<string>>()
        {
            new Line.Help(),
            new Line.Exit(),
            new Line.Close(),
            new Line.CloseHelpMenu(),
            new Line.ChangeDirectory(),
            new Line.CreateDirectory(),
            new Line.SelectPanel(),
            new Line.CreateFile(),
            new Line.Delete(),
            new Line.Rename(),
            new Line.Open(),
            new Line.Copy(),
            new Line.Renmove()
        };

        /// <summary>
        /// открыта ли менюшка помощи
        /// </summary>
        public static bool HelpIsOpen = false;

        public bool CanExecute(ConsoleKeyInfo item)
        {
            return item.Key == ConsoleKey.F9;
        }

        public bool Execute()
        {
            View view;
            Console.CursorVisible = true;
            view = View.GetInstance();
            HideCursor(view);
            bool quit = false;
            string line = string.Empty;
            int count;
            while (!quit)
            {
                Console.SetCursorPosition(1, view.ConsoleHeight - 3);
                Console.Write(string.Concat(Enumerable.Repeat(' ', view.ConsoleWidht - 20)));
                Console.SetCursorPosition(1, view.ConsoleHeight - 3);
                Console.Write("~> ");
                line = Console.ReadLine();
                if (HelpIsOpen)
                {
                    new Clear(view.ConsoleWidht, view.ConsoleHeight);
                    HelpIsOpen = new Line.CloseHelpMenu().Execute();
                }
                count = 0;
                foreach (var item in commands)
                {
                    count++;
                    if (item.CanExecute(line))
                    {
                        quit = item.Execute();
                        if (!quit)
                        {
                            Console.SetCursorPosition(1, view.ConsoleHeight - 3);
                            Console.Write(string.Concat(Enumerable.Repeat(' ', view.ConsoleWidht - 1)));
                            Console.SetCursorPosition(view.ConsoleWidht - 19, view.ConsoleHeight - 3);
                            Console.BackgroundColor = BackColor;
                            Console.WriteLine(Text);
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                        }
                        break;
                    }
                    if (count == commands.Count)
                    {
                        Console.SetCursorPosition(view.ConsoleWidht - 19, view.ConsoleHeight - 3);
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("command not found");
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                    }
                }
            }

            if (line.ToLower() == "exit")
            {
                return true;
            }

            Console.CursorVisible = false;
            return false;
        }

        /// <summary>
        /// скрытие курсора
        /// </summary>
        /// <param name="view"></param>
        private void HideCursor(View view)
        {
            var panel = view.FilePanel;
            string element;
            if (panel == FilePanel.Left)
            {
                if (view.DriversOnLeftPanel.Count == 0)
                {
                    element = view.FilesAndDirectoriesOnLeftPanel[view.AbsolutleCursorOffseOnLeftPanel].Name;
                    Console.SetCursorPosition(1, view.CursorOffsetOnLeftPanel);
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(element);
                    view.ShowExt(panel);
                }
                else
                {
                    element = view.DriversOnLeftPanel[view.CursorOffsetOnLeftPanel - 3].Name;
                    Console.SetCursorPosition(1, view.CursorOffsetOnLeftPanel);
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(element);
                }
            }
            else
            {
                if (view.DriversOnRightPanel.Count == 0)
                {
                    element = view.FilesAndDirectoriesOnRightPanel[view.AbsolutleCursorOffseOnRightPanel].Name;
                    Console.SetCursorPosition(view.ConsoleWidht / 2 + 1, view.CursorOffsetOnRightPanel);
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(element);
                    view.ShowExt(panel);
                }
                else
                {
                    element = view.DriversOnRightPanel[view.CursorOffsetOnRightPanel - 3].Name;
                    Console.SetCursorPosition(view.ConsoleWidht / 2 + 1, view.CursorOffsetOnRightPanel);
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(element);
                }
            }
        }
    }
}
