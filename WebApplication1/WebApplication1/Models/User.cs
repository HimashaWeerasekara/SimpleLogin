using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class User : IdentityUser
    {
        public string NIC { get; set; }
        public string PersonalAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [ForeignKey("Division")]
        public int? DivisionId { get; set; }
        public Division Division { get; set; }
    }
}
