using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CustomerProfile.Data;
using CustomerProfile.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace CustomerProfile.Pages.Contacts
{
    [Authorize]
    public class DetailsModel : BasePageModel
    {

        public DetailsModel(
            CustomerProfile.Data.ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }

        public CustomerProfile.Models.Contacts Contacts { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Contacts = await _context.Contacts.FirstOrDefaultAsync(m => m.ContactsID == id);

            if (Contacts == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
