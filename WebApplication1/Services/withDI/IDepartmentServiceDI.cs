using WebApplication1.Models;

namespace WebApplication1.Services.withDI
{
    public interface IDepartmentServiceDI
    {
        Task<List<Department>> GetAllAsync();
    }
}