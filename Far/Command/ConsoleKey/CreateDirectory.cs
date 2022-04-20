namespace Far.Command
{
    /// <summary>
    /// Создание директории
    /// </summary>
    public class CreateDirectory : ICommand<ConsoleKeyInfo>
    {
        public bool CanExecute(ConsoleKeyInfo item)
        {
            return item.Key == ConsoleKey.F7;
        }

        public bool Execute()
        {
            View view = View.GetInstance();
            FormWithMessage.Show(view.ConsoleWidht, view.ConsoleHeight);
            string name = FormWithMessage.ShowMessage(view.ConsoleWidht, view.ConsoleHeight, "Enter directory name: ");
            if (string.IsNullOrEmpty(name))
            {
                Window.HideMessage();
                return false;
            }
            try
            {
                if (view.FilePanel == FilePanel.Left)
                {
                    var e = Directory.GetDirectories(view.PathOnLeftPanel, "*" + name);
                    Directory.CreateDirectory(Directory.Exists(view.PathOnLeftPanel + "\\" + name) ? view.PathOnLeftPanel + "\\" + $"({e.Length + 1})" + name : view.PathOnLeftPanel + "\\" + name);
                }
                else
                {
                    var e = Directory.GetDirectories(view.PathOnRightPanel, "*" + name);
                    Directory.CreateDirectory(Directory.Exists(view.PathOnRightPanel + "\\" + name) ? view.PathOnRightPanel + "\\" + $"({e.Length + 1})" + name : view.PathOnRightPanel + "\\" + name);
                }
            }
            catch
            {

            }
            finally
            {
                Window.HideMessage();
            }
            return false;
        }
    }
}
