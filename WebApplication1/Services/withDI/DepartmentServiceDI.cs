using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services.withDI
{
    public class DepartmentServiceDI : IDepartmentServiceDI
    {
        private readonly UserManagementContext _context;
        public DepartmentServiceDI(UserManagementContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> GetAllAsync()
        {
            var departments = await _context.Departments.ToListAsync();
            return departments;
        }
    }
}
