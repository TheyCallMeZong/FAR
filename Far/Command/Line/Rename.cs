namespace Far.Command.Line
{
    /// <summary>
    /// переименовать файл или директорию
    /// </summary>
    public class Rename : ICommand<string>
    {
        /// <summary>
        /// массив, хранящий команду и путь
        /// </summary>
        private string[] text;

        public bool CanExecute(string item)
        {
            text = item.Split(' ');
            return text.Length == 3 && text[0].ToLower() == "rename";
        }

        public bool Execute()
        {
            View view = View.GetInstance();
            try
            {
                if (view.FilePanel == FilePanel.Left)
                {
                    if (File.Exists(view.PathOnLeftPanel + "\\" + text[1]) && !File.Exists(view.PathOnLeftPanel + "\\" + text[2]))
                    {
                        File.Move(view.PathOnLeftPanel + "\\" + text[1], view.PathOnLeftPanel + "\\" + text[2]);
                    }
                }
                else
                {
                    if (File.Exists(view.PathOnRightPanel + "\\" + text[1]) && !File.Exists(view.PathOnRightPanel + "\\" + text[2]))
                    {
                        File.Move(view.PathOnRightPanel + "\\" + text[1], view.PathOnRightPanel + "\\" + text[2]);
                    }
                }
                new Clear(view.ConsoleWidht, view.ConsoleHeight).ClearPanel(FilePanel.Left);
                new Clear(view.ConsoleWidht, view.ConsoleHeight).ClearPanel(FilePanel.Right);
                view.ShowFiles(new Panel(view.PathOnLeftPanel, FilePanel.Left));
                view.ShowFiles(new Panel(view.PathOnRightPanel, FilePanel.Right));
                CommandLine.Text = "good";
                CommandLine.BackColor = ConsoleColor.Green;
            }
            catch
            {
                CommandLine.Text = "error";
                CommandLine.BackColor = ConsoleColor.Red;
            }
            return false;
        }
    }
}
