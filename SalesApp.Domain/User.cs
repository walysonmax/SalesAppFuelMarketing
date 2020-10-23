using System;
using System.Collections.Generic;
using System.Text;

namespace SalesApp.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }


        public string Password { get; set; }

        public Profile Profile { get; set; }
    }
}
