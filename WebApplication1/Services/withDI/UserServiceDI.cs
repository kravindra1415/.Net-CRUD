using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services.withDI
{
    public class UserServiceDI : IUserServiceDI
    {
        private readonly UserManagementContext _contxet;
        public UserServiceDI(UserManagementContext context)
        {
            _contxet = context;
        }

        public async Task<List<User>> GetAllAsync()
        {
            var users = await _contxet.Users.ToListAsync();
            return users;
        }
    }
}
