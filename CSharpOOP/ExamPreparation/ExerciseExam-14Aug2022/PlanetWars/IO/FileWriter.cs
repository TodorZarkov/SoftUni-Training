namespace PlanetWars.IO
{
    using IO.Contracts;
    using System.IO;

    internal class FileWriter : IWriter
    {
        string path = "../../../output.txt";

        public FileWriter()
        {
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                sw.Write("");
            }
        }

        public void Write(string message)
        {
            using (StreamWriter sw = new StreamWriter(path,true))
            {
                sw.Write(message);
            }
        }

        public void WriteLine(string message)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(message);
            }
        }
    }
}
