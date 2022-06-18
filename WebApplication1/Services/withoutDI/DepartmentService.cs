using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services.withoutDI
{
    public class DepartmentService
    {
        public async Task<List<Department>> GetAllAsync(UserManagementContext context)
        {
            var departments = await context.Departments.ToListAsync();
            return departments;
        }
    }
}
