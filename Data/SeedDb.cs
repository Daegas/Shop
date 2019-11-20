namespace Shop.Web.Data
{
    using Entities;
    using Microsoft.AspNetCore.Identity;
    using Shop.Web.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private Random random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            //Create roles
            await this.userHelper.CheckRoleAsync("Admin");
            await this.userHelper.CheckRoleAsync("Customer");
            //Validate Cities and Countries
            
            // Add user
            var user = await this.userHelper.GetUserByEmailAsync("jzuluaga55@gmail.com");
            if (user == null)
            {
                user = new Users
                {
                    FirstName = "Juan",
                    LastName = "Zuluaga",
                    Email = "jzuluaga55@gmail.com",
                    UserName = "jzuluaga55@gmail.com",
                    PhoneNumber = "3506342747"
                };

                var result = await this.userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }

                await this.userHelper.AddUserToRoleAsync(user, "Admin");
            }

            
            //
            var isInRole = await this.userHelper.IsUserInRoleAsync(user, "Admin");
            if (!isInRole)
            {
                await this.userHelper.AddUserToRoleAsync(user, "Admin");
            }
            // Add products
            if (!this.context.Products.Any())
            {
                this.AddProduct("iPhone X", user);
                this.AddProduct("Magic Mouse", user);
                this.AddProduct("iWatch Series 4", user);
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, Users user)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(1000),
                IsAvailabe = true,
                Stock = this.random.Next(100),
                User = user
            });
        }
    }



}
