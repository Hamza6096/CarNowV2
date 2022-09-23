namespace CarNow.Models
{
    public class Equipment
    {
        public int EquipmentID { get; set; }
        public string Name { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
