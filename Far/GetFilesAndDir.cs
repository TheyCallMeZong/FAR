namespace Far
{
    /// <summary>
    /// Получение информации о всех файлах и директориях
    /// </summary>
    public class GetFilesAndDir
    {
        /// <summary>
        /// Путь до файла
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="path"></param>
        public GetFilesAndDir(string path)
        {
            Path = path;
        }

        /// <summary>
        /// Создание списка для текущего пути
        /// </summary>
        /// <returns></returns>
        public List<Files> GetListCurrentDirectory()
        {
            List<Files> newTreeFiles = new List<Files>();
            try
            {
                string[] directories = Directory.GetDirectories(Path);
                string[] files = Directory.GetFiles(Path);
                foreach (var str in directories)
                {
                    string name = GetName(str);
                    newTreeFiles.Add(new Files(0, name, null, Path));
                }
                foreach (var str in files)
                {
                    FileInfo file = new FileInfo(str);
                    long size = file.Length;
                    string name = GetName(str);

                    newTreeFiles.Add(new Files(size, name, GetExtension(str), Path));
                }
                return newTreeFiles;
            }
            catch
            {
                return newTreeFiles;
            }
        }

        /// <summary>
        /// Получение имени
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string GetName(string str)
        {
            string name = str.Substring(str.LastIndexOf('\\') + 1);
            return name;
        }

        /// <summary>
        /// Получение расширения
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string GetExtension(string str)
        {
            string ext = str.Substring(str.LastIndexOf('.'));
            ext = ext.Replace(Path, "");
            return ext;
        }
    }
}
