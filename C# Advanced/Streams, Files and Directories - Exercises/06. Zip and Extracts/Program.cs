namespace ZipAndExtract
{
    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;

    public class ZipAndExtract
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\tozip";
            string zipArchiveFilePath = @"..\..\..\zippedCopy.zip";
            string outputFilePath = @"..\..\..\";
            string outFileName = "extracted.png";
            ZipFileToArchive(inputFilePath, zipArchiveFilePath);
            ExtractFileFromArchive(zipArchiveFilePath, outFileName, outputFilePath);

        }

        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        {
            ZipFile.CreateFromDirectory(inputFilePath, zipArchiveFilePath, CompressionLevel.Fastest, false);
            

        }

        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
        {
            //ZipFile.ExtractToDirectory(zipArchiveFilePath, Path.Combine(outputFilePath,fileName));
            var arch = ZipFile.OpenRead(zipArchiveFilePath);
            arch.Entries.First().ExtractToFile(Path.Combine(outputFilePath, fileName));
        }
    }
}