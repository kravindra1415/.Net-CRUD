using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Services.withDI;
using WebApplication1.Services.withoutDI;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //DI
        private readonly IDepartmentServiceDI _departmentServiceDI;
        private readonly IUserServiceDI _userServiceDI;

        public HomeController(ILogger<HomeController> logger,
            IDepartmentServiceDI departmentServiceDI,
            IUserServiceDI userServiceDI
            )
        {
            _logger = logger;
            _departmentServiceDI = departmentServiceDI;
            _userServiceDI = userServiceDI;
        }

        /// <summary>
        /// Without DI
        /// </summary>
        /// <returns></returns>

        public async Task<IActionResult> IndexAsync()
        {
            var dbContext = new UserManagementContext();

            var departmentService = new DepartmentService();
            var userService = new UserService();

            var departmentUserViewModel = new DepartmentUserViewModel
            {
                department = await departmentService.GetAllAsync(dbContext),
                user = await userService.GetAllAsync(dbContext)
            };


            return View(departmentUserViewModel);
        }

        /// <summary>
        /// With DI
        /// </summary>
        /// <returns></returns>

        public async Task<IActionResult> PrivacyAsync()
        {
            var departmentUserViewModel = new DepartmentUserViewModel
            {
                department = await _departmentServiceDI.GetAllAsync(),
                user = await _userServiceDI.GetAllAsync()
            };

            return View(departmentUserViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}