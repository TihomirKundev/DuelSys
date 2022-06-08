using Synthesis_assignment.Base_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthesis_assignment.Upload_classes
{
    public interface IUploadPeople
    {
        People Login(string email, string password, string type);
        People RegisterPlayer(People people);

    }
}
