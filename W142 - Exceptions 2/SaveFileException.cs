using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace W142___Exceptions_2
{
    public class SaveFileException : Exception
    {
        public override string Message { get; }

        public SaveFileException(string message, string fileName) : base(message)
        {
            Message = FileType(fileName) + message;
        }

        private string FileType(string saveFilename) => "." + saveFilename.Split('.').Last() + " ";
    }
}
