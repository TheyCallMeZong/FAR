namespace Far.Command.Line
{
    /// <summary>
    /// Удаление файла или директории
    /// </summary>
    public class Delete : ICommand<string>
    {
        /// <summary>
        /// массив, хранящий команду и путь
        /// </summary>
        private string[] text;

        public bool CanExecute(string item)
        {
            text = item.Split(' ');
            return text.Length == 2 && text[0].ToLower() == "delete";
        }

        public bool Execute()
        {
            View view = View.GetInstance();
            if (view.FilePanel == FilePanel.Left) 
            { 
                if (File.Exists(view.PathOnLeftPanel + "\\" + text[1]))
                {
                    FormWithMessage.Show(view.ConsoleWidht, view.ConsoleHeight);
                    FormWithMessage.ShowYN(view.ConsoleWidht, view.ConsoleHeight, $"Do you want delete the file {text[1]}?");

                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        File.Delete(view.PathOnLeftPanel + "\\" + text[1]);
                    }
                }
                else if (Directory.Exists(view.PathOnLeftPanel + "\\" + text[1]))
                {
                    FormWithMessage.Show(view.ConsoleWidht, view.ConsoleHeight);
                    FormWithMessage.ShowYN(view.ConsoleWidht, view.ConsoleHeight, $"Do you want delete the directory {text[1]}?");

                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        Directory.Delete(view.PathOnLeftPanel + "\\" + text[1], true);
                    }
                }
            }
            else
            {
                if (File.Exists(view.PathOnRightPanel + "\\" + text[1]))
                {
                    FormWithMessage.Show(view.ConsoleWidht, view.ConsoleHeight);
                    FormWithMessage.ShowYN(view.ConsoleWidht, view.ConsoleHeight, $"Do you want delete the file {text[1]}?");

                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        File.Delete(view.PathOnRightPanel + "\\" + text[1]);
                    }
                }
                else if (Directory.Exists(view.PathOnRightPanel + "\\" + text[1]))
                {
                    FormWithMessage.Show(view.ConsoleWidht, view.ConsoleHeight);
                    FormWithMessage.ShowYN(view.ConsoleWidht, view.ConsoleHeight, $"Do you want delete the directory {text[1]}?");

                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        Directory.Delete(view.PathOnRightPanel + "\\" + text[1], true);
                    }
                }
            }
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            new CloseHelpMenu().Execute();
            return false;
        }
    }
}
