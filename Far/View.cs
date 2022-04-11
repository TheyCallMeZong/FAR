using System.Drawing;
using System.Runtime.InteropServices;

namespace Far
{
    public class View
    {
        /// <summary>
        /// Отступ для печати пути
        /// </summary>
        public int OffsetForPath { get; set; }

        /// <summary>
        /// Отуступ для печати файлов и директорий
        /// </summary>
        public int OffsetForFileAndDir { get; set; }

        /// <summary>
        /// Ширина консоли
        /// </summary>
        public int ConsoleWidht { get; set; }

        /// <summary>
        /// Высота консоли
        /// </summary>
        public int ConsoleHeight { get; set; }

        /// <summary>
        /// Отступ курсора для левой панели
        /// </summary>
        public int CursorOffsetOnLeftPanel { get; set; }

        /// <summary>
        /// Отступ курсора для правой панели
        /// </summary>
        public int CursorOffsetOnRightPanel { get; set; }

        /// <summary>
        /// Все файлы и директории текущей папки левой панели
        /// </summary>
        public List<Files> FilesAndDirectoriesOnLeftPanel { get; set; }

        /// <summary>
        /// Все файлы и директории текущей папки правой панели
        /// </summary>
        public List<Files> FilesAndDirectoriesOnRightPanel { get; set; }

        /// <summary>
        /// Диски на левой панели
        /// </summary>
        public List<DriveInfo> DriversOnLeftPanel { get; set; }

        /// <summary>
        /// Диски на правой панели
        /// </summary>
        public List<DriveInfo> DriversOnRightPanel { get; set; }

        /// <summary>
        /// какая панель исользуется 
        /// </summary>
        public FilePanel FilePanel;

        /// <summary>
        /// Путь
        /// </summary>
        public string PathOnLeftPanel { get; set; }

        /// <summary>
        /// Путь
        /// </summary>
        public string PathOnRightPanel { get; set; }

        /// <summary>
        /// Открыта ли менюшка
        /// </summary>
        public bool HelpIsOpen;

        /// <summary>
        /// Экземляр одиночик
        /// </summary>
        private static View instance;

        /// <summary>
        /// Получение экземпляра одиночик
        /// </summary>
        /// <returns></returns>
        public static View GetInstance()
        {
            if (instance == null)
            {
                instance = new View();
            }
            return instance;
        }

        /// <summary>
        /// Дескриптор окна
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        /// <summary>
        /// Функция, которая определяет положение окна
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nCmdShow"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        /// <summary>
        /// Максимальное значение для показа окна
        /// </summary>
        private const int MAXSIZE = 3;

        private string[] menu = new[]
        {
            "F1 Help",
            "F2 CreateFile",
            "F3 Edit",
            "F4 Rename",
            "F5 Copy",
            "F6 Renmove",
            "F7 CreateDirectory",
            "F8 Delete",
            "F9 Tree",
            "F10 Exit"
        };
        /// <summary>
        /// Конструктор
        /// </summary>
        public View()
        {
            ConsoleWidht = Console.WindowWidth;
            ConsoleHeight = Console.WindowHeight;
            Console.BufferHeight = ConsoleHeight;
            Console.BufferWidth = ConsoleWidht + 1;
            OffsetForPath = 1;
            OffsetForFileAndDir = 3;
            CursorOffsetOnLeftPanel = 4;
            CursorOffsetOnRightPanel = 4;
            DriversOnRightPanel = new List<DriveInfo>();
            DriversOnLeftPanel = new List<DriveInfo>();
            FilePanel = FilePanel.Left;
        }

        /// <summary>
        /// Устанавливаем окно во весь экран и меняем цвет текста 
        /// </summary>
        public void SetWindow()
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(GetConsoleWindow(), MAXSIZE);
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Title = "FAR";
            ConsoleWidht = Console.WindowWidth;
            ConsoleHeight = Console.WindowHeight;
        }

        /// <summary>
        /// Дизайн
        /// </summary>
        public void ViewDesign()
        {
            for (int i = 0; i < ConsoleHeight; i++)
            {
                Console.Write(string.Concat(Enumerable.Repeat(' ', ConsoleWidht)));
            }
            HorizontalLine horizontal = new HorizontalLine();
            horizontal.DrawLine(0, ConsoleWidht, 0, '~');
            horizontal.DrawLine(0, ConsoleWidht, ConsoleHeight - 2, '~');
            horizontal.DrawLine(1, ConsoleWidht / 2, 2, '~');
            horizontal.DrawLine(ConsoleWidht / 2, ConsoleWidht, 2, '~');
            horizontal.DrawLine(1, ConsoleWidht / 2, ConsoleHeight - 4, '~');
            horizontal.DrawLine(ConsoleWidht / 2, ConsoleWidht, ConsoleHeight - 4, '~');
            VerticalLine verticalLine = new VerticalLine();
            verticalLine.DrawLine(0, ConsoleHeight - 1, 0, '|');
            verticalLine.DrawLine(0, ConsoleHeight - 1, ConsoleWidht - 1, '|');
            verticalLine.DrawLine(1, ConsoleHeight - 3, ConsoleWidht / 2, '|');
            SetMenu();
        }

