namespace TriviaBiblicoUNAD2024.Servicios.Interfaces
{
    public interface IDataEngineService<T>
    {
        IQueryable<T> GetQueriable { get; }

        Task<ICollection<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int? id);
        Task<ICollection<T?>> GetByIdAsync(IEnumerable<int>? ids);

        Task<int> CreateAsync(T? entity);
        Task<int> UpdateAsync(int? Id, T? entity);
        Task<int> DeleteAsync(T? entity);
        Task<int> DeleteAsync(IEnumerable<T> entities);
        Task<int> DeleteAsync(int? Id);
        Task<int> DeleteAsync(IEnumerable<int>? ids);

    }
}
