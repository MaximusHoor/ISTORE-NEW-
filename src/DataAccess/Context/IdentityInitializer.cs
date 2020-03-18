using Domain.EF_Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class IdentityInitializer
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IdentityInitializer(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task SeedAsync()
        {
            var login = "admin@mail.ru";
            var pass = "qwerty";
  
            if ((await _userManager.FindByEmailAsync(login)) == null)
            {
                var user = new User() { UserName=login, Email = login };
                var saveuser = await _userManager.CreateAsync(user, pass);
                if (saveuser.Succeeded)
                {
                    if ((await _roleManager.FindByNameAsync("admin")) == null)
                    {
                        var saverole = await _roleManager.CreateAsync(new IdentityRole("admin"));
                        if (saverole.Succeeded)
                        {
                            await _userManager.AddToRoleAsync(user, "admin");
                        }
                    }
                }
               
            }
        }

    }
}
