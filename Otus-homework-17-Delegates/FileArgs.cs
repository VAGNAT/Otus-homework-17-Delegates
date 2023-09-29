using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus_homework_17_Delegates
{
    public class FileArgsEventArgs : EventArgs
    {
        public string? FileName { get; set; }

        public override string ToString()
        {
            return FileName!;
        }
    }
}