        public void SetMenu()
        {
            Console.SetCursorPosition(1, ConsoleHeight - 3);

            foreach (var item in menu)
            {
                Console.Write(item + "\t| ");
            }
        }

        /// <summary>
        /// Отображение всех файлов и директорий
        /// </summary>
        /// <param name="panel"></param>
        public void ShowFiles(Panel panel)
        {
            new Clear(ConsoleWidht, ConsoleHeight).ClearPanel(panel.FilePanel);
            OffsetForFileAndDir = 3;
            if (panel.FilePanel == FilePanel.Left)
            {
                FilesAndDirectoriesOnLeftPanel = panel.Files;
                Console.SetCursorPosition(1 + GetLeftOffset(panel), OffsetForFileAndDir);
                Console.WriteLine("Extension Size");
                Console.SetCursorPosition(1, OffsetForFileAndDir++);
                Console.WriteLine("[..]");
                Console.SetCursorPosition(1, OffsetForPath);
                
                Console.Write(panel.Path);
                Console.SetCursorPosition(GetLeftOffset(panel), OffsetForFileAndDir);
                Console.WriteLine("|\t\t|\t\t|");
                foreach (var item in panel.Files)
                {
                    Console.SetCursorPosition(1, OffsetForFileAndDir++);
                    Console.Write(item.Name);
                    Console.SetCursorPosition(GetLeftOffset(panel), OffsetForFileAndDir);
                    Console.WriteLine("|\t\t|\t\t|");
                    if (!string.IsNullOrEmpty(item.Extension))
                    {
                        Console.SetCursorPosition(GetLeftOffset(panel), --OffsetForFileAndDir);
                        var size = Math.Round((item.Size / 8 / 1024), 1);
                        if (size == 0)
                        {
                            size = 1;
                        }
                        Console.Write("|" + item.Extension + "\t| " + size + " KByte");
                        
                        OffsetForFileAndDir++;
                    }
                }
                PathOnLeftPanel = panel.Path;
                DriversOnLeftPanel.Clear();
                CursorOffsetOnLeftPanel = 4;
            }
            else
            {
                FilesAndDirectoriesOnRightPanel = panel.Files;
                Console.SetCursorPosition(GetLeftOffset(panel), OffsetForFileAndDir);
                Console.WriteLine(" Extension Size");
                Console.SetCursorPosition(ConsoleWidht / 2 + 1, OffsetForFileAndDir++);
                Console.WriteLine("[..]");
                Console.SetCursorPosition(ConsoleWidht / 2 + 1, OffsetForPath);
                Console.Write(panel.Path);
                Console.SetCursorPosition(GetLeftOffset(panel), OffsetForFileAndDir);
                Console.WriteLine("|\t\t|\t\t|");
                foreach (var item in panel.Files)
                {
                    if (OffsetForFileAndDir == ConsoleHeight - 4)
                    {
                        return;
                    }
                    Console.SetCursorPosition(ConsoleWidht / 2 + 1, OffsetForFileAndDir++);
                    Console.Write(item.Name);
                    Console.SetCursorPosition(GetLeftOffset(panel), OffsetForFileAndDir);
                    Console.WriteLine("|\t\t|\t\t|");
                    if (!string.IsNullOrEmpty(item.Extension))
                    {
                        Console.SetCursorPosition(GetLeftOffset(panel), --OffsetForFileAndDir);
                        var size = Math.Round((item.Size / 8 / 1024), 1);
                        if (size == 0)
                        {
                            size = 1;
                        }
                        Console.Write("|" + item.Extension + "\t| " + size + " KByte");
                        OffsetForFileAndDir++;
                    }
                }
                PathOnRightPanel = panel.Path;
                DriversOnRightPanel.Clear();
                CursorOffsetOnRightPanel = 4;
            }
            OffsetForFileAndDir = 3;
            SetStartCursor();
        }

