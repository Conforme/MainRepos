namespace Conforme.Models.Domain
{
    public class Qualifications
    {
        public Guid Id { get; set; }
        public string QualCode { get; set; } = string.Empty;
        public string QualName { get; set; } = string.Empty;
        public string RelNo { get; set; } = string.Empty;
        public string RelDetail { get; set; } = string.Empty;
        public string QualDetail { get; set; } = string.Empty;
        public string QualDepartment { get; set; } = string.Empty;
    }
}
