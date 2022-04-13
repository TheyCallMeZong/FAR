using System.Diagnostics;

namespace Far.Command
{
    public class Edit : ICommand<ConsoleKeyInfo>
    {
        public bool CanExecute(ConsoleKeyInfo item)
        {
            return item.Key == ConsoleKey.F3;
        }

        public bool Execute()
        {
            Files item;
            View view = View.GetInstance();
            if (view.FilePanel == FilePanel.Left)
            {
                item = view.FilesAndDirectoriesOnLeftPanel[view.CursorOffsetOnLeftPanel - 4];
                if (item.Extension == "txt")
                {
                    if (File.Exists(item.Path + "\\" + item.Name))
                    {
                        Process process = new();
                        process.StartInfo.FileName = @"C:\Windows\System32\notepad.exe";
                        process.StartInfo.Arguments = item.Path + "\\" + item.Name;
                        process.Start();
                    }
                }
            }
            else
            {
                item = view.FilesAndDirectoriesOnRightPanel[view.CursorOffsetOnRightPanel - 4];

                if (item.Extension == "txt")
                {
                    if (File.Exists(item.Path + "\\" + item.Name))
                    {
                        Process process = new();
                        process.StartInfo.FileName = @"C:\Windows\System32\notepad.exe";
                        process.StartInfo.Arguments = item.Path + "\\" + item.Name;
                        process.Start();
                    }
                }
            }
            return false;
        }
    }
}
