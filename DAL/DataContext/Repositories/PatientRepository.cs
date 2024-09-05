using DataContext.Context;
using DataContext.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DataContext.Repositories
{
    public class PatientRepository<T> : IPatientRepository<T> where T : Patient
    {
        #region Поля и свойства
        private readonly DataDB db;
        protected DbSet<T> Set { get; set; }
        protected virtual IQueryable<T> Items => Set;
        #endregion

        public PatientRepository(DataDB db)
        {
            this.db = db;
            this.Set = db.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            if(entity == null) 
                throw new ArgumentNullException(nameof(entity));

            var sector = await db.Sectors.FirstOrDefaultAsync(s => s.Id == entity.SectorId);

            entity.CreatedAt = DateTime.Now;
            entity.Sector = sector;

            await db.AddAsync(entity).ConfigureAwait(false);
            await db.SaveChangesAsync().ConfigureAwait(false);

            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            if(entity == null) 
                throw new ArgumentNullException( nameof(entity));

            db.Entry(entity).State = EntityState.Deleted;

            await db.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<T> GetAsync(int id) => 
            await Items.Include(item => item.Sector).FirstOrDefaultAsync(item => item.Id == id).ConfigureAwait(false);

        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var sector = await db.Sectors.FirstOrDefaultAsync(s => s.Id == entity.SectorId);

            entity.UpdatedAt = DateTime.Now;
            entity.Sector = sector;

            db.Entry(entity).State = EntityState.Modified;

            await db.SaveChangesAsync().ConfigureAwait(false);

            return entity;
        }

        public async Task<Pagination<T>> GetAllAsync(int pageNumber, int pageSize, string sortBy, bool isAscending)
        {
            if (pageNumber <= 0)
                throw new ArgumentOutOfRangeException(nameof(pageNumber));

            if (pageSize <= 0)
                throw new ArgumentOutOfRangeException(nameof(pageSize));

            IQueryable<T> query = Items
                .Include(item => item.Sector);

            query = sortBy switch
            {
                "Surename" => isAscending ? query.OrderBy(d => d.Surename) : query.OrderByDescending(d => d.Surename),
                "Name" => isAscending ? query.OrderBy(d => d.Name) : query.OrderByDescending(d => d.Name),
                "Patronymic" => isAscending ? query.OrderBy(d => d.Patronymic) : query.OrderByDescending (d => d.Patronymic),
                "Birthday" => isAscending ? query.OrderBy(d => d.Birthday) : query.OrderByDescending(d => d.Birthday),
                "Sex" => isAscending ? query.OrderBy(d => d.Sex) : query.OrderByDescending(d => d.Sex),
                "Sector" => isAscending ? query.OrderBy(d => d.Sector.Name) : query.OrderByDescending(d => d.Sector.Name),
                _ => query.OrderBy(d => d.Surename), // Сортировка по умолчанию
            };

            var totalItems = await query.CountAsync();

            var doctors = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new Pagination<T>
            {
                Items = doctors,
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
    }
}
