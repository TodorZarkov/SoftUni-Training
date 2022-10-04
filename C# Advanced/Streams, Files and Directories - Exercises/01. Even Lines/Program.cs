namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StringBuilder result = new StringBuilder();
            using (var reader = new StreamReader(inputFilePath))
            {
                string line = reader.ReadLine();
                int lineCount = 0;
                while (line != null)
                {
                    if (lineCount % 2 == 0)
                    {
                        string revLine = string.Join(' ', line.Split(' ').Reverse().ToArray());
                        result.Append(revLine);
                        result.Append('\n');
                    }
                    lineCount++;

                    line = reader.ReadLine();
                }
            }
            string[] symbols = { "-", ",", ".", "!", "?" };
            foreach (var symbol in symbols)
            {
                result.Replace(symbol, "@");
            }
            return result.ToString();
        }
    }
}