namespace Far.Command.Line
{
    /// <summary>
    /// помощь 
    /// </summary>
    public class Help : ICommand<string>
    {
        public bool CanExecute(string item)
        {
            return item.ToLower() == "help";
        }

        public bool Execute()
        {
            string[] message = new[]
            {
                "exit - exit",
                "help - help",
                "cd - change directory",
                "mkdir - make directory",
                "select (left or right) - select panel",
                "mkf - make file",
                "close - close cmd",
                "delete %\\path\\% - delete file or directory",
                "rename file, new file - rename file",
                "open %\\path\\% - open txt file",
                "copy %\\path\\% - copy file",
                "renmove %\\path\\% - renmove file",
                "To close the menu, enter \"close help\""
            };
            View view = View.GetInstance();
            FormWithMessage.Show(view.ConsoleWidht, view.ConsoleHeight);
            FormWithMessage.ShowHelpMessage(view.ConsoleWidht, view.ConsoleHeight, message);
            CommandLine.HelpIsOpen = true;
            return false;
        }
    }
}
