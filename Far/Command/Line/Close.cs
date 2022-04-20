namespace Far.Command.Line
{
    /// <summary>
    /// закрытие командной строки
    /// </summary>
    public class Close : ICommand<string>
    {
        public bool CanExecute(string item)
        {
            return item.ToLower() == "close";
        }

        public bool Execute()
        {
            View view = View.GetInstance();
            Console.SetCursorPosition(1, view.ConsoleHeight - 3);
            Console.Write(string.Concat(Enumerable.Repeat(' ', view.ConsoleWidht - 1)));
            new Clear(view.ConsoleWidht, view.ConsoleHeight).ClearPanel(FilePanel.Left);
            new Clear(view.ConsoleWidht, view.ConsoleHeight).ClearPanel(FilePanel.Right);
            VerticalLine verticalLine = new VerticalLine();
            verticalLine.DrawLine(1, view.ConsoleHeight - 3, view.ConsoleWidht / 2, '|');
            view.SetMenu();
            view.ShowFiles(new Panel(view.PathOnLeftPanel, FilePanel.Left));
            view.ShowFiles(new Panel(view.PathOnRightPanel, FilePanel.Right));
            view.SetStartCursor(view.FilePanel);
            return true;
        }
    }
}
