using System;
using System.Linq;

namespace _09._Kamino_Factory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                char separator = '!';
                int sequLen = int.Parse(Console.ReadLine());
                int valueToSearchFor = 1;

                int[] bestDna = new int[sequLen];
                int bestSample = 1;
                int bestSeqLen = 1;
                int bestStartIndex = 0;
                int bestSum = 0;

                int subSequLen = 0;
                int startIndex = 0;
                int sample = 1;

                string input = Console.ReadLine();
                while (input != "Clone them!")
                {
                    subSequLen = 0;
                    startIndex = 0;

                    int[] arr = input.Split(separator).Select(int.Parse).ToArray();
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (arr[i] == valueToSearchFor)
                        {
                            int temSeqLen = 1;
                            for (int j = i + 1; j < arr.Length; j++)
                            {
                                if (arr[i] == arr[j])
                                {
                                    temSeqLen++;
                                    if (temSeqLen > subSequLen)
                                    {
                                        subSequLen = temSeqLen;
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
                    }

                    if (subSequLen > bestSeqLen)
                    {
                        bestSeqLen = subSequLen;
                        bestStartIndex = startIndex;
                        bestSample = sample;
                        arr.CopyTo(bestDna, 0);
                    }
                    else if (subSequLen == bestSeqLen && bestStartIndex > startIndex)
                    {
                        bestSeqLen = subSequLen;
                        bestStartIndex = startIndex;
                        bestSample = sample;
                        arr.CopyTo(bestDna, 0);
                    }
                    else if (subSequLen == bestSeqLen && bestStartIndex == startIndex)
                    {
                        int sum = 0;
                        for (int i = 0; i < arr.Length; i++)
                        {
                            sum += arr[i];
                            bestSum += bestDna[i];
                        }
                        if (sum > bestSum)
                        {
                            bestSeqLen = subSequLen;
                            bestStartIndex = startIndex;
                            bestSample = sample;
                            arr.CopyTo(bestDna, 0);
                        }
                    }

                    sample++;
                    input = Console.ReadLine();
                }

                bestSum = 0;
                for (int i = 0; i < bestDna.Length; i++)
                {
                    bestSum += bestDna[i];
                }
                Console.WriteLine($"Best DNA sample {bestSample} with sum: {bestSum}.");
                Console.WriteLine(String.Join(' ',bestDna));





            }
        }
    }
}
