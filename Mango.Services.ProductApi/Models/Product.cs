using System.ComponentModel.DataAnnotations;

namespace Mango.Services.ProductApi.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }=string.Empty;
        public double Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;//we will get it from external website 
        public string CategoryName { get; set; } = string.Empty;
        public string ImageLocalPath { get;  set; }
        
    }
}
