using System.Diagnostics;

namespace Far.Command
{
    /// <summary>
    /// Открытие файла или директории
    /// </summary>
    public class Open : ICommand<ConsoleKeyInfo>
    {
        public bool CanExecute(ConsoleKeyInfo item)
        {
            return item.Key == ConsoleKey.Enter;
        }

        public bool Execute()
        {
            Files item;
            string str;
            View view = View.GetInstance();
            if (view.FilePanel == FilePanel.Left)
            {
                if (view.DriversOnLeftPanel.Count > 0)
                {
                    str = view.DriversOnLeftPanel[view.CursorOffsetOnLeftPanel - 3].Name;
                    view.ShowFiles(new Panel(str, FilePanel.Left)); 
                    view.SetStartCursor(view.FilePanel);
                    return false;
                }
                if (view.CursorOffsetOnLeftPanel == 3)
                {
                    string path = view.PathOnLeftPanel;
                    path = path.Remove(path.LastIndexOf('\\')); 
                    if (!path.Contains("\\"))
                    {
                        view.ShowDisk(view.FilePanel);
                        return false;
                    }
                    view.ShowFiles(new Panel(path, FilePanel.Left));
                    view.SetStartCursor(view.FilePanel);
                    return false;
                }
                item = view.FilesAndDirectoriesOnLeftPanel[view.CursorOffsetOnLeftPanel - 4];

                if (item.Extension == null)
                {
                    view.ShowFiles(new Panel(item.Path + "\\" + item.Name, FilePanel.Left));
                    view.SetStartCursor(view.FilePanel);
                }
                else if (item.Extension == ".txt")
                {
                    if (File.Exists(item.Path + "\\" + item.Name))
                    {
                        Process process = new();
                        process.StartInfo.FileName = @"C:\Windows\System32\notepad.exe";
                        process.StartInfo.Arguments = item.Path + "\\" + item.Name;
                        process.Start();
                    }
                }
                else if (item.Extension == ".exe")
                {
                    Process process = new Process();
                    process.StartInfo.FileName = item.Path + "\\" + item.Name;
                    process.Start();
                }
            }
            else
            {
                if (view.DriversOnRightPanel.Count > 0)
                {
                    str = view.DriversOnRightPanel[view.CursorOffsetOnRightPanel - 3].Name;
                    view.ShowFiles(new Panel(str, FilePanel.Right));
                    view.SetStartCursor(view.FilePanel);
                    return false;
                }
                if (view.CursorOffsetOnRightPanel == 3)
                {
                    string path = view.PathOnRightPanel;
                    path = path.Remove(path.LastIndexOf('\\'));
                    if (!path.Contains("\\"))
                    {
                        view.ShowDisk(view.FilePanel);
                        return false;
                    }
                    view.ShowFiles(new Panel(path, FilePanel.Right));
                    view.SetStartCursor(view.FilePanel);
                    return false;
                }

                item = view.FilesAndDirectoriesOnRightPanel[view.CursorOffsetOnRightPanel - 4];

                if (item.Extension == null)
                {
                    view.ShowFiles(new Panel(item.Path + "\\" + item.Name, FilePanel.Right));
                    view.SetStartCursor(view.FilePanel);
                }
                else if (item.Extension == ".txt")
                {
                    if (File.Exists(item.Path + "\\" + item.Name))
                    {
                        Process process = new();
                        process.StartInfo.FileName = @"C:\Windows\System32\notepad.exe";
                        process.StartInfo.Arguments = item.Path + "\\" + item.Name;
                        process.Start();
                    }
                }
                else if (item.Extension == ".exe")
                {
                    Process process = new Process();
                    process.StartInfo.FileName = item.Path + "\\" + item.Name;
                    process.Start();
                }
            }
            return false;
        }
    }
}
