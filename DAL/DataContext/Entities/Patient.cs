using System;

namespace DataContext.Entities
{
    /// <summary>
    /// Пациент
    /// </summary>
    public class Patient : IPatient
    {
        public int Id { get; set; }
        public string Surename { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public string Sex { get; set; }
        public int SectorId { get; set; }
        public Sector Sector { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
