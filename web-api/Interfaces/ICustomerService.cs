using web_api.Contracts;
using web_api.Models;

namespace web_api.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Todo> GetByIdAsync(Guid id);
        Task CreateTodoAsync(CreateTodoRequest request);
        Task UpdateTodoAsync(Guid id, UpdateTodoRequest request);
        Task DeleteTodoAsync(Guid id);
    }
}
