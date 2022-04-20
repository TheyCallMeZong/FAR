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
                    var e = Directory.GetFiles(view.PathOnLeftPanel, "*" + fileName);
                    var file = File.Create(File.Exists(view.PathOnLeftPanel + "\\" + fileName) ? view.PathOnLeftPanel + "\\" + $"({e.Length + 1})" + fileName: view.PathOnLeftPanel + "\\" + fileName);
                    file.Close();
                }
                else
                {
                    var e = Directory.GetFiles(view.PathOnRightPanel, "*" + fileName);
                    var file = File.Create(File.Exists(view.PathOnRightPanel + "\\" + fileName) ? view.PathOnRightPanel + "\\" + $"({e.Length + 1})" + fileName : view.PathOnRightPanel + "\\" + fileName);
                    file.Close();
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
