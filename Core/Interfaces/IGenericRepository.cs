using Core.Entities;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsAsync(int id);

        Task<IReadOnlyList<T>> GetAsAsync();

    }
}
