using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CustomerProfile.Data;
using CustomerProfile.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace CustomerProfile.Pages.Contacts
{
    public class CreateModel : BasePageModel
    {
        public CreateModel(
            CustomerProfile.Data.ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }


        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CustomerProfile.Models.Contacts Contacts { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Contacts.OwnerID = _userManager.GetUserId(User);
            _context.Contacts.Add(Contacts);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
