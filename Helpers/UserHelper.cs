namespace Shop.Web.Helpers
{
    using System.Threading.Tasks;
    using Data.Entities;
    using Microsoft.AspNetCore.Identity;
    using Models;

    public class UserHelper : IUserHelper
    {
        private readonly UserManager<Users> userManager;
        private readonly SignInManager<Users> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserHelper(UserManager<Users> userManager, SignInManager<Users> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }


        public async Task<IdentityResult> AddUserAsync(Users user, string password)
        {
            return await this.userManager.CreateAsync(user, password);
        }

        public async Task<Users> GetUserByEmailAsync(string email)
        {
            var user = await this.userManager.FindByEmailAsync(email);
            return user;
        }

        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            return await this.signInManager.PasswordSignInAsync(
                model.Username,
                model.Password,
                model.RememberMe,
                false);
        }

        public async Task LogoutAsync()
        {
            await this.signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> UpdateUserAsync(Users user)
        {
            return await this.userManager.UpdateAsync(user);
        }

        public async Task<IdentityResult> ChangePasswordAsync(Users user, string oldPassword, string newPassword)
        {
            return await this.userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        }

        public async Task<SignInResult> ValidatePasswordAsync(Users user, string password)
        {
            return await this.signInManager.CheckPasswordSignInAsync(user, password,false);
        }

        public async Task CheckRoleAsync(string roleName)
        {
            var roleExists = await this.roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await this.roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName
                });
            }
        }

        public async Task AddUserToRoleAsync(Users user, string roleName)
        {
            await this.userManager.AddToRoleAsync(user, roleName);
        }

        public async Task<bool> IsUserInRoleAsync(Users user, string roleName)
        {
            return await this.userManager.IsInRoleAsync(user, roleName);
        }
    }



}
