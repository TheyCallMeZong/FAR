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
            view.ShowHelpMessage();

            return false;
        }
    }
}
