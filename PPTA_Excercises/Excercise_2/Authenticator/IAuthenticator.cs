using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPTA_Excercises.Excercise_2.Authenticator
{
    public interface IAuthenticator
    {
        public bool Authenticate(string userName, string password);
    }
}
