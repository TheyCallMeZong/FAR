namespace Far.Command
{
    /// <summary>
    /// Удаление папок и файлов
    /// </summary>
    public class Delete : ICommand<ConsoleKeyInfo>
    {
        public bool CanExecute(ConsoleKeyInfo item)
        {
            return item.Key == ConsoleKey.F8;
        }

        public bool Execute()
        {
            View view = View.GetInstance();
            FormWithMessage.Show(view.ConsoleWidht, view.ConsoleHeight);
            if (view.FilePanel == FilePanel.Left)
            {
                FormWithMessage.ShowYN(view.ConsoleWidht, view.ConsoleHeight, $"Do you want to delete {view.FilesAndDirectoriesOnLeftPanel[view.CursorOffsetOnLeftPanel - 4].Name}?");
                var click = Console.ReadKey();
                if (click.Key == ConsoleKey.Y)
                {
                    if (File.Exists(view.PathOnLeftPanel + "\\" + view.FilesAndDirectoriesOnLeftPanel[view.CursorOffsetOnLeftPanel - 4].Name))
                    {
                        File.Delete(view.PathOnLeftPanel + "\\" + view.FilesAndDirectoriesOnLeftPanel[view.CursorOffsetOnLeftPanel - 4].Name);
                    }
                    else
                    {
                        Directory.Delete(view.PathOnLeftPanel + "\\" + view.FilesAndDirectoriesOnLeftPanel[view.CursorOffsetOnLeftPanel - 4].Name, true);
                    }
                }
            }
            else
            {
                FormWithMessage.ShowYN(view.ConsoleWidht, view.ConsoleHeight, $"Do you want to delete {view.FilesAndDirectoriesOnRightPanel[view.CursorOffsetOnRightPanel - 4].Name}?");
                var click = Console.ReadKey();
                if (click.Key == ConsoleKey.Y)
                {
                    if (File.Exists(view.PathOnRightPanel + "\\" + view.FilesAndDirectoriesOnRightPanel[view.CursorOffsetOnRightPanel - 4].Name))
                    {
                        File.Delete(view.PathOnRightPanel + "\\" + view.FilesAndDirectoriesOnRightPanel[view.CursorOffsetOnRightPanel - 4].Name);
                    }
                    else
                    {
                        Directory.Delete(view.PathOnRightPanel + "\\" + view.FilesAndDirectoriesOnRightPanel[view.CursorOffsetOnRightPanel - 4].Name, true);
                    }
                }
            }
            Window.HideMessage();
            return false;
        }
    }
}
