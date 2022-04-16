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
            try
            {
                if (view.FilePanel == FilePanel.Left)
                {
                    FormWithMessage.ShowYN(view.ConsoleWidht, view.ConsoleHeight, $"Do you want to delete {view.FilesAndDirectoriesOnLeftPanel[view.AbsolutleCursorOffseOnLeftPanel].Name}?");
                    var click = Console.ReadKey();
                    if (click.Key == ConsoleKey.Y)
                    {
                        if (File.Exists(view.PathOnLeftPanel + "\\" + view.FilesAndDirectoriesOnLeftPanel[view.AbsolutleCursorOffseOnLeftPanel].Name))
                        {
                            File.Delete(view.PathOnLeftPanel + "\\" + view.FilesAndDirectoriesOnLeftPanel[view.AbsolutleCursorOffseOnLeftPanel].Name);
                        }
                        else
                        {
                            Directory.Delete(view.PathOnLeftPanel + "\\" + view.FilesAndDirectoriesOnLeftPanel[view.AbsolutleCursorOffseOnLeftPanel].Name, true);
                        }
                    }
                }
                else
                {
                    FormWithMessage.ShowYN(view.ConsoleWidht, view.ConsoleHeight, $"Do you want to delete {view.FilesAndDirectoriesOnRightPanel[view.AbsolutleCursorOffseOnRightPanel].Name}?");
                    var click = Console.ReadKey();
                    if (click.Key == ConsoleKey.Y)
                    {
                        if (File.Exists(view.PathOnRightPanel + "\\" + view.FilesAndDirectoriesOnRightPanel[view.AbsolutleCursorOffseOnRightPanel].Name))
                        {
                            File.Delete(view.PathOnRightPanel + "\\" + view.FilesAndDirectoriesOnRightPanel[view.AbsolutleCursorOffseOnRightPanel].Name);
                        }
                        else
                        {
                            Directory.Delete(view.PathOnRightPanel + "\\" + view.FilesAndDirectoriesOnRightPanel[view.AbsolutleCursorOffseOnRightPanel].Name, true);
                        }
                    }
                }
            }
            catch
            {

            }
            finally
            {
                Window.HideMessage();
            }
            return false;
        }
    }
}
