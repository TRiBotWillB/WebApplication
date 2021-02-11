using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        
        public ViewResult Index()
        {
            var model =  _employeeRepository.GetAllEmployees();

            return View(model);
        }

        public ViewResult Details()
        {
            Employee model = _employeeRepository.GetEmployee(1);
            HomeDetailsViewModel viewModel = new HomeDetailsViewModel()
            {
                Employee = model,
                PageTitle = "Employee Details"
            };

            return View(viewModel);
        }
    }
}