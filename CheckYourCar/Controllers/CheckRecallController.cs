using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckYourCar.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheckYourCar.Controllers
{
    public class CheckRecallController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CheckRecallController(ApplicationDbContext db)
        {
            _db = db;
        }


        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string MakeName, string ModelName)
        {
            // use LINQ query to get all the genres from the database
            IQueryable<string> makeQuery = from r in _db.VehicleRecalls
                                            orderby r.MakeName
                                            select r.MakeName;
            IQueryable<string> modelQuery = from r in _db.VehicleRecalls
                                            where r.MakeName == MakeName
                                            orderby r.ModelName
                                            select r.ModelName;

            var recalls = from r in _db.VehicleRecalls
                          select r;

            VehicleRecallCheckResultViewModel vehicleRecallVM;
            if (!String.IsNullOrEmpty(MakeName) && !String.IsNullOrEmpty(ModelName))
            {
                recalls = recalls.Where(r => r.MakeName == MakeName);
                recalls = recalls.Where(r => r.ModelName == ModelName);

                vehicleRecallVM = new VehicleRecallCheckResultViewModel
                {
                    MakeNames = new SelectList(await makeQuery.Distinct().ToListAsync()),
                    ModelNames = new SelectList(await modelQuery.Distinct().ToListAsync()),
                    VehicleRecalls = await recalls.OrderByDescending(r => r.RecallDate).ToListAsync()
                };
            } else
            {
                vehicleRecallVM = new VehicleRecallCheckResultViewModel
                {
                    MakeNames = new SelectList(await makeQuery.Distinct().ToListAsync()),
                    ModelNames = new SelectList(await modelQuery.Distinct().ToListAsync()),
                    VehicleRecalls = null
                };
            }
     
            return View(vehicleRecallVM);

        }
           
    }
}
