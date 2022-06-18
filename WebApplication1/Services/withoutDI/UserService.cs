using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services.withoutDI
{
    public class UserService
    {
        public async Task<List<User>> GetAllAsync(UserManagementContext context)
        {
            var users = await context.Users.ToListAsync();
            return users;
        }
    }
}
