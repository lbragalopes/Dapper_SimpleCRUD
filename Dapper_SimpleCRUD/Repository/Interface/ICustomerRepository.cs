using Dapper_SimpleCRUD.Models;

namespace Dapper_SimpleCRUD.Repository.Interface
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByIdAsync(int id);
        Task<IReadOnlyList<Customer>> GetAllAsync();
        Task<Customer> AddAsync(Customer entity);
        Task AddListAsync(List<Customer> entity);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(Customer entity);
      
    }
}
