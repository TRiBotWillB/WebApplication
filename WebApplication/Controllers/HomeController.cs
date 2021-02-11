using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        
        public ViewResult Index()
        {
            var model =  _employeeRepository.GetAllEmployees();

            return View(model);
        }

        public ViewResult Details(int? id)
        {
            Employee model = _employeeRepository.GetEmployee(id ?? 1);

            HomeDetailsViewModel viewModel = new HomeDetailsViewModel()
            {
                Employee = model,
                PageTitle = "Employee Details"
            };

            return View(viewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee newEmployee = _employeeRepository.AddEmployee(employee);
                //return RedirectToAction("Details", new {id = newEmployee.Id});
            }

            return View();
        }
    }
}