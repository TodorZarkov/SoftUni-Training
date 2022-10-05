namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            DirectoryInfo dir = new DirectoryInfo(inputFolderPath);
            Dictionary<string, int> extensions = new Dictionary<string, int>();
            dir.GetFiles().Aggregate(extensions, (prev, next) =>
            {
                if (!prev.ContainsKey(next.Extension)){
                    prev.Add(next.Extension,0);
                }
                prev[next.Extension]++;

                return extensions;
            });
            FileInfo[] files = dir.GetFiles().OrderByDescending(file => extensions[file.Extension]).ThenBy(file => file.Extension).ThenBy(file => file.Length).ToArray();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(files[0].Extension);
            for (int i = 0;i<files.Length-1; i++)
            {
                sb.AppendLine($"--{files[i].Name} - {(files[i].Length/1024.0).ToString("0.###")}kb");
                if (files[i+1].Extension != files[i].Extension)
                {
                    sb.AppendLine(files[i+1].Extension);
                }
            }
            sb.AppendLine($"--{files[files.Length-1].Name} - {(files[files.Length - 1].Length / 1024.0).ToString("0.###")}kb");



            return sb.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string DTPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            File.WriteAllText(DTPath + reportFileName, textContent);
        }
    }
}
