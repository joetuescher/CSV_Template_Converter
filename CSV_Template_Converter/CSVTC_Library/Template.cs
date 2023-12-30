namespace CSVTC_Library
{
    public class Template
    {
        private string _filePath;
        public string FilePath
        {
            get
            {
                return _filePath;
            }
            set
            {
                _filePath = value;
                TemplateContent = File.ReadAllText(value);
            }
        }
        public string TemplateContent { get; set; }
        public Template(string path)
        {
            FilePath = path ?? throw new FileNotFoundException();
        }
        /// <summary>
        /// Reads the template again.
        /// </summary>
        /// <returns>Returns true, if the content has changed.</returns>
        public bool RefreshTemplate()
        {
            string oldTemplateContent = new(TemplateContent);
            TemplateContent = File.ReadAllText(FilePath);
            return TemplateContent != oldTemplateContent;
        }
    }
}