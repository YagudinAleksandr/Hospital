using DataContext.Context;
using DataContext.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DataContext.Repositories
{
    public class DoctorRepository<T> : IDoctorRepository<T> where T : Doctor, new()
    {
        #region Поля и свойства
        private readonly DataDB db;
        protected DbSet<T> Set { get; set; }
        protected virtual IQueryable<T> Items => Set;
        #endregion

        public DoctorRepository(DataDB db)
        {
            this.db = db;
            this.Set = db.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var office = await db.Offices.FirstOrDefaultAsync(o => o.Id == entity.OfficeId);
            var specialization = await db.Specializations.FirstOrDefaultAsync(s => s.Id == entity.SpecializationId);
            var sector = await db.Sectors.FirstOrDefaultAsync(s => s.Id == entity.SectorId);

            entity.Office = office;
            entity.Sector = sector;
            entity.Specialization = specialization;

            await db.AddAsync(entity).ConfigureAwait(false);
            await db.SaveChangesAsync().ConfigureAwait(false);

            return entity;

        }

        public async Task DeleteAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            db.Entry(entity).State = EntityState.Deleted;
            await db.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<T> GetAsync(int id) 
        {
            return await Items
                .Include(item => item.Office)
                .Include(item => item.Sector)
                .Include(item => item.Specialization)
                .FirstOrDefaultAsync(item => item.Id == id).ConfigureAwait(false);
        }
            

        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var office = await db.Offices.FirstOrDefaultAsync(o => o.Id == entity.OfficeId);
            var specialization = await db.Specializations.FirstOrDefaultAsync(s => s.Id == entity.SpecializationId);
            var sector = await db.Sectors.FirstOrDefaultAsync(s => s.Id == entity.SectorId);

            entity.Office = office;
            entity.Sector = sector;
            entity.Specialization = specialization;

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
                .Include(item => item.Office)
                .Include(item => item.Sector)
                .Include(item => item.Specialization);

            query = sortBy switch
            {
                "Fullname" => isAscending ? query.OrderBy(d => d.Fullname) : query.OrderByDescending(d => d.Fullname),
                "Office" => isAscending ? query.OrderBy(d => d.Office.Name) : query.OrderByDescending(d => d.Office.Name),
                "Specialization" => isAscending ? query.OrderBy(d => d.Specialization.Name) : query.OrderByDescending(d => d.Specialization.Name),
                "Sector" => isAscending ? query.OrderBy(d => d.Sector.Name) : query.OrderByDescending(d => d.Sector.Name),
                _ => query.OrderBy(d => d.Fullname), // Сортировка по умолчанию
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
