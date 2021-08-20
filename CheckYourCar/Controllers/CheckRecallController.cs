using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckYourCar.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheckYourCar.Controllers
{
    public class CheckRecallController : Controller
    {
        private readonly ApplicationDbContext _db;

        

        [BindProperty]
        public VehicleRecall VehicleRecall { get; set; }
        public CheckRecallController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Check()
        {
            string make = HttpContext.Request.Form["MakeName"];
            string model = HttpContext.Request.Form["ModelName"];
            VehicleRecall = new VehicleRecall();
            VehicleRecall = _db.VehicleRecalls.FirstOrDefault(u => u.MakeName == make && u.ModelName == model);

            if (VehicleRecall == null)
            {
                return Content("Not found");
            }

            return Content("Recall message: " + VehicleRecall.Comment);// View(VehicleRecall); // TODO
        }

    }
}
