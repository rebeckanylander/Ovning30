using Ovning30;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ContactsRepo repo = new ContactsRepo();
            Console.WriteLine("Visa kontaktlista? (J/N)");
            var response = Console.ReadLine();
            switch (response.ToUpper())
            {
                case "J":
                    var allContacts = repo.GetAllContacts();
                    foreach (var contact in allContacts)
                    {
                        Console.WriteLine(contact.ToString());
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
