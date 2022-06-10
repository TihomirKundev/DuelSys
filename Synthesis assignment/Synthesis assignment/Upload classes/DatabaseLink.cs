using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthesisAssignment.Upload_classes
{
    internal class DatabaseLink
    {
        private const string link = "Server=studmysql01.fhict.local;Uid=dbi483777;Database=dbi483777;Pwd=tihomir27092002;";
        public string Link { get { return link; } }
    }
}
