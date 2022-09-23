using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarNow.Models
{
    public class Renting
    {
        public int RentingID { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }
        public bool IsValidate { get; set; }
        public DateTime PaymentDate { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }
        [StringLength(50)]
        public string TypeOfPayment { get; set; }
        public DateTime PlannedDuration { get; set; }
        public DateTime RealDuration { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal DailyPrice { get; set; }
        public int CarID { get; set; }
        public int Id { get; set; }

        public Car Car { get; set; }
        public User User { get; set; }
    }
}
