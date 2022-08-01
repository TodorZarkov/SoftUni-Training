using System;
using System.Text;

namespace _07._String_Explosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder explodedText = new StringBuilder();
            string text = Console.ReadLine();
            const char bomb = '>';
            int bombIndex = text.IndexOf(bomb);
            int magnitude = (int)text[bombIndex + 1] - 48;
            AddCharsFromString(explodedText, text, 0, bombIndex);
            while (bombIndex != -1)
            {
                int nextBombIndex = text.IndexOf(bomb);
                while (nextBombIndex > bombIndex)
                {
                    bombIndex = nextBombIndex;
                    explodedText.Append(bomb);
                    nextBombIndex = text.IndexOf(bomb);
                }
                bombIndex = text.IndexOf(bomb);
            }
        }
        static void AddCharsFromString(StringBuilder sb, string text, int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                sb.Append(text[i]);
            }
        }
    }
}
