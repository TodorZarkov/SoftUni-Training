namespace Formula1.IO
{
    using Formula1.IO.Contracts;
    using System;
    using System.IO;

    public class FileWriter : IWriter
    {
        private string path = "../../../output.txt";


        public FileWriter()
        {
            using (var sw = new StreamWriter(path, false))
            {
                sw.Write("");
            }
        }
        
        public void Write(string message)
        {
            using (var sw = new StreamWriter(path,true))
            {
                 sw.Write(message);
            }

        }

        public void WriteLine(string message)
        {

            using (var sw = new StreamWriter(path,true))
            {
                sw.WriteLine(message);
            }
            
        }
    }
}
