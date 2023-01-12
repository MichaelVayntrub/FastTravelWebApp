namespace FastTravel.Models
{
    public class PackageFilter
    {
        public float? minPrice { get; set; }
        public float? maxPrice { get; set; }
        public bool directOnly { get; set; }
        public DateOnly? dateSource { get; set; }
        public bool? sortingOrder { get; set; }
    }
}
