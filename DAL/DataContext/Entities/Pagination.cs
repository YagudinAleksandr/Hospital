using System.Collections.Generic;

namespace DataContext.Entities
{
    /// <summary>
    /// Модель постраничного вывода
    /// </summary>
    /// <typeparam name="T">Тип данных</typeparam>
    public class Pagination<T>
    {
        /// <summary>
        /// Элементы
        /// </summary>
        public IEnumerable<T> Items { get; set; }
        /// <summary>
        /// Всего элементов
        /// </summary>
        public int TotalItems { get; set; }
        /// <summary>
        /// Номер страницы
        /// </summary>
        public int PageNumber { get; set; }
        /// <summary>
        /// Количество элементов на странице
        /// </summary>
        public int PageSize { get; set; }
    }
}
