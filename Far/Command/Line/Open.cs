using System.Diagnostics;

namespace Far.Command.Line
{
    /// <summary>
    /// откртиые txt файлов
    /// </summary>
    public class Open : ICommand<string>
    {
        /// <summary>
        /// массив, хранящий команду и путь
        /// </summary>
        private string[] text;

        public bool CanExecute(string item)
        {
            text = item.Split(' ');
            return text.Length == 2 && text[0] == "open";
        }

        public bool Execute()
        {
            View view = View.GetInstance();

            if (view.FilePanel == FilePanel.Left)
            {
                if (File.Exists(view.PathOnLeftPanel + "\\" + text[1]))
                {
                    Process process = new();
                    process.StartInfo.FileName = @"C:\Windows\System32\notepad.exe";
                    process.StartInfo.Arguments = view.PathOnLeftPanel + "\\" + text[1];
                    process.Start();
                }
            }
            else
            {
                if (File.Exists(view.PathOnRightPanel + "\\" + text[1]))
                {
                    Process process = new();
                    process.StartInfo.FileName = @"C:\Windows\System32\notepad.exe";
                    process.StartInfo.Arguments = view.PathOnRightPanel + "\\" + text[1];
                    process.Start();
                }
            }

            return false;
        }
    }
}
