using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthesis_assignment.Upload_classes
{
    internal class DatabaseLink
    {
        private const string link = "Server=tcp:mymarket.database.windows.net,1433;Initial Catalog=Synthesis;Persist Security Info=False;User ID=TihomirKandev;Password=Tihomir27092002;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public string Link { get { return link; } }
    }
}
