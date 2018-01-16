using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ovning30
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string SSN { get; set; }

        public override string ToString()
        {
            return $"{Id}: {Name}, {PhoneNumber}, {SSN}";
        }
    }
}