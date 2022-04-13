namespace Far.Command
{
    /// <summary>
    /// копирование файла с одной панели на другую
    /// </summary>
    public class Copy : ICommand<ConsoleKeyInfo>
    {
        public bool CanExecute(ConsoleKeyInfo item)
        {
            return item.Key == ConsoleKey.F5;
        }

        public bool Execute()
        {
            View view = View.GetInstance();
            try
            {
                if (view.FilePanel == FilePanel.Left)
                {
                    if (File.Exists(view.PathOnLeftPanel + "\\" + view.FilesAndDirectoriesOnLeftPanel[view.CursorOffsetOnLeftPanel - 4].Name))
                    {
                        File.Move(view.PathOnLeftPanel + "\\" + view.FilesAndDirectoriesOnLeftPanel[view.CursorOffsetOnLeftPanel - 4].Name, view.PathOnRightPanel + "\\" + view.FilesAndDirectoriesOnLeftPanel[view.CursorOffsetOnLeftPanel - 4].Name);
                    }
                }
                else
                {
                    if (File.Exists(view.PathOnRightPanel + "\\" + view.FilesAndDirectoriesOnRightPanel[view.CursorOffsetOnRightPanel - 4].Name))
                    {
                        File.Move(view.PathOnRightPanel + "\\" + view.FilesAndDirectoriesOnRightPanel[view.CursorOffsetOnRightPanel - 4].Name, view.PathOnLeftPanel + "\\" + view.FilesAndDirectoriesOnRightPanel[view.CursorOffsetOnRightPanel - 4].Name);
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
