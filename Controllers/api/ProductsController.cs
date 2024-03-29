﻿namespace Shop.Web.Controllers.api
{
    using Data;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    [Route("api/[Controller]")]
    [Authorize(AuthenticationSchemes= JwtBearerDefaults.AuthenticationScheme)]
    public class ProductsController : Controller
    {
        private readonly IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return this.Ok(this.productRepository.GetAllWithUsers());
        }

        /*
        public IQueryable GetAllWithUsers()
        {
            return this.context.Products.Include(p => p.User).OrderBy(p => p.Name);
        }
        */
    }

}
