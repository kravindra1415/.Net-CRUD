using WebApplication1.Models;

namespace WebApplication1.Services.withDI
{
    public interface IUserServiceDI
    {
        Task<List<User>> GetAllAsync();
    }
}