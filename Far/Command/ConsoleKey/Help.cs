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
            List<string> message = view.menu.ToList();
            message.Add("Tab ChangePanel");
            FormWithMessage.ShowHelpMessage(view.ConsoleWidht, view.ConsoleHeight, message.ToArray());
            Window.MenuIsOpen = true;
            return false;
        }
    }
}
