using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CarNow.Models
{
    public class User : IdentityUser
    {

        [Required]
        [StringLength(50)]
        public string Firstname { get; set; }

        [Required]
        [StringLength(10)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        [Required]
        [StringLength(10)]
        public string Zipcode { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<Renting> Rentings { get; set; }
        public ICollection<Car> Cars { get; set; }

    }
}
