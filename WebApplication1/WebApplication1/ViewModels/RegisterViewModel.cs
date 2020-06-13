using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class RegisterViewModel
    {
        public string NIC { get; set; }
        public string PersonalAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public bool RegisterAsFarmer { get; set; } = true;
        public int DivisionId { get; set; }
    }
}