        /// <summary>
        /// получение отступа для отображение расширения и размера файла
        /// </summary>
        /// <param name="panel"></param>
        /// <returns></returns>
        public int GetLeftOffset(Panel panel)
        {
            if (panel.FilePanel == FilePanel.Left)
            {
                return ConsoleWidht / 2 - 50;
            }
            else
            {
                return ConsoleWidht - 50;
            }
        }

        /// <summary>
        /// Установка начального положения курсора
        /// </summary>
        /// <param name="panel"></param>
        public void SetStartCursor()
        {
            if (FilePanel == FilePanel.Left)
            {
                if (FilesAndDirectoriesOnLeftPanel.Count == 0 && DriversOnLeftPanel.Count == 0)
                {
                    Console.SetCursorPosition(1, --CursorOffsetOnLeftPanel);
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("[..]");
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    return;
                }
                if (DriversOnLeftPanel.Count != 0)
                {
                    Console.SetCursorPosition(1, CursorOffsetOnLeftPanel);
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(DriversOnLeftPanel[0].Name);
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    return;
                }
                Console.SetCursorPosition(1, CursorOffsetOnLeftPanel);
                var item = FilesAndDirectoriesOnLeftPanel[CursorOffsetOnLeftPanel - 4].Name;

                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.WriteLine(item);
                Console.BackgroundColor = ConsoleColor.DarkBlue;
            }
            else
            {
                if (FilesAndDirectoriesOnRightPanel.Count == 0 && DriversOnRightPanel.Count == 0)
                {
                    Console.SetCursorPosition(ConsoleWidht / 2 + 1, --CursorOffsetOnRightPanel);
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("[..]");
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    return;
                }
                if (DriversOnRightPanel.Count != 0)
                {
                    Console.SetCursorPosition(ConsoleWidht / 2 + 1, CursorOffsetOnRightPanel);
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(DriversOnRightPanel[CursorOffsetOnRightPanel - 3].Name);
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    return;
                }

                Console.SetCursorPosition(ConsoleWidht / 2 + 1, CursorOffsetOnRightPanel);
                var item = FilesAndDirectoriesOnRightPanel[CursorOffsetOnRightPanel - 4].Name;

                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.WriteLine(item);
                Console.BackgroundColor = ConsoleColor.DarkBlue;
            }
        }

        /// <summary>
        /// перемещение курсора вниз
        /// </summary>
        /// <param name="panel"></param>
        public void MoveCusrorDown()
        {
            string item;
            if (FilePanel == FilePanel.Left)
            {
                if (DriversOnLeftPanel.Count != 0 && CursorOffsetOnLeftPanel != DriversOnLeftPanel.Count + 2)
                {
                    Console.SetCursorPosition(1, CursorOffsetOnLeftPanel);
                    item = DriversOnLeftPanel[CursorOffsetOnLeftPanel - 3].Name;
                    Console.WriteLine(item);
                    Console.SetCursorPosition(1, ++CursorOffsetOnLeftPanel);
                    item = DriversOnLeftPanel[CursorOffsetOnLeftPanel - 3].Name;
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(item);
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    return;
                }
                if (CursorOffsetOnLeftPanel == FilesAndDirectoriesOnLeftPanel.Count + 3 || CursorOffsetOnLeftPanel == DriversOnLeftPanel.Count + 2)
                {
                    return;
                }
                else if (CursorOffsetOnLeftPanel == 3)
                {
                    Console.SetCursorPosition(1, CursorOffsetOnLeftPanel);
                    Console.WriteLine("[..]");
                }
                else if (CursorOffsetOnLeftPanel != 3)
                {
                    Console.SetCursorPosition(1, CursorOffsetOnLeftPanel);
                    item = FilesAndDirectoriesOnLeftPanel[CursorOffsetOnLeftPanel - 4].Name;
                    Console.WriteLine(item);
                }
                Console.SetCursorPosition(1, ++CursorOffsetOnLeftPanel);
                item = FilesAndDirectoriesOnLeftPanel[CursorOffsetOnLeftPanel - 4].Name;
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.WriteLine(item);
                Console.BackgroundColor = ConsoleColor.DarkBlue;
            }
            else
            {
                if (DriversOnRightPanel.Count != 0 && CursorOffsetOnRightPanel != DriversOnRightPanel.Count + 2)
                {
                    Console.SetCursorPosition(ConsoleWidht / 2 + 1, CursorOffsetOnRightPanel);
                    item = DriversOnRightPanel[CursorOffsetOnRightPanel - 3].Name;
                    Console.WriteLine(item);
                    Console.SetCursorPosition(ConsoleWidht / 2 + 1, ++CursorOffsetOnRightPanel);
                    item = DriversOnRightPanel[CursorOffsetOnRightPanel - 3].Name;
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(item);
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    return;
                }
                else if (CursorOffsetOnRightPanel == FilesAndDirectoriesOnRightPanel.Count + 3 || CursorOffsetOnRightPanel == DriversOnRightPanel.Count + 2)
                {
                    return;
                }
                else if (CursorOffsetOnRightPanel == 3 && DriversOnRightPanel.Count == 0)
                {
                    Console.SetCursorPosition(ConsoleWidht / 2 + 1, CursorOffsetOnRightPanel);
                    Console.WriteLine("[..]");
                }
                else if (CursorOffsetOnRightPanel != 3 && DriversOnRightPanel.Count == 0)
                {
                    Console.SetCursorPosition(ConsoleWidht / 2 + 1, CursorOffsetOnRightPanel);
                    item = FilesAndDirectoriesOnRightPanel[CursorOffsetOnRightPanel - 4].Name;
                    Console.WriteLine(item);
                }
                Console.SetCursorPosition(ConsoleWidht / 2 + 1, ++CursorOffsetOnRightPanel);
                item = FilesAndDirectoriesOnRightPanel[CursorOffsetOnRightPanel - 4].Name;
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.WriteLine(item);
                Console.BackgroundColor = ConsoleColor.DarkBlue;
            }
        }

