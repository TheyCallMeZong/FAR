namespace Far.Command
{
    /// <summary>
    /// удаление с переносом
    /// </summary>
    public class RenMove : ICommand<ConsoleKeyInfo>
    {
        public bool CanExecute(ConsoleKeyInfo item)
        {
            return item.Key == ConsoleKey.F6;
        }

        public bool Execute()
        {
            View view = View.GetInstance();
            try
            {
                if (view.FilePanel == FilePanel.Left)
                {
                    if (File.Exists(view.PathOnLeftPanel + "\\" + view.FilesAndDirectoriesOnLeftPanel[view.AbsolutleCursorOffseOnLeftPanel].Name))
                    {
                        if (File.Exists(view.PathOnRightPanel + "\\" + view.FilesAndDirectoriesOnLeftPanel[view.AbsolutleCursorOffseOnLeftPanel].Name))
                        {
                            FormWithMessage.Show(view.ConsoleWidht, view.ConsoleHeight);
                            FormWithMessage.ShowYN(view.ConsoleWidht, view.ConsoleHeight, "The file exists. Do you want to replace it?");
                            var click = Console.ReadKey();
                            if (click.Key == ConsoleKey.Y)
                            {
                                File.Delete(view.PathOnRightPanel + "\\" + view.FilesAndDirectoriesOnLeftPanel[view.AbsolutleCursorOffseOnLeftPanel].Name);                                
                            }
                        }
                        File.Move(view.PathOnLeftPanel + "\\" + view.FilesAndDirectoriesOnLeftPanel[view.AbsolutleCursorOffseOnLeftPanel].Name, view.PathOnRightPanel + "\\" + view.FilesAndDirectoriesOnLeftPanel[view.AbsolutleCursorOffseOnLeftPanel].Name);
                    }
                    else
                    {
                        Directory.Move(view.PathOnLeftPanel + "\\" + view.FilesAndDirectoriesOnLeftPanel[view.AbsolutleCursorOffseOnLeftPanel].Name, view.PathOnRightPanel + "\\" + view.FilesAndDirectoriesOnLeftPanel[view.AbsolutleCursorOffseOnLeftPanel].Name);
                    }
                }
                else
                {
                    if (File.Exists(view.PathOnRightPanel + "\\" + view.FilesAndDirectoriesOnRightPanel[view.AbsolutleCursorOffseOnRightPanel].Name))
                    {
                        if (File.Exists(view.PathOnLeftPanel + "\\" + view.FilesAndDirectoriesOnRightPanel[view.AbsolutleCursorOffseOnRightPanel].Name))
                        {
                            FormWithMessage.Show(view.ConsoleWidht, view.ConsoleHeight);
                            FormWithMessage.ShowYN(view.ConsoleWidht, view.ConsoleHeight, "The file exists. Do you want to replace it?");
                            var click = Console.ReadKey();
                            if (click.Key == ConsoleKey.Y)
                            {
                                File.Delete(view.PathOnLeftPanel + "\\" + view.FilesAndDirectoriesOnRightPanel[view.AbsolutleCursorOffseOnRightPanel].Name);
                            }
                        }
                        File.Move(view.PathOnRightPanel + "\\" + view.FilesAndDirectoriesOnRightPanel[view.AbsolutleCursorOffseOnRightPanel].Name, view.PathOnLeftPanel + "\\" + view.FilesAndDirectoriesOnRightPanel[view.AbsolutleCursorOffseOnRightPanel].Name);
                    }
                    else
                    {
                        Directory.Move(view.PathOnRightPanel + "\\" + view.FilesAndDirectoriesOnRightPanel[view.AbsolutleCursorOffseOnRightPanel].Name, view.PathOnLeftPanel + "\\" + view.FilesAndDirectoriesOnRightPanel[view.AbsolutleCursorOffseOnRightPanel].Name);
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
