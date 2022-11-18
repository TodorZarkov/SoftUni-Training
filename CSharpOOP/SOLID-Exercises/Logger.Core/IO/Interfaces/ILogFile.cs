namespace Logger.Core.IO.Interfaces
{

    public interface ILogFile
    {
        public string Name { get; }

        public string Path { get; }

        public string FullPath { get; }

        public string Content { get; }

        public int Size { get; }


        public void Write(string logMessage);

    }
}
