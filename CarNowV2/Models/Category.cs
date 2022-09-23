namespace CarNow.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
