using System;
using System.Linq;

namespace _07._Max_Sequence_of_Equal_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char separator = ' ';
            int[] arr = Console.ReadLine().Split(separator).Select(int.Parse).ToArray();
            int sequenceLen = 1;
            int startIndex = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int temSeqLen = 1;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        temSeqLen++;
                        if (temSeqLen > sequenceLen)
                        {
                            sequenceLen = temSeqLen;
                            startIndex = i;
                        }
                    }
                    else
                    {
                        i = j - 1;
                        break;
                    }
                    
                }


            }
            for (int i = startIndex; i < startIndex+sequenceLen; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}
