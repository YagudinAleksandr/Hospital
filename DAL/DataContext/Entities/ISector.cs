using System;

namespace DataContext.Entities
{
    public interface ISector : IBaseEntity
    {
        /// <summary>
        /// Номер участка
        /// </summary>
        public String Name { get; set; }
    }
}
