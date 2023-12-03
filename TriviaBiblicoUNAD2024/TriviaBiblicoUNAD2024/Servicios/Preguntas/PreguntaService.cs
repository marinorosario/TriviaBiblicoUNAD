using TriviaBiblicoUNAD2024.Data.Modelos.Preguntas;
using TriviaBiblicoUNAD2024.Servicios.Interfaces;

namespace TriviaBiblicoUNAD2024.Servicios.Preguntas
{
    public class PreguntaService : IDataEngineService<PreguntaModel>
    {
        public IQueryable<PreguntaModel> GetQueriable => throw new NotImplementedException();

        public Task<int> CreateAsync(PreguntaModel? entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(PreguntaModel? entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(IEnumerable<PreguntaModel> entities)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int? Id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(IEnumerable<int>? ids)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<PreguntaModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PreguntaModel?> GetByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<PreguntaModel?>> GetByIdAsync(IEnumerable<int>? ids)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(int? Id, PreguntaModel? entity)
        {
            throw new NotImplementedException();
        }
    }
}