        /// <summary>
        /// перемещение курсора вверх
        /// </summary>
        /// <param name="panel"></param>
        public void MoveCusrorUp()
        {
            string item;
            if (FilePanel == FilePanel.Left)
            {
                if (CursorOffsetOnLeftPanel == 4 && DriversOnLeftPanel.Count == 0)
                {
                    Console.SetCursorPosition(1, CursorOffsetOnLeftPanel);
                    item = FilesAndDirectoriesOnLeftPanel[CursorOffsetOnLeftPanel - 4].Name;
                    Console.WriteLine(item);
                    Console.SetCursorPosition(1, --CursorOffsetOnLeftPanel);
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("[..]");
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    return;
                }
                else if (DriversOnLeftPanel.Count != 0 && CursorOffsetOnLeftPanel != 3)
                {
                    Console.SetCursorPosition(1, CursorOffsetOnLeftPanel);
                    item = DriversOnLeftPanel[CursorOffsetOnLeftPanel - 3].Name;
                    Console.WriteLine(item);
                    Console.SetCursorPosition(1, --CursorOffsetOnLeftPanel);
                    item = DriversOnLeftPanel[CursorOffsetOnLeftPanel - 3].Name;
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(item);
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    return;
                }
                else if (CursorOffsetOnLeftPanel == 3 || FilesAndDirectoriesOnLeftPanel.Count == 0)
                {
                    return;
                }
                Console.SetCursorPosition(1, CursorOffsetOnLeftPanel);
                item = FilesAndDirectoriesOnLeftPanel[CursorOffsetOnLeftPanel - 4].Name;
                Console.WriteLine(item);
                Console.SetCursorPosition(1, --CursorOffsetOnLeftPanel);
                item = FilesAndDirectoriesOnLeftPanel[CursorOffsetOnLeftPanel - 4].Name;
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.WriteLine(item);
                Console.BackgroundColor = ConsoleColor.DarkBlue;
            }
            else
            {
                if (CursorOffsetOnRightPanel == 4 && DriversOnRightPanel.Count == 0)
                {
                    Console.SetCursorPosition(ConsoleWidht / 2 + 1, CursorOffsetOnRightPanel);
                    item = FilesAndDirectoriesOnRightPanel[CursorOffsetOnRightPanel - 4].Name;
                    Console.WriteLine(item);
                    Console.SetCursorPosition(ConsoleWidht / 2 + 1, --CursorOffsetOnRightPanel);
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("[..]");
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    return;
                }
                else if (DriversOnRightPanel.Count != 0 && CursorOffsetOnRightPanel != 3)
                {
                    Console.SetCursorPosition(ConsoleWidht / 2 + 1, CursorOffsetOnRightPanel);
                    item = DriversOnRightPanel[CursorOffsetOnRightPanel - 3].Name;
                    Console.WriteLine(item);
                    Console.SetCursorPosition(ConsoleWidht / 2 + 1, --CursorOffsetOnRightPanel);
                    item = DriversOnRightPanel[CursorOffsetOnRightPanel - 3].Name;
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(item);
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    return;
                }
                else if (CursorOffsetOnRightPanel == 3 || FilesAndDirectoriesOnRightPanel.Count == 0)
                {
                    return;
                }
                Console.SetCursorPosition(ConsoleWidht / 2 + 1, CursorOffsetOnRightPanel);
                item = FilesAndDirectoriesOnRightPanel[CursorOffsetOnRightPanel - 4].Name;
                Console.WriteLine(item);
                Console.SetCursorPosition(ConsoleWidht / 2 + 1, --CursorOffsetOnRightPanel);
                item = FilesAndDirectoriesOnRightPanel[CursorOffsetOnRightPanel - 4].Name;
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.WriteLine(item);
                Console.BackgroundColor = ConsoleColor.DarkBlue;
            }
        }

