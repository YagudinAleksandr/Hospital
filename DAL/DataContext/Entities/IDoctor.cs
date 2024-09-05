namespace DataContext.Entities
{
    public interface IDoctor : IBaseEntity
    {
        /// <summary>
        /// Идентификационный номер
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// ФИО врача
        /// </summary>
        public string Fullname { get; set; }
        /// <summary>
        /// кабинет
        /// </summary>
        public Office Office { get; set; }
        /// <summary>
        /// Специализация
        /// </summary>
        public Specialization Specialization { get; set; }
        /// <summary>
        /// Участок
        /// </summary>
        public Sector? Sector { get; set; }
    }
}
