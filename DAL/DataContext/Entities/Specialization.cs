using System.Collections.Generic;

namespace DataContext.Entities
{
    /// <summary>
    /// Специализация
    /// </summary>
    public class Specialization: ISpecialization
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
