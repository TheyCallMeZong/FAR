namespace Far.Command.Line
{
    /// <summary>
    /// создание директории
    /// </summary>
    public class CreateDirectory : ICommand<string>
    {
        /// <summary>
        /// массив содержащий команду и название директории
        /// </summary>
        private string[] text;
        public bool CanExecute(string item)
        {
            text = item.Split(' ');
            return text[0].ToLower() == "mkdir" && text.Length == 2 && !string.IsNullOrEmpty(text[1]);
        }

        public bool Execute()
        {
            View view = View.GetInstance();
            try
            {
                if (view.FilePanel == FilePanel.Left)
                {
                    var e = Directory.GetDirectories(view.PathOnLeftPanel, "*" + text[1]);
                    var path = view.PathOnLeftPanel;
                    Directory.CreateDirectory(Directory.Exists(path + "\\" + text[1]) ? path + "\\" + $"({e.Length + 1})" + text[1] : path + "\\" + text[1]);

                    new Clear(view.ConsoleWidht, view.ConsoleHeight).ClearPanel(FilePanel.Left);
                    view.ShowFiles(new Panel(view.PathOnLeftPanel, FilePanel.Left));
                }
                else
                {
                    var e = Directory.GetDirectories(view.PathOnRightPanel, "*" + text[1]);
                    var path = view.PathOnRightPanel;
                    Directory.CreateDirectory(Directory.Exists(path + "\\" + text[1]) ? path + "\\" + $"({e.Length + 1})" + text[1] : path + "\\" + text[1]);

                    new Clear(view.ConsoleWidht, view.ConsoleHeight).ClearPanel(FilePanel.Right);
                    view.ShowFiles(new Panel(view.PathOnRightPanel, FilePanel.Right));
                }
            }
            catch
            {

            }

            return false;
        }
    }
}
