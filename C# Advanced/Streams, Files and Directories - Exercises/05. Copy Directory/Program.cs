namespace CopyDirectory
{
    using System;
    using System.IO;

    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath = @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath, true);
            }
            DirectoryInfo dir = new DirectoryInfo(inputPath);

            Directory.CreateDirectory(outputPath);

            var files = dir.GetFiles();
            foreach (var file in files)
            {
                string targetFilePath = Path.Combine(outputPath, file.Name);
                file.CopyTo(targetFilePath);
            }
            
        }
    }
}