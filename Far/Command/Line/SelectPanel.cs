namespace Far.Command.Line
{
    /// <summary>
    /// выбор панели для работы
    /// </summary>
    public class SelectPanel : ICommand<string>
    {
        /// <summary>
        /// массив, содержащий команду и панель
        /// </summary>
        private string[] text;
        public bool CanExecute(string item)
        {
            text = item.Split(' ');
            return text[0].ToLower() == "select" && !string.IsNullOrEmpty(text[1]) && text.Length == 2;
        }

        public bool Execute()
        {
            View view = View.GetInstance();

            int console;

            if (int.TryParse(text[1], out console))
            {
                if (console == 0 || console == 1)
                {
                    view.FilePanel = (FilePanel)console;
                }
            }
            else
            {
                if (text[1].ToLower() == "right")
                {
                    view.FilePanel = FilePanel.Right;
                }
                else if (text[1].ToLower() == "left")
                {
                    view.FilePanel= FilePanel.Left;
                }
            }
            return false;
        }
    }
}
