using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolio.Models.ViewModels
{
    public class UserViewModel
    {
        public IEnumerable<IdentityUser> Users;
    }
}
