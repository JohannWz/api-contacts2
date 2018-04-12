using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_contacts
{
    public class User
    {
        public long id { get; set; }
        public String name { get; set; }
        public String email { get; set; }
        public String password { get; set; }
    }
}
