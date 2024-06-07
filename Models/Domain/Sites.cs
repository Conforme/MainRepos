namespace Conforme.Models.Domain
{
    public class Sites
    {
        public Guid Id { get; set; }
        public string SiteName { get; set; } = string.Empty;
        public string StreetName1 { get; set; } = string.Empty;
        public string StreetName2 { get; set; } = string.Empty;
        public string Suburb { get; set; } = string.Empty;
        public int Postcode { get; set; } = int.MinValue;
        public string SitePhone { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
    }
}
