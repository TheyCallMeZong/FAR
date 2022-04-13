namespace Far.Command
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
            FormWithMessage.Show(view.ConsoleWidht, view.ConsoleHeight);
            var fileName = FormWithMessage.ShowMessage(view.ConsoleWidht, view.ConsoleHeight, "Enter file name:");
            if (string.IsNullOrEmpty(fileName))
            {
                Window.HideMessage();
                return false;
            }
            try
            {
                if (view.FilePanel == FilePanel.Left)
                {
                    if (!File.Exists(view.PathOnLeftPanel + "\\" + fileName))
                    {
                        var fs = File.Create(view.PathOnLeftPanel + "\\" + fileName);
                        fs.Close();
                    }
                }
                else
                {
                    if (!File.Exists(view.PathOnRightPanel + "\\" + fileName))
                    {
                        var fs = File.Create(view.PathOnRightPanel + "\\" + fileName);
                        fs.Close();
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
