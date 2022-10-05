namespace CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using (FileStream readStream = new FileStream(inputFilePath, FileMode.Open))
            {
                using (FileStream writeStream = new FileStream(outputFilePath, FileMode.Create))
                {

                    byte[] buffer = new byte[1];
                    while (readStream.Read(buffer) != 0)
                    {
                        writeStream.Write(buffer);
                    }
                }
            }
        }
    }
}