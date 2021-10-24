using System.ComponentModel.DataAnnotations;

namespace Services.Product.API.Models
{
    public class Products
    {
        // These bindings are called Data annotations 
        // More info here: https://www.infoworld.com/article/3543302/how-to-use-data-annotations-in-csharp.html 
        [Key]
        public int ProductID {  get; set; }
        [Required]
        public string Name {  get; set; }
        [Range(1,1000)]
        public double Price { get; set; }
        public string Description {  get; set; }    
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
