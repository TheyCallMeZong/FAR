namespace Far.Command
{
    /// <summary>
    /// Скролинг вниз
    /// </summary>
    public class DownMove : ICommand<ConsoleKeyInfo>
    {
        public bool CanExecute(ConsoleKeyInfo item)
        {
            return item.Key == ConsoleKey.DownArrow;
        }

        public bool Execute()
        {
            View view = View.GetInstance();
            view.MoveCusrorDown();
            return false;
        }
    }
}
