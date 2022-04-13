namespace Far
{
    /// <summary>
    /// Смена панелей
    /// </summary>
    public class ChangePanel : ICommand<ConsoleKeyInfo>
    {
        public bool CanExecute(ConsoleKeyInfo item)
        {
            return item.Key == ConsoleKey.Tab;
        }

        public bool Execute()
        {
            View view = View.GetInstance();
            if (view.FilePanel == FilePanel.Left)
            {
                view.FilePanel = FilePanel.Right;
                
                if (view.FilesAndDirectoriesOnRightPanel.Count == 0 && view.DriversOnRightPanel.Count > 0)
                {
                    var disk = view.DriversOnRightPanel[view.CursorOffsetOnRightPanel - 3].Name;
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(view.ConsoleWidht / 2 + 1, view.CursorOffsetOnRightPanel);
                    Console.WriteLine(disk);
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                else if (view.FilesAndDirectoriesOnRightPanel.Count > 0)
                {
                    if (view.CursorOffsetOnRightPanel == 3)
                    {
                        view.CursorOffsetOnRightPanel++;
                    }
                    var file = view.FilesAndDirectoriesOnRightPanel[view.CursorOffsetOnRightPanel - 4].Name;
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(view.ConsoleWidht / 2 + 1, view.CursorOffsetOnRightPanel);
                    Console.WriteLine(file);
                }
                else
                {
                    Console.SetCursorPosition(view.ConsoleWidht / 2 + 1, view.CursorOffsetOnRightPanel);
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("[..]");
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                if (view.FilesAndDirectoriesOnLeftPanel.Count == 0 && view.DriversOnLeftPanel.Count > 0)
                {
                    var disk = view.DriversOnLeftPanel[view.CursorOffsetOnLeftPanel - 3].Name;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.SetCursorPosition(1, view.CursorOffsetOnLeftPanel);
                    Console.WriteLine(disk);
                }
                else
                {
                    if (view.CursorOffsetOnLeftPanel == 3)
                    {
                        Console.SetCursorPosition(1, view.CursorOffsetOnLeftPanel);
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("[..]");
                        return false;
                    }
                    var item = view.FilesAndDirectoriesOnLeftPanel[view.CursorOffsetOnLeftPanel - 4].Name;
                    Console.SetCursorPosition(1, view.CursorOffsetOnLeftPanel);
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(item);
                }
                return false;
            }
            else
            {
                view.FilePanel = FilePanel.Left;

                if (view.FilesAndDirectoriesOnLeftPanel.Count == 0 && view.DriversOnLeftPanel.Count > 0)
                {
                    var disk = view.DriversOnLeftPanel[view.CursorOffsetOnLeftPanel - 3].Name;
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(1, view.CursorOffsetOnLeftPanel);
                    Console.WriteLine(disk);
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                else if (view.FilesAndDirectoriesOnLeftPanel.Count > 0)
                {
                    if (view.CursorOffsetOnLeftPanel == 3)
                    {
                        view.CursorOffsetOnLeftPanel++;
                    }
                    var file = view.FilesAndDirectoriesOnLeftPanel[view.CursorOffsetOnLeftPanel - 4].Name;
                    Console.SetCursorPosition(1, view.CursorOffsetOnLeftPanel);
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(file);
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                else
                {
                    Console.SetCursorPosition(1, view.CursorOffsetOnLeftPanel);
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("[..]");
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                if (view.FilesAndDirectoriesOnRightPanel.Count == 0 && view.DriversOnRightPanel.Count > 0)
                {
                    var disk = view.DriversOnRightPanel[view.CursorOffsetOnRightPanel - 3].Name;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.SetCursorPosition(view.ConsoleWidht / 2 + 1, view.CursorOffsetOnRightPanel);
                    Console.WriteLine(disk);
                }
                else
                {
                    if (view.CursorOffsetOnRightPanel == 3)
                    {
                        Console.SetCursorPosition(view.ConsoleWidht / 2 + 1, view.CursorOffsetOnRightPanel);
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("[..]");
                        return false;
                    }
                    var file = view.FilesAndDirectoriesOnRightPanel[view.CursorOffsetOnRightPanel - 4].Name;
                    Console.SetCursorPosition(view.ConsoleWidht / 2 + 1, view.CursorOffsetOnRightPanel);
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(file);
                }
                return false;
            }
        }
    }
}
