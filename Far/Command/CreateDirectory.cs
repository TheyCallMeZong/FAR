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
                    if (!Directory.Exists(view.PathOnLeftPanel + "\\" + name))
                    {
                        Directory.CreateDirectory(view.PathOnLeftPanel + "\\" + name);
                    }
                }
                else
                {
                    if (!Directory.Exists(view.PathOnRightPanel + "\\" + name))
                    {
                        Directory.CreateDirectory(view.PathOnRightPanel + "\\" + name);
                    }
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
