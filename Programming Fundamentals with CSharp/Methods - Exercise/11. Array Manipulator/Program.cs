using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int[] arr = { 10, 8, 6, 4, 2 };

        // if (Exchange(arr, 4))
        // {
        //     System.Console.WriteLine(string.Join(' ', arr));
        // }
        // else
        // {
        //     System.Console.WriteLine("Invalid index"); ;
        // }

        //System.Console.WriteLine(MaxEven(arr));
        LastNEven(5, arr);

    }

    //    • exchange {index} – splits the array after the given index and 
    //exchanges the places of the two resulting sub-arrays. E.g. 
    //[1, 2, 3, 4, 5] -> exchange 2 -> result: [4, 5, 1, 2, 3]
    // ◦ If the index is outside the boundaries of the array, print "Invalid index"
    public static bool Exchange(int[] arr, int splitInd)
    {
        if (splitInd >= arr.Length - 1)
            return false;
        int off = arr.Length - splitInd;
        for (int i = 0; i < off; i++)
        {
            RotateOneRight(arr);
        }
        return true;
    }

    public static void RotateOneRight(int[] arr)
    {
        int tmp = arr[0];
        for (int i = 0; i < arr.Length - 1; i++)
        {
            arr[i] = arr[i + 1];
        }
        arr[arr.Length - 1] = tmp;
    }

    //If a min/max even/odd element cannot be found, print "No matches"
    //if -1 is returned = no matches
    //if equal ret. right-max
    public static int MaxEven(int[] arr)
    {
        int maxEl = arr[0];
        int maxIndex = -1;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] % 2 == 0) //not equ. if odd
            {
                if (arr[i] > maxEl) // less if Min
                {
                    maxEl = arr[i];
                    maxIndex = i;
                }
                else if (arr[i] == maxEl && i > maxIndex)
                {
                    maxIndex = i;
                }
            }
        }
        if (maxIndex != -1)
            return maxIndex;

        return -1;
    }

    public static int MaxOdd(int[] arr)
    {
        int maxEl = arr[0];
        int maxIndex = -1;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] % 2 != 0) //not equ. if odd
            {
                if (arr[i] > maxEl) // less if Min
                {
                    maxEl = arr[i];
                    maxIndex = i;
                }
                else if (arr[i] == maxEl && i > maxIndex)
                {
                    maxIndex = i;
                }
            }
        }
        if (maxIndex != -1)
            return maxIndex;

        return -1;
    }

    public static int MinEven(int[] arr)
    {
        int minEl = arr[0];
        int minIndex = -1;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] % 2 == 0) //not equ. if odd
            {
                if (arr[i] < minEl) // less if Min
                {
                    minEl = arr[i];
                    minIndex = i;
                }
                else if (arr[i] == minEl && i > minIndex)
                {
                    minIndex = i;
                }
            }
        }
        if (minIndex != -1)
            return minIndex;

        return -1;
    }

    public static int MinOdd(int[] arr)
    {
        int minEl = arr[0];
        int minInxex = -1;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] % 2 != 0) //not equ. if odd
            {
                if (arr[i] < minEl) // less if Min
                {
                    minEl = arr[i];
                    minInxex = i;
                }
                else if (arr[i] == minEl && i > minInxex)
                {
                    minInxex = i;
                }
            }
        }
        if (minInxex != -1)
            return minInxex;

        return -1;
    }


    //first {count} even/odd – returns the first {count} elements -> 
    //[1, 8, 2, 3] -> first 2 even -> print [8, 2]
    // • last {count} even/odd – returns the last {count} elements -> 
    //[1, 8, 2, 3] -> last 2 odd -> print [1, 3]
    //     ◦ If the count is greater than the array length, 
    //print "Invalid count"
    //     ◦ If there are not enough elements to satisfy the count, 
    //print as many as you can. If there are zero even/odd elements, print an empty array "[]"
    public static void FirstNEven(int n, int[] arr)
    {
        if (n > arr.Length)
        {
            System.Console.WriteLine("Invalid count");
            return;
        }

        string output = string.Empty;
        int countEvens = 0;
        for (int i = 0; i < arr.Length; i++)
        {


            if (arr[i] % 2 == 0) // if odd - not equal.
            {
                countEvens++;
                output += arr[i] + ", ";
                if (countEvens == n)
                {
                    output = output.Trim();
                    output = output.Trim(',');
                    output = "[" + output + "]";
                    System.Console.WriteLine(output);
                    return;
                }
            }
        }
        output = output.Trim();
        output = output.Trim(',');
        output = "[" + output + "]";
        System.Console.WriteLine(output);

    }

    public static void FirstNOdd(int n, int[] arr)
    {
        if (n > arr.Length)
        {
            System.Console.WriteLine("Invalid count");
            return;
        }

        string output = string.Empty;
        int countEvens = 0;
        for (int i = 0; i < arr.Length; i++)
        {


            if (arr[i] % 2 != 0) // if odd - not equal.
            {
                countEvens++;
                output += arr[i] + ", ";
                if (countEvens == n)
                {
                    output = output.Trim();
                    output = output.Trim(',');
                    output = "[" + output + "]";
                    System.Console.WriteLine(output);
                    return;
                }
            }
        }
        output = output.Trim();
        output = output.Trim(',');
        output = "[" + output + "]";
        System.Console.WriteLine(output);

    }


    public static void LastNEven(int n, int[] arr)
    {
        if (n > arr.Length)
        {
            System.Console.WriteLine("Invalid count");
            return;
        }

        string output = string.Empty;
        int countEvens = 0;
        for (int i = arr.Length - 1; i >= 0; i--)
        {


            if (arr[i] % 2 == 0) // if odd - not equal.
            {
                countEvens++;
                output += arr[i] + " ";
                if (countEvens == n)
                {
                    output = output.Trim();
                    int[] tempOut1 = output.Split(' ').Select(int.Parse).ToArray();
                    tempOut1.Reverse();
                    output = string.Join(", ", tempOut1);
                    output = "[" + output + "]";
                    System.Console.WriteLine(output);
                    return;
                }
            }
        }
        output = output.Trim();
        int[] tempOut = output.Split(' ').Select(int.Parse).ToArray();
        tempOut.Reverse();
        output = string.Join(", ", tempOut);
        output = "[" + output + "]";
        System.Console.WriteLine(output);
    }





    public static string ReverseString(string s)
    {
        s = string.Join("", s.Reverse());
        return s;
    }

}
