using System.Collections.Generic;

namespace DataContext.Entities
{
    /// <summary>
    /// Участки
    /// </summary>
    public class Sector : ISector
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
