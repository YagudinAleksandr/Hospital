using DataContext.Entities;

namespace DataContext.Repositories
{
    /// <summary>
    /// Репозиторий пациентов
    /// </summary>
    /// <typeparam name="T">Тип сущности</typeparam>
    public interface IPatientRepository<T> : IBaseRepository<T> where T : IPatient
    {
    }
}
