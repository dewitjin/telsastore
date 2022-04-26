using System.ComponentModel.DataAnnotations;

namespace StoreAPI.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Country { get; set; } //'US' or 'CA'
        [Required]
        public string State { get; set; } //'BC' or 'ON'
        [Required]
        public string Zip { get; set; } //'V6G 3E2'
        [Required]
        public string Street { get; set; }
        public string City { get; set; }
        public decimal? TaxRate { get; set; }
    }
}
