namespace Far.Command
{
    /// <summary>
    /// Изменение имени файла
    /// </summary>
    public class Edit : ICommand<ConsoleKeyInfo>
    {
        public bool CanExecute(ConsoleKeyInfo item)
        {
            return item.Key == ConsoleKey.F3;
        }

        public bool Execute()
        {
            View view = View.GetInstance();
            view.ShowEditMessage();
            return false;
        }
    }
}
