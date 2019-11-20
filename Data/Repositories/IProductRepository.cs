using System.Linq;

namespace Shop.Web.Data
{
    using Entities;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;

    public interface IProductRepository : IGenericRepository<Product>
    {
        IQueryable GetAllWithUsers();

        IEnumerable<SelectListItem> GetComboProducts();
    }
}
