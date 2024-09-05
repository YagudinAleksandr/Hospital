using System;

namespace DataContext.Entities
{
    public interface IPatient : IBaseEntity
    {
        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surename { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic { get; set; }
        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// Пол
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// Участок
        /// </summary>
        public Sector Sector { get; set; }
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTimeOffset CreatedAt { get; set; }
        /// <summary>
        /// Дата изменения
        /// </summary>
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
