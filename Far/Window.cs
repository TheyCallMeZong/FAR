namespace Far
{
    public class Window
    {
        private List<ICommand<ConsoleKeyInfo>> commands = new List<ICommand<ConsoleKeyInfo>>()
            {
                new DownMove(),
                new UpMove(),
                new ChangePanel(),
                new Open(),
                new Quit(),
                new Help()
            };

        public void Run()
        {
            View view = View.GetInstance();
            bool quit = false;
            while (!quit)
            {
                var t = Console.ReadKey();
                if (view.HelpIsOpen)
                {
                    view.HideHelp();
                    view.HelpIsOpen = false;
                }
                foreach (var item in commands)
                {
                    if (item.CanExecute(t))
                    {
                        quit = item.Execute();
                        break;
                    }
                }
            }
        }
    }
}