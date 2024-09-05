using DataContext.Entities;
using System.Threading.Tasks;

namespace DataContext.Repositories
{
    /// <summary>
    /// Интерфейс базового репозитория
    /// </summary>
    /// <typeparam name="T">Тип сущности</typeparam>
    public interface IBaseRepository<T> where T : IBaseEntity
    {
        /// <summary>
        /// Асинхронное создание сущности
        /// </summary>
        /// <param name="entity">Сущность для создания</param>
        /// <returns>Созданная сущность</returns>
        Task<T> CreateAsync(T entity);
        /// <summary>
        /// Асинхронное обновление сущности
        /// </summary>
        /// <param name="entity">Сущность для обновления</param>
        /// <returns>Обновленная сущность</returns>
        Task<T> UpdateAsync(T entity);
        /// <summary>
        /// Асинхронное удаление сущности
        /// </summary>
        /// <param name="entity">Сущность для удаления</param>
        /// <returns></returns>
        Task DeleteAsync(T entity);
        /// <summary>
        /// Асинхронное получение сущности
        /// </summary>
        /// <param name="id">Идентификационный номер сущности</param>
        /// <returns>сущность</returns>
        Task<T> GetAsync(int id);
        /// <summary>
        /// Вывод всех записей
        /// </summary>
        /// <param name="pageNumber">Номер страницы</param>
        /// <param name="pageSize">Количество элементов на странице</param>
        /// <param name="sortBy">Поле сортировки</param>
        /// <param name="isAscending">Направление сортировки</param>
        /// <returns></returns>
        Task<Pagination<T>> GetAllAsync(int pageNumber,  int pageSize, string sortBy, bool isAscending);
    }
}
