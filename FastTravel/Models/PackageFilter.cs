namespace FastTravel.Models
{
    public class PackageFilter
    {
        public float? minPrice { get; set; }
        public float? maxPrice { get; set; }
        public int directOnly { get; set; }
        public DateTime dateSource { get; set; }
        public bool? sortingOrder { get; set; }
    }
}
