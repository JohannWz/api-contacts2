using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_contacts
{
    public class Connexion
    {
        public string email;
        public string password;

        public Connexion(String e, String p)
        {
            email = e;
            password = p;
        }
    }
}
