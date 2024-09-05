namespace DataContext.Entities
{
    public interface ISpecialization : IBaseEntity
    {
        /// <summary>
        /// Название специализации
        /// </summary>
        public string Name { get; set; }
    }
}
