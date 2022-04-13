namespace Far.Command
{
    /// <summary>
    /// Изменение имени файла
    /// </summary>
    public class Rename : ICommand<ConsoleKeyInfo>
    {
        public bool CanExecute(ConsoleKeyInfo item)
        {
            return item.Key == ConsoleKey.F4;
        }

        public bool Execute()
        {
            View view = View.GetInstance();
            view.ShowEditMessage();
            return false;
        }
    }
}
