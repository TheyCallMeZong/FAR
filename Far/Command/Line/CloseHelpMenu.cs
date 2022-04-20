namespace Far.Command.Line
{
    /// <summary>
    /// закрытие окна помощи
    /// </summary>
    public class CloseHelpMenu : ICommand<string>
    {
        public bool CanExecute(string item)
        {
            return item.ToLower() == "close help";
        }

        public bool Execute()
        {
            View view = View.GetInstance();
            new Clear(view.ConsoleWidht, view.ConsoleHeight).ClearPanel(FilePanel.Left);
            new Clear(view.ConsoleWidht, view.ConsoleHeight).ClearPanel(FilePanel.Right);
            view.ShowFiles(new Panel(view.PathOnLeftPanel, FilePanel.Left));
            view.ShowFiles(new Panel(view.PathOnRightPanel, FilePanel.Right));
            VerticalLine verticalLine = new VerticalLine();
            verticalLine.DrawLine(1, view.ConsoleHeight - 3, view.ConsoleWidht / 2, '|');

            return false;
        }
    }
}
