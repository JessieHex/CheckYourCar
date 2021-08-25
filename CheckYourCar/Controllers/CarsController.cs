using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckYourCar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheckYourCar.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        //using Microsoft.AspNetCore.Mvc.Rendering;
        public IEnumerable<SelectListItem> carMake { get; set; }
        // GET: /<controller>/
        public CarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //create car make
        public IActionResult AddCarMake()
        {
            return View();
        }


        //get car make
        public async Task<IActionResult> Index()
        {

            return View(await _context.CarsMake.ToListAsync());
        }
    }
}
