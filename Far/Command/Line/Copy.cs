namespace Far.Command.Line
{
    /// <summary>
    /// Копирование с одной панели на другую через cmd
    /// </summary>
    public class Copy : ICommand<string>
    {
        /// <summary>
        /// массив, хранящий команду и путь
        /// </summary>
        private string[] text;

        public bool CanExecute(string item)
        {
            text = item.Split(' ');
            return text.Length == 2 && text[0] == "copy";
        }

        public bool Execute()
        {
            View view = View.GetInstance();
            try
            {
                if (view.FilePanel == FilePanel.Left)
                {
                    if (File.Exists(view.PathOnLeftPanel + "\\" + text[1]))
                    {
                        if (File.Exists(view.PathOnRightPanel + "\\" + text[1]))
                        {
                            FormWithMessage.Show(view.ConsoleWidht, view.ConsoleHeight);
                            FormWithMessage.ShowYN(view.ConsoleWidht, view.ConsoleHeight, "The file exists. Do you want to replace it?");
                            var click = Console.ReadKey();
                            if (click.Key == ConsoleKey.Y)
                            {
                                File.Delete(view.PathOnRightPanel + "\\" + text[1]);
                            }
                        }
                        File.Copy(view.PathOnLeftPanel + "\\" + text[1], view.PathOnRightPanel + "\\" + text[1]);
                    }
                    else
                    {
                        Directory.Move(view.PathOnLeftPanel + "\\" + text[1], view.PathOnRightPanel + "\\" + text[1]);
                    }
                }
                else
                {
                    if (File.Exists(view.PathOnRightPanel + "\\" + text[1]))
                    {
                        if (File.Exists(view.PathOnLeftPanel + "\\" + text[1]))
                        {
                            FormWithMessage.Show(view.ConsoleWidht, view.ConsoleHeight);
                            FormWithMessage.ShowYN(view.ConsoleWidht, view.ConsoleHeight, "The file exists. Do you want to replace it?");
                            var click = Console.ReadKey();
                            if (click.Key == ConsoleKey.Y)
                            {
                                File.Delete(view.PathOnLeftPanel + "\\" + text[1]);
                            }
                        }
                        File.Copy(view.PathOnRightPanel + "\\" + text[1], view.PathOnLeftPanel + "\\" + text[1]);
                    }
                    else
                    {
                        Directory.Move(view.PathOnRightPanel + "\\" + text[1], view.PathOnLeftPanel + "\\" + text[1]);
                    }
                }
                CommandLine.Text = "good";
                CommandLine.BackColor = ConsoleColor.Green;
            }
            catch
            {
                CommandLine.Text = "error";
                CommandLine.BackColor = ConsoleColor.Red;
            }
            finally
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                new CloseHelpMenu().Execute();
            }
            return false;
        }
    }
}
