namespace Far
{
    public class Files
    {
        /// <summary>
        /// Размер файла
        /// </summary>
        public float Size { get; set; }

        /// <summary>
        /// Имя файла
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Разрешение файла
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// Путь до файла или директории
        /// </summary>
        public string Path { get; set; }

        public Files(long size, string name, string extension, string path)
        {
            Size = size;
            Name = name;
            Extension = extension;
            Path = path;
        }
    }
}
