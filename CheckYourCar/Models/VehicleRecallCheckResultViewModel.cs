using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CheckYourCar.Models
{
    public class VehicleRecallCheckResultViewModel
    {
        public List<VehicleRecall> VehicleRecalls { get; set; }
        public SelectList MakeNames { get; set; }
        public SelectList ModelNames { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }

    }
}
