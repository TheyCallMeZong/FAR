namespace Far
{
    /// <summary>
    /// Скролинг вверх
    /// </summary>
    public class UpMove : ICommand<ConsoleKeyInfo>
    {
        public bool CanExecute(ConsoleKeyInfo item)
        {
            return item.Key == ConsoleKey.UpArrow;
        }

        public bool Execute()
        {
            View view = View.GetInstance();
            view.MoveCusrorUp();
            return false;
        }
    }
}
