using System.ComponentModel.DataAnnotations;

namespace web_api.Models
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; } = "Mr.";
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public DateTime Dob { get; set; }
    }
}
