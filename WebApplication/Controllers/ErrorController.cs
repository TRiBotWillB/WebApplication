using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }
    
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            
            switch (statusCode)
            {
                case 404:
                    
                    ViewBag.Errormessage = "Sorry, the resource you requested could not be found";
                    
                    _logger.LogWarning($"404 Error Occured. {statusCodeResult.OriginalPath}" + 
                                       $"{statusCodeResult.OriginalQueryString}");

                    break;
            }

            return View("NotFound");
        }

        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            _logger.LogError($"The path {exceptionDetails.Path} threw an exception " +
                             $"{exceptionDetails.Error.Message}");

            return View("Error");
        }
        
    }
}