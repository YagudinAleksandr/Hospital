namespace DataContext.Entities
{
    /// <summary>
    /// Врач
    /// </summary>
    public class Doctor : IDoctor
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public int OfficeId { get; set; }
        public Office Office { get; set; }
        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; }
        public int SectorId { get; set; }
        public Sector Sector { get; set; }
    }
}
