namespace NZWalks.API.Model.Domain
{
    public class Region
    {
        public Guid Id { get; set; }

        // KPK => Khyber Pakhtunkhwa
        // KSA => Kingdom of Saudi Arabia
        // UAE => United Arab Emirates
        // All refers to the country name

        public string Code { get; set; }
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
