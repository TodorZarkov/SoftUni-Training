namespace _06._8QueensPuzzle
{
    using System;

    public class Program
    {
        //static int count = 1;
        const int rank = 8;
        static HashSet<int> attackRow = new(); 
        static HashSet<int> attackCol = new(); 
        static HashSet<int> attackLeftDiagonal = new(); 
        static HashSet<int> attackRightDiagonal = new();
        static bool[,] matrix = new bool[rank, rank];
        static void Main(string[] args)
        {
            
                QueensPosition(0);
            
        }

        static void QueensPosition(int row)
        {
            if (row > rank - 1)
            {
                PrintMatrix();
                return;
            }
           
           

            for (int col = 0; col < rank; col++)
            {
                if (!IsUnderAttack(row, col))
                {
                    matrix[row, col] = true;
                    SetUnderAttack(row, col);

                    QueensPosition(row + 1);

                    matrix[row, col] = false;
                    SetFree(row, col);
                }
                
            }

            

        }

        private static void SetFree(int row, int col)
        {
            attackCol.Remove(col);
            attackRow.Remove(row);
            attackLeftDiagonal.Remove(row - col);
            attackRightDiagonal.Remove(row + col);
        }

        private static void SetUnderAttack(int row, int col)
        {
            attackCol.Add(col);
            attackRow.Add(row);
            attackLeftDiagonal.Add(row - col);
            attackRightDiagonal.Add(row + col);
        }

        private static bool IsUnderAttack(int row, int col)
        {
            return (attackCol.Contains(col)||
            attackRow.Contains(row)||
            attackLeftDiagonal.Contains(row - col)||
            attackRightDiagonal.Contains(row + col));
        }

        private static void PrintMatrix()
        {
            char[] line = new char[rank];
            for (int i = 0; i < rank; i++)
            {
                for (int j = 0; j < rank; j++)
                {
                    line[j] = matrix[i, j] ? '*' : '-';
                }
                Console.WriteLine(string.Join(" ",line));
            }
            Console.WriteLine();//count++);
        }
    }
}