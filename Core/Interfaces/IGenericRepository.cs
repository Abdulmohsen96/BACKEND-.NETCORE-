using Core.Entities;
using Core.Specifications;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Core.Interfaces {
    public interface IGenericRepository<T> where T : BaseEntity {

        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> GetAsync(ISpecification<T> spec);
        Task<int> CountAsync (ISpecification<T> spec);
    }
}