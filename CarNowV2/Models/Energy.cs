namespace CarNow.Models
{
    public class Energy
    {
        public int EnergyID { get; set; }
        public string Name { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
