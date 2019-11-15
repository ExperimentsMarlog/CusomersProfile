using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerProfile.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace CustomerProfile.Pages.Contacts
{
    public class BasePageModel : PageModel
    {
        protected ApplicationDbContext _context { get; }
        protected IAuthorizationService _authorizationService { get; }
        protected UserManager<IdentityUser> _userManager { get; }

        public BasePageModel(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager) : base()
        {
            _context = context;
            _userManager = userManager;
            _authorizationService = authorizationService;
        }
    }
}
