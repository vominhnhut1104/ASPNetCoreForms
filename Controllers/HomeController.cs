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
        public IActionResult NoModelBinding()
        {

            ProductEditModel model = new ProductEditModel();
            string message = "";

            model.Name = Request.Form["Name"].ToString();
            model.Rate = Convert.ToDecimal(Request.Form["Rate"]);
            model.Rating = Convert.ToInt32(Request.Form["Rateing"]);

            message = "product " + model.Name + " created successfully";
            return Content(message);
        }

        [HttpPost]
        public IActionResult Create(ProductEditModel model) //
        {
            string message = string.Empty;

            
            if (ModelState.IsValid) // cơ chế model Binding này từ động map với ProductEditModel 
            {
                //Check product name exist
                if (model.Name == "test")
                {
                    ModelState.AddModelError("", "This product name was exists");
                    return View(model);
                }

                message = "Product: " + model.Name + ". Rate: "
                         + model.Rate + ". Rating: " + model.Rating + " created successfully"; // nếu model map hợp lệ thì in ra message này
            }

            else
            {
               return View(model);
            }    
                
            return Content(message);
        }

        [HttpGet]
        public IActionResult FormAndQuery()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FormAndQuery([FromRoute]string name, ProductEditModel model)
        {
            string message = "";

            if (ModelState.IsValid)
            {
                message = "Query string " + name + " product " + model.Name + " Rate " + model.Rate + " Rating " + model.Rating;
            }
            else
            {
                message = "Failed to create the product. Please try again";
            }
            return Content(message);
        }
    }
}
