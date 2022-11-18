namespace Logger.Core.IO
{
    using System.Text;

    using Exceptions;
    using Interfaces;
    using Utilities;
    public class LogFile : ILogFile
    {
        private string? name;
        private string? path;

        private readonly StringBuilder content;

        private LogFile()
        {
            content = new StringBuilder();
        }

        public LogFile(string name, string path)
            : this()
        {
            Name = name;
            Path = path;
        }

        public string Name
        {
            get
            {
                return name!;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new EmptyFileNameException();
                }

                name = value;
            }
        }

        public string Path
        {
            get
            {
                return path;
            }
            private set
            {
                if (!Validation.FilePathExists(value))
                {
                    throw new InvalidPathException();
                }

                path = System.IO.Path.GetFullPath(value);
            }
        }

        public string FullPath
            => System.IO.Path.GetFullPath(Path + "/" + Name);

        public string Content
            => content.ToString();

        public int Size
            => content.Length;

        public void Write(string text)
        {
            content.Append(text);
        }

        public void WriteLine(string text)
        {
            content.AppendLine(text);
        }
    }
}
