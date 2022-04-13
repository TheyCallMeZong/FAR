namespace Far.Command
{
    /// <summary>
    /// Дерево файлов и директорий
    /// </summary>
    public class Tree : ICommand<ConsoleKeyInfo>
    {
        public bool CanExecute(ConsoleKeyInfo item)
        {
            return item.Key == ConsoleKey.F9;
        }

        public bool Execute()
        {
            return false;
        }
    }
}
