namespace Far.Command.Line
{
    /// <summary>
    /// смена директории
    /// </summary>
    public class ChangeDirectory : ICommand<string>
    {
        /// <summary>
        /// массив содержащий команду и путь
        /// </summary>
        private string[] text;
        public bool CanExecute(string item)
        {
            text = item.Split(' ');
            return text[0].ToLower() == "cd" && text.Length == 2 && (text[1].ToLower() == ".." || !string.IsNullOrEmpty(text[1]));
        }

        public bool Execute()
        {
            View view = View.GetInstance();
            string path = string.Empty;
            if (view.FilePanel == FilePanel.Left)
            {
                if (text[1] == "..")
                {
                    if (Directory.Exists(Directory.GetParent(view.PathOnLeftPanel)?.FullName))
                    {
                        path = Directory.GetParent(view.PathOnLeftPanel).FullName;
                    }
                    else
                    {
                        view.ShowDisk(FilePanel.Left);
                        return false;
                    }
                }
                else if (DriveInfo.GetDrives().FirstOrDefault(x => x.Name.ToLower() == text[1].Replace("\\", "").ToLower() + "\\") != null)
                {
                    path = text[1].Replace("\\", "") + "\\";
                }
                else
                {
                    path = view.PathOnLeftPanel + "\\" + text[1];
                }
                if (Directory.Exists(path))
                {
                    new Clear(view.ConsoleWidht, view.ConsoleHeight).ClearPanel(view.FilePanel);
                    view.PageInScrollingInLeftPanel = 0;
                    view.ShowFiles(new Panel(path, FilePanel.Left));
                }
            }
            else
            {
                if (text[1] == "..")
                {
                    if (Directory.Exists(Directory.GetParent(view.PathOnRightPanel)?.FullName))
                    {
                        path = Directory.GetParent(view.PathOnRightPanel).FullName;
                    }
                    else
                    {
                        view.ShowDisk(FilePanel.Right);
                        return false;
                    }
                }
                else if (DriveInfo.GetDrives().FirstOrDefault(x => x.Name.ToLower() == text[1].Replace("\\", "").ToLower() + "\\") != null)
                {
                    path = text[1].Replace("\\", "") + "\\";
                }
                else
                {
                    path = view.PathOnRightPanel + "\\" + text[1];
                }
                if (Directory.Exists(path))
                {
                    new Clear(view.ConsoleWidht, view.ConsoleHeight).ClearPanel(view.FilePanel);
                    view.PageInScrollingInRightPanel = 0;
                    view.ShowFiles(new Panel(path, FilePanel.Right));
                }
            }
            return false;
        }
    }
}
