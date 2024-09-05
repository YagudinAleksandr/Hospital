namespace DataContext.Entities
{
    public interface IOffice : IBaseEntity
    {
        /// <summary>
        /// Название кабинета
        /// </summary>
        public string Name { get; set; }
    }
}
