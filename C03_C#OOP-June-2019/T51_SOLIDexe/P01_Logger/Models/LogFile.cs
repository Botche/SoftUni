using System;
using System.IO;
using System.Linq;
using System.Text;

namespace P01_Logger.Models
{
    public class LogFile
    {
        private const string path = "log.txt";
        private StringBuilder sb;
        public LogFile(string path = path)
        {
            this.sb = new StringBuilder();
            File.WriteAllText(path, string.Empty);
        }

        public int Size => this.sb.ToString()
            .Where(c => c >= 'a' && c <= 'z' ||
                        c >= 'A' && c <= 'Z')
            .Sum(c => c);

        public void Write(string message)
        {
            sb.AppendLine(message);

            File.AppendAllText(path, message + Environment.NewLine);
        }
    }
}
