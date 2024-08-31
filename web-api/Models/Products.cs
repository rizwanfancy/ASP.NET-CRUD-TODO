using System.ComponentModel.DataAnnotations;

namespace web_api.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ProductName { get; set; }
        public string Price { get; set; }
        public string Expiry { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
