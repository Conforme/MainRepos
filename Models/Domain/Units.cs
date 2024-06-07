namespace Conforme.Models.Domain
{
    public class Units
    {
        public Guid Id { get; set; }
        public string UnitCode { get; set; } = string.Empty;
        public string UnitName { get; set; } = string.Empty;
        public string UnitRel { get; set; } = string.Empty;
        public string RelDescription { get; set; } = string.Empty;
        public string Application { get; set; } = string.Empty;
        public string PreReqCode { get; set; } = string.Empty;
        public string UnitSector { get; set; } = string.Empty;
        public string FoundationSkills { get; set; } = string.Empty;
        public string UnitMapInfo { get; set; } = string.Empty;
        public string Links { get; set; } = string.Empty;
        public double NomHours { get; set; } = double.MinValue;
        public string UnitType { get; set; } = string.Empty;
        public Guid QualID { get; set; }
        public Guid SiteID { get; set; }
        public string Notes { get; set; } = string.Empty;
        public string PreReqName { get; set; } = string.Empty;
        public string ApplicationAbr { get; set; } = string.Empty;
        public double NonSupervised { get; set; } = double.MinValue;
        public double Supervised { get; set; } = double.MinValue;
        public string CurYear { get; set; } = string.Empty;
        public string CurSemester { get; set; } = string.Empty;
        public string GrpName { get; set; } = string.Empty;
        public string ClusterName { get; set; } = string.Empty;
        public string StartDate { get; set; } = string.Empty;
        public string EndDate { get; set; } = string.Empty;
        public int PreRequisites { get; set; } = int.MinValue;
        public int FaceToFace { get; set; } = int.MinValue;
        public int Online { get; set; } = int.MinValue;
        public int Blended { get; set; } = int.MinValue;
        public int Flexible { get; set; } = int.MinValue;
        public int OnTheJob { get; set; } = int.MinValue;
        public int Placement { get; set; } = int.MinValue;
        public int TrainerId { get; set; } = int.MinValue;
        public int TrainerId2 { get; set; } = int.MinValue;
        public int SeniorEdId { get; set; } = int.MinValue;
        public int Administration { get; set; } = int.MinValue;
        public string LMSaddress { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string AssessedAs { get; set; } = string.Empty;
        public string LearningMaterials { get; set; } = string.Empty;
        public string Equipment { get; set; } = string.Empty;
        public string PPE { get; set; } = string.Empty;
        public string OtherEquipment { get; set; } = string.Empty;
        public string ThirdParty { get; set; } = string.Empty;
        public string Licensing { get; set; } = string.Empty;
        public string WHSConsiderations { get; set; } = string.Empty;
        public string OtherConsiderations { get; set; } = string.Empty;
        public int Admin2 { get; set; } = int.MinValue;
    }
}
