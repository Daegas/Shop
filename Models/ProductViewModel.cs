namespace Shop.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    using Data.Entities;
    using Microsoft.AspNetCore.Http;

    public class ProductViewModel : Product
    {
        internal string file;

        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }
    }


}
