using Microsoft.EntityFrameworkCore;
using Radzen;
using TriviaBiblicoUNAD2024.Data;
using TriviaBiblicoUNAD2024.Data.Modelos.Equipos;
using TriviaBiblicoUNAD2024.Servicios.Interfaces;

namespace TriviaBiblicoUNAD2024.Servicios.Equipos
{
    public class EquipoService : IDataEngineService<EquipoModel>
    {
        private readonly IDbContextFactory<ApplicationDbContext> dbContextFactory;

        public EquipoService(IDbContextFactory<ApplicationDbContext> _dbContextFactory)
        {
            dbContextFactory=_dbContextFactory;
        }

        public IQueryable<EquipoModel> GetQueriable { 
            get {
                ApplicationDbContext DbContext = dbContextFactory.CreateDbContext();
                return DbContext.Equipos.AsQueryable();
            } 
        }

        public async Task<int> CreateAsync(EquipoModel? entity)
        {
            ApplicationDbContext DbContext = await dbContextFactory.CreateDbContextAsync();
            if (entity is not null)
            {
                await DbContext.Equipos.AddAsync(entity);
                return await DbContext.SaveChangesAsync();
            }

            return  await Task.FromResult(0);
        }

        public async Task<int> DeleteAsync(EquipoModel? entity)
        {
            ApplicationDbContext DbContext = await dbContextFactory.CreateDbContextAsync();
            if (entity is not null)
            {
                DbContext.Equipos.Remove(entity);
                return await DbContext.SaveChangesAsync();
            }

            return await Task.FromResult(0);
        }

        public async Task<int> DeleteAsync(IEnumerable<EquipoModel>? entities)
        {
            ApplicationDbContext DbContext = await dbContextFactory.CreateDbContextAsync();
            if (entities is not null && entities.Count() > 0)
            {
                DbContext.Equipos.RemoveRange(entities);
                return await DbContext.SaveChangesAsync();
            }

            return await Task.FromResult(0);
        }

        public async Task<int> DeleteAsync(int? Id)
        {
            ApplicationDbContext DbContext = await dbContextFactory.CreateDbContextAsync();
            if (Id is not null)
            {
                return await DbContext.Equipos
                    .Where(e => e.Id == Id)
                    .ExecuteDeleteAsync();
            }

            return await Task.FromResult(0);
        }

        public async Task<int> DeleteAsync(IEnumerable<int>? ids)
        {
            ApplicationDbContext DbContext = await dbContextFactory.CreateDbContextAsync();
            if (ids is not null && ids.Count() > 0)
            {
                return await DbContext.Equipos
                    .Where(e => ids.Contains(e.Id))
                    .ExecuteDeleteAsync();
            }

            return await Task.FromResult(0);
        }

        public async Task<ICollection<EquipoModel>> GetAllAsync()
        {
            ApplicationDbContext DbContext = await dbContextFactory.CreateDbContextAsync();
            return await DbContext.Equipos.ToListAsync();
        }

        public async Task<EquipoModel?> GetByIdAsync(int? id)
        {
            ApplicationDbContext DbContext = await dbContextFactory.CreateDbContextAsync();
            if (id is not null)
            {
                return await DbContext.Equipos.FindAsync(id);
            }

            return null;
        }

        public async Task<ICollection<EquipoModel?>> GetByIdAsync(IEnumerable<int>? ids)
        {
            ApplicationDbContext DbContext = await dbContextFactory.CreateDbContextAsync();
            if (ids is not null && ids.Count() > 0)
            {
                return await DbContext.Equipos.Where(x => ids.Contains(x.Id)).ToListAsync();
            }

            return Enumerable.Empty<EquipoModel>().ToArray();
        }

        public async Task<int> UpdateAsync(int? Id, EquipoModel? entity)
        {
            ApplicationDbContext DbContext = await dbContextFactory.CreateDbContextAsync();
            if (Id is not null && entity is not null)
            {
                if (Id == entity.Id)
                {
                    DbContext.Equipos.Update(entity);
                    return await DbContext.SaveChangesAsync();
                }
            }

            return await Task.FromResult(0);
        }
    }
}
