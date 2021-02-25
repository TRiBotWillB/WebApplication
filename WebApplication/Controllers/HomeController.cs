using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication.Models;
using WebApplication.Security;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ILogger<HomeController> _logger;
        private readonly IDataProtector _dataProtector;

        public HomeController(IEmployeeRepository employeeRepository, IHostingEnvironment hostingEnvironment,
            ILogger<HomeController> logger, IDataProtectionProvider dataProtectionProvider,
            DataProtectionPurposeStrings dataProtectionPurposeStrings)
        {
            _employeeRepository = employeeRepository;
            _hostingEnvironment = hostingEnvironment;
            _logger = logger;
            _dataProtector = dataProtectionProvider.CreateProtector(dataProtectionPurposeStrings.EmployeeIdRouteValue);
        }

        public ViewResult Index()
        {
            var model = _employeeRepository.GetAllEmployees()
                .Select(e =>
                {
                    e.EncryptedId = _dataProtector.Protect(e.Id.ToString());

                    return e;
                });

            return View(model);
        }

        public ViewResult Details(string id)
        {
            int employeeId = Convert.ToInt32(_dataProtector.Unprotect(id));
            
            _logger.LogTrace("LOGGED TRACE");
            _logger.LogWarning("LOGGED WARNING");

            Employee employee = _employeeRepository.Get(employeeId);

            if (employee == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", employeeId);
            }

            HomeDetailsViewModel viewModel = new HomeDetailsViewModel()
            {
                Employee = employee,
                PageTitle = "Employee Details"
            };

            return View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var uniqueFileName = ProccessUploadedFile(model);

                Employee newEmployee = new Employee
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    PhotoPath = uniqueFileName
                };

                _employeeRepository.Add(newEmployee);

                // Add sets the Id in the newEmployee object so we can reference it directly

                return RedirectToAction("Details", new {id = newEmployee.Id});
            }

            return View();
        }

        [HttpGet]
        [Authorize]
        public ViewResult Edit(int Id)
        {
            Employee employee = _employeeRepository.Get(Id);
            EmployeeEditViewModel employeeEditViewModel = new EmployeeEditViewModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department,
                ExistingPhotoPath = employee.PhotoPath
            };

            return View(employeeEditViewModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _employeeRepository.Get(model.Id);

                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Department = model.Department;

                if (model.Photo != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", model.ExistingPhotoPath);
                        
                        System.IO.File.Delete(filePath);
                    }
                    
                    var uniqueFileName = ProccessUploadedFile(model);
                    employee.PhotoPath = uniqueFileName;
                }

                _employeeRepository.Update(employee);

                return RedirectToAction("Details", new {id = employee.Id});
            }

            return View();
        }

        private string ProccessUploadedFile(EmployeeCreateViewModel model)
        {
            string uniqueFileName = null;

            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");

                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;

                string filepath = Path.Combine(uploadsFolder, uniqueFileName);

                FileStream fs = new FileStream(filepath, FileMode.Create);
                model.Photo.CopyTo(fs);
                fs.Close();
            }

            return uniqueFileName;
        }
    }
}