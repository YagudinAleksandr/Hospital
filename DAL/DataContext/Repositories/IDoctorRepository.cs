using DataContext.Entities;

namespace DataContext.Repositories
{
    /// <summary>
    /// Репозиторий докторов
    /// </summary>
    /// <typeparam name="T">Тип сущности</typeparam>
    public interface IDoctorRepository<T> : IBaseRepository<T> where T : IDoctor
    {
    }
}
