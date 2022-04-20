using System.Diagnostics;
namespace Far.Command.Line
{
    /// <summary>
    /// выход из программы
    /// </summary>
    public class Exit : ICommand<string>
    {
        public bool CanExecute(string item)
        {
            return item.ToLower() == "exit";
        }

        public bool Execute()
        {
            return true;
        }
    }
}
