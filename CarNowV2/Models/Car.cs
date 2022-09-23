using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarNow.Models
{
    public class Car
    {
        public int CarID { get; set; }
        [Required]
        [StringLength(50)]
        public string Brand { get; set; }
        [Required]
        [StringLength(50)]
        public string Model { get; set; }
        [Required]
        [StringLength(10)]
        public string Matriculation { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime MatriculationDate { get; set; }
        [Required]
        public int NbSeats { get; set; }
        [Required]
        public int NbDoors { get; set; }
        [Required]
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal DailyPrice { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public string Image { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        public int Id { get; set; }
        public int EnergyID { get; set; }

        public ICollection<Renting> Rentings { get; set; }
        public User User { get; set; }
        public ICollection<Category> Categorys { get; set; }
        public ICollection<Equipment> Equipments { get; set; }
        public Energy Energy { get; set; }
    }
}
