namespace Far
{
    /// <summary>
    /// Список панелей
    /// </summary>
    public enum FilePanel
    {
        Right,
        Left
    }

    public class Panel
    {
        /// <summary>
        /// Левая или правая панель
        /// </summary>
        public FilePanel FilePanel { get; set; }

        /// <summary>
        /// Путь до директории
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Список папок и файлов
        /// </summary>
        public List<Files> Files { get; set; }

        public Panel(string path, FilePanel panel)
        {
            Path = path;
            Files = new GetFilesAndDir(path).GetListCurrentDirectory();
            FilePanel = panel;
        }
    }
}
