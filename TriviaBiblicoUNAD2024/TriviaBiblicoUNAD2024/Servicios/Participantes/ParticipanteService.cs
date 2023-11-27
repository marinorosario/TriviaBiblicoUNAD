using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using TriviaBiblicoUNAD2024.Data;
using TriviaBiblicoUNAD2024.Data.Modelos.Equipos;
using TriviaBiblicoUNAD2024.Data.Modelos.Participantes;
using TriviaBiblicoUNAD2024.Servicios.Interfaces;

namespace TriviaBiblicoUNAD2024.Servicios.Participantes
{
    public class ParticipanteService : IDataEngineService<ParticipanteModel>
    {
        private readonly IDbContextFactory<ApplicationDbContext> DbContextFactory;

        public ParticipanteService(IDbContextFactory<ApplicationDbContext> _DbContextFactory)
        {
            DbContextFactory = _DbContextFactory;
        }

        public IQueryable<ParticipanteModel> GetQueriable {
            get
            {
                ApplicationDbContext dbContext = DbContextFactory.CreateDbContext();
                return dbContext.Participantes.AsQueryable();
            }
        }    

        public async Task<int> CreateAsync(ParticipanteModel? entity)
        {
            ApplicationDbContext DbContext = await DbContextFactory.CreateDbContextAsync();
            if (entity is not null)
            {
                await DbContext.Participantes.AddAsync(entity);
                return await DbContext.SaveChangesAsync();
            }

            return await Task.FromResult(0);
        }

        public async Task<int> DeleteAsync(ParticipanteModel? entity)
        {
            ApplicationDbContext DbContext = await DbContextFactory.CreateDbContextAsync();
            if (entity is not null)
            {
                DbContext.Participantes.Remove(entity);
                return await DbContext.SaveChangesAsync();
            }

            return await Task.FromResult(0);
        }

        public async Task<int> DeleteAsync(IEnumerable<ParticipanteModel> entities)
        {
            ApplicationDbContext DbContext = await DbContextFactory.CreateDbContextAsync();
            if (entities is not null && entities.Count() > 0)
            {
                DbContext.Participantes.RemoveRange(entities);
                return await DbContext.SaveChangesAsync();
            }

            return await Task.FromResult(0);
        }

        public async Task<int> DeleteAsync(int? Id)
        {
            ApplicationDbContext DbContext = await DbContextFactory.CreateDbContextAsync();
            if (Id is not null)
            {
                return await DbContext.Participantes
                    .Where(e => e.Id == Id)
                    .ExecuteDeleteAsync();
            }

            return await Task.FromResult(0);
        }

        public async Task<int> DeleteAsync(IEnumerable<int>? ids)
        {
            ApplicationDbContext DbContext = await DbContextFactory.CreateDbContextAsync();
            if (ids is not null && ids.Count() > 0)
            {
                return await DbContext.Participantes
                    .Where(e => ids.Contains(e.Id))
                    .ExecuteDeleteAsync();
            }

            return await Task.FromResult(0);
        }

        public async Task<ICollection<ParticipanteModel>> GetAllAsync()
        {
            ApplicationDbContext DbContext = await DbContextFactory.CreateDbContextAsync();
            return await DbContext.Participantes.ToListAsync();
        }

        public async Task<ParticipanteModel?> GetByIdAsync(int? id)
        {
            ApplicationDbContext DbContext = await DbContextFactory.CreateDbContextAsync();
            if (id is not null)
            {
                return await DbContext.Participantes.FindAsync(id);
            }

            return null;
        }

        public async Task<ICollection<ParticipanteModel?>> GetByIdAsync(IEnumerable<int>? ids)
        {
            ApplicationDbContext DbContext = await DbContextFactory.CreateDbContextAsync();
            if (ids is not null && ids.Count() > 0)
            {
                var result = await DbContext.Participantes.Where(x => ids.Contains(x.Id)).ToListAsync();

                return result!;
            }

            return Enumerable.Empty<ParticipanteModel>().ToArray();
        }

        public async Task<int> UpdateAsync(int? Id, ParticipanteModel? entity)
        {
            ApplicationDbContext DbContext = await DbContextFactory.CreateDbContextAsync();
            if (Id is not null && entity is not null)
            {
                if (Id == entity.Id)
                {
                    DbContext.Participantes.Update(entity);
                    return await DbContext.SaveChangesAsync();
                }
            }

            return await Task.FromResult(0);
        }
    }
}
