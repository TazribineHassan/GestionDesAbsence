using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDesAbsence.Services
{
    public interface ILoginService
    {
        object Login(string email, string password, string userType);
    }
}
