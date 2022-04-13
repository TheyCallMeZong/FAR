namespace Far
{
    /// <summary>
    /// Выход из программы
    /// </summary>
    public class Quit : ICommand<ConsoleKeyInfo>
    {
        public bool CanExecute(ConsoleKeyInfo item)
        {
            return item.Key == ConsoleKey.F10;
        }

        public bool Execute()
        {
            return true;
        }
    }
}
