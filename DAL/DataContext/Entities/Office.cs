using System.Collections.Generic;

namespace DataContext.Entities
{
    /// <summary>
    /// Кабинет
    /// </summary>
    public class Office : IOffice
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
