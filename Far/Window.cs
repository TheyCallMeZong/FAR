using Far.Command;

namespace Far
{
    public class Window
    {
        /// <summary>
        /// открыта ли менюшка
        /// </summary>
        public static bool MenuIsOpen;

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
                new CreateFile(),
                new Rename(), 
                new Edit(),
                new RenMove(),
                new Copy(),
                new CreateDirectory(),
                new Delete(),
                new Tree()
            };

        /// <summary>
        /// Точка выполнения программы
        /// </summary>
        public void Run()
        {
            bool quit = false;
            while (!quit)
            {
                var t = Console.ReadKey(true);
                if (MenuIsOpen)
                {
                    MenuIsOpen = false;
                    HideMessage();
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
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            if (view.DriversOnLeftPanel.Count == 0 && view.DriversOnRightPanel.Count == 0)
            {
                view.AbsolutleCursorOffseOnRightPanel = view.PageInScrollingInRightPanel * (view.ConsoleHeight - 8);
                view.AbsolutleCursorOffseOnLeftPanel = view.PageInScrollingInLeftPanel * (view.ConsoleHeight - 8);
                view.ShowFiles(new Panel(view.PathOnLeftPanel, FilePanel.Left));
                view.ShowFiles(new Panel(view.PathOnRightPanel, FilePanel.Right));
            }
            else if (view.DriversOnLeftPanel.Count == 0 && view.DriversOnRightPanel.Count != 0)
            {
                view.ShowFiles(new Panel(view.PathOnLeftPanel, FilePanel.Left));
                view.AbsolutleCursorOffseOnLeftPanel = view.PageInScrollingInLeftPanel * (view.ConsoleHeight - 8);
                view.ShowDisk(FilePanel.Right);
            }
            else if (view.DriversOnLeftPanel.Count != 0 && view.DriversOnRightPanel.Count == 0)
            {
                view.AbsolutleCursorOffseOnRightPanel = view.PageInScrollingInRightPanel * (view.ConsoleHeight - 8);
                view.ShowFiles(new Panel(view.PathOnRightPanel, FilePanel.Right));
                view.ShowDisk(FilePanel.Left);
            }
            else
            {
                view.ShowDisk(FilePanel.Right);
                view.ShowDisk(FilePanel.Left);
            }
            view.SetStartCursor(view.FilePanel);
            VerticalLine verticalLine = new VerticalLine();
            verticalLine.DrawLine(1, view.ConsoleHeight - 3, view.ConsoleWidht / 2, '|');
        }
    }
}