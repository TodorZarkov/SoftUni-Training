using System;
using System.Text;

namespace _07._String_Explosion
{
    internal class Program
    {
        public static void Main()
        {
            char bomb = '>';
            string text = Console.ReadLine();
            int index = 0;
            StringBuilder explodedText = new StringBuilder();
            while (index < text.Length)
            {
                if (text[index] == bomb)
                {
                    int bombIndex = index;
                    int magnitude = int.Parse($"{text[bombIndex + 1]}");
                    int numberOfBombs = 1;
                    int nextBombIndex = bombIndex + 2;
                    while (nextBombIndex <= magnitude + bombIndex)
                    {
                        if (nextBombIndex >= text.Length)
                            break;
                        if (text[nextBombIndex] == bomb)
                        {
                            magnitude += int.Parse($"{text[nextBombIndex + 1]}");
                            numberOfBombs++;
                        }
                        nextBombIndex++;
                    }

                    index += magnitude + numberOfBombs;
                    explodedText.Append(bomb, numberOfBombs);
                }
                else
                {
                    explodedText.Append(text[index]);
                    index++;
                }

            }
            Console.WriteLine(explodedText);
        }
    }
}