        /// <summary>
        /// отображение дисков
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void ShowDisk()
        {
            if (FilePanel == FilePanel.Left)
            {
                new Clear(ConsoleWidht, ConsoleHeight).ClearPanel(FilePanel.Left);

                var drivers = DriveInfo.GetDrives();
                foreach (var driver in drivers)
                {
                    Console.SetCursorPosition(1, OffsetForFileAndDir++);
                    Console.Write(driver.Name);
                    DriversOnLeftPanel.Add(driver);
                }
                FilesAndDirectoriesOnLeftPanel.Clear();
            }
            else
            {
                new Clear(ConsoleWidht, ConsoleHeight).ClearPanel(FilePanel.Right);

                var drivers = DriveInfo.GetDrives();
                foreach (var driver in drivers)
                {
                    Console.SetCursorPosition(ConsoleWidht / 2 + 1, OffsetForFileAndDir++);
                    Console.Write(driver.Name);
                    DriversOnRightPanel.Add(driver);
                }
                FilesAndDirectoriesOnRightPanel.Clear();
            }
            OffsetForFileAndDir = 3;
            SetStartCursor();
        }

        /// <summary>
        /// Отрисовка формы для окна "Помощь"
        /// </summary>
        public void ShowHelpMessage()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            HorizontalLine hl = new HorizontalLine();
            hl.DrawLine(ConsoleWidht / 2 - ConsoleWidht / 4, ConsoleWidht / 2 + ConsoleWidht / 4, ConsoleHeight / 2 - ConsoleHeight / 4, '*');
            hl.DrawLine(ConsoleWidht / 2 - ConsoleWidht / 4, ConsoleWidht / 2 + ConsoleWidht / 4, ConsoleHeight / 2 + ConsoleHeight / 4, '*');

            VerticalLine vl = new VerticalLine();
            vl.DrawLine(ConsoleHeight / 2 - ConsoleHeight / 4 + 1, ConsoleHeight / 2 + ConsoleHeight / 4, ConsoleWidht / 2 - ConsoleWidht / 4, '|');
            vl.DrawLine(ConsoleHeight / 2 - ConsoleHeight / 4 + 1, ConsoleHeight / 2 + ConsoleHeight / 4, ConsoleWidht / 2 + ConsoleWidht / 4 - 1, '|');
            
            for (int i = 2; i < ConsoleHeight / 2; i++)
            {
                Console.SetCursorPosition(ConsoleWidht / 2 - ConsoleWidht / 4 + 1, i + ConsoleHeight / 4);
                Console.Write(string.Concat(Enumerable.Repeat(' ', ConsoleWidht / 2 - 2)));
            }
            Help();
        }

        /// <summary>
        /// Отрисвока помощи
        /// </summary>
        private void Help()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            for (int i = 0; i < menu.Length; i++)
            {
                Console.SetCursorPosition(ConsoleWidht / 2 - ConsoleWidht / 4 + 2, 1 + i + (ConsoleHeight / 2 - ConsoleHeight / 4));
                Console.WriteLine(menu[i]);
            }
            Console.SetCursorPosition(ConsoleWidht / 2 - ConsoleWidht / 4 + 2, 1 + menu.Length + (ConsoleHeight / 2 - ConsoleHeight / 4));
            Console.Write("Tab ChangePanel");
            HelpIsOpen = true;
        }

        /// <summary>
        /// Убрать окно помощи
        /// </summary>
        public void HideHelp()
        {
            if (!HelpIsOpen)
            {
                return;
            }
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            if (DriversOnLeftPanel.Count == 0 && DriversOnRightPanel.Count == 0)
            {
                ShowFiles(new Panel(PathOnLeftPanel, FilePanel.Left));
                ShowFiles(new Panel(PathOnRightPanel, FilePanel.Right));
                VerticalLine verticalLine = new VerticalLine();
                verticalLine.DrawLine(1, ConsoleHeight - 3, ConsoleWidht / 2, '|');
            }
            else 
            {

            }
        }
    }
}