using SalesApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Models
{
    public class RegisterViewModel
    {

        public string UserName { get; set; }
        public string Name { get; set; }

        public string Password { get; set; }

        public Profile Profile { get; set; }

    }
}
