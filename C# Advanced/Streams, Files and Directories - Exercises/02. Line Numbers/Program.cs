namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class LineNumbers
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }
        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] lines = File.ReadAllLines(inputFilePath);
            StringBuilder sb = new StringBuilder();
            Regex lettersRx = new Regex(@"\w");
            Regex marksRx = new Regex(@"\p{P}");
            for (int i = 0;i<lines.Length;i++)
            {
                int letters = lettersRx.Matches(lines[i]).Count;
                int marks = marksRx.Matches(lines[i]).Count;
                sb.AppendLine($"Line {i + 1}: {lines[i]} ({letters})({marks})");
            }
            File.WriteAllText(outputFilePath, sb.ToString());
        }
    }
}