using AuthDemo.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace AuthDemo.IManagers
{
    public interface IUserManager
    {
        Task<IdentityResult> CreateAsync(UserVM user);
    }
}