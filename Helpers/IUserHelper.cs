namespace Shop.Web.Helpers
{
    using System.Threading.Tasks;
    using Shop.Web.Data.Entities;
    using Microsoft.AspNetCore.Identity;
    using Models;

    public interface IUserHelper
    {
        Task<Users> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(Users user, string password);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();

        Task<IdentityResult> UpdateUserAsync(Users user);

        Task<IdentityResult> ChangePasswordAsync(Users user, string oldPassword, string newPassword);

        Task<SignInResult> ValidatePasswordAsync(Users user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(Users user, string roleName);

        Task<bool> IsUserInRoleAsync(Users user, string roleName);


    }

}
