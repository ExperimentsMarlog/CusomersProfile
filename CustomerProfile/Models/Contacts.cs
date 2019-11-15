using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerProfile.Models
{
    public class Contacts
    {
        public int ContactsID { get; set; }

        // user ID from AspNetUser table.
        public string OwnerID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

    }
}
