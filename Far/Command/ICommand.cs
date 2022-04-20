namespace Far.Command
{
    /// <summary>
    /// Паттер команда
    /// </summary>
    /// <typeparam name="T">ConsoleKey or string</typeparam>
    public interface ICommand<T>
    {
        /// <summary>
        /// Проверка на возможность выполнения данной команды
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool CanExecute(T item);

        /// <summary>
        /// Выполнение команды
        /// </summary>
        /// <returns></returns>
        public bool Execute();
    }
}
