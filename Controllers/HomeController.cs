using ASPNetCoreForms.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNetCoreForms.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            // model = new ProductEditModel();
            // View(model);
            return View();
        }

        public IActionResult Edit()
        {
            var  model = new ProductEditModel();
             View(model);
            return View(model);
        }


        [HttpPost]
        public IActionResult Create(ProductEditModel model) //
        {
            string message = string.Empty;
            if (ModelState.IsValid) // cơ chế model Binding này từ động map với ProductEditModel 
            {
                message = "Product: " + model.Name + ". Rate: "
                         + model.Rate + ". Rating: " + model.Rating + " created successfully"; // nếu model map hợp lệ thì in ra message này
            }

            else
            {
                message = "Failed to create product , Please to try again";
            }    
                
            return Content(message);
        }
    }
}
