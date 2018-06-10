using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakeryStore.Models
{
    public class NewPerson
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }
}