namespace Conforme.Models.Domain
{
    public class AssessTasks
    {

        public Guid Id { get; set; }
        public Guid UnitId { get; set; }
        public int AssessNumber { get; set; } = int.MinValue;
        public string AssessOf { get; set; } = string.Empty;
        public string AssessName { get; set; } = string.Empty;
        public string AssessMethod { get; set; } = string.Empty;
        public string DueDate { get; set; } = string.Empty;
        public string SemYear { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public string CRN_Number { get; set; } = string.Empty;
        public string TaskAbrev { get; set; } = string.Empty;
        public int NumQuestions { get; set; } = int.MinValue;
        public string TextNumQuestions { get; set; } = string.Empty;
        public string Equipment_Learner { get; set; } = string.Empty;
        public string Equipment_Assessor { get; set; } = string.Empty;
        public string MappingEvidence { get; set; } = string.Empty;
        public string UnitNameAbrev { get; set; } = string.Empty;
    }
}
