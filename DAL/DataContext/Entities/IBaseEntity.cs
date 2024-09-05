namespace DataContext.Entities
{
    /// <summary>
    /// Базовая сущность
    /// </summary>
    public interface IBaseEntity
    {
        /// <summary>
        /// Идентификационный номер
        /// </summary>
        int Id { get; set; }
    }
}
