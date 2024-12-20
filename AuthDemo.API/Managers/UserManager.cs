using AuthDemo.Constants;
using AuthDemo.Domain;
using AuthDemo.IManagers;
using AuthDemo.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace AuthDemo.Managers
{
    public class UserManager : IUserManager
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserManager(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateAsync(UserVM user)
        {
            ApplicationUser newUser = new()
            {
                Name = user.Name,
                Email = user.Email,
                UserName = user.UserName,
                PhoneNumber = user.Phone
            };

            var result = await _userManager.CreateAsync(newUser, user.Password);
            if(!result.Succeeded) {
                return result;
            } 
            
            await _userManager.AddToRoleAsync(newUser, RoleConstants.ADMIN);

            return result;
        }
    }
}