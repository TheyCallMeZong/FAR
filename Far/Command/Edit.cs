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
                item = view.FilesAndDirectoriesOnLeftPanel[view.AbsolutleCursorOffseOnLeftPanel];
                if (item.Extension == ".txt")
                {
                    Process process = new();
                    process.StartInfo.FileName = @"C:\Windows\System32\notepad.exe";
                    process.StartInfo.Arguments = item.Path + "\\" + item.Name;
                    process.Start();
                }
                if (item.Extension == ".exe")
                {
                    Process process = new Process();
                    process.StartInfo.FileName = item.Path + "\\" + item.Name;
                    process.Start();
                }
            }
            else
            {
                item = view.FilesAndDirectoriesOnRightPanel[view.AbsolutleCursorOffseOnRightPanel];

                if (item.Extension == ".txt")
                {
                    Process process = new();
                    process.StartInfo.FileName = @"C:\Windows\System32\notepad.exe";
                    process.StartInfo.Arguments = item.Path + "\\" + item.Name;
                    process.Start();
                }
                if (item.Extension == ".exe")
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
