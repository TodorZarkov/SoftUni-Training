namespace NavalVessels.IO
{
    using NavalVessels.IO.Contracts;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

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
