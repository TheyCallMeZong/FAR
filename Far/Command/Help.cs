namespace Far.Command
{
    /// <summary>
    /// Помощь
    /// </summary>
    public class Help : ICommand<ConsoleKeyInfo>
    {
        public bool CanExecute(ConsoleKeyInfo item)
        {
            return item.Key == ConsoleKey.F1;
        }

        public bool Execute()
        {
            View view = View.GetInstance();
            FormWithMessage.Show(view.ConsoleWidht, view.ConsoleHeight);
            FormWithMessage.ShowHelpMessage(view.ConsoleWidht, view.ConsoleHeight, view.menu);
            Window.MenuIsOpen = true;
            return false;
        }
    }
}
