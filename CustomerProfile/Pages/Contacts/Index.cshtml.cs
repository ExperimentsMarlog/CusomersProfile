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
    public class IndexModel : BasePageModel
    {

        public IndexModel(
            CustomerProfile.Data.ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
        : base(context, authorizationService, userManager)            
        {
        }

        public IList<CustomerProfile.Models.Contacts> Contacts { get;set; }

        public async Task OnGetAsync()
        {
            Contacts = await _context.Contacts.Where(w=>w.OwnerID.Equals(_userManager.GetUserId(User))).ToListAsync();
        }
    }
}
