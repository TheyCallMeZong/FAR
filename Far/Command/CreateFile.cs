namespace Far
{
    /// <summary>
    /// Создание файла
    /// </summary>
    public class CreateFile : ICommand<ConsoleKeyInfo>
    {
        public bool CanExecute(ConsoleKeyInfo item)
        {
            return item.Key == ConsoleKey.F2;
        }

        public bool Execute()
        {
            View view = View.GetInstance();
            view.ShowCreateFile();
            return false;
        }
    }
}
