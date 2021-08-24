using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CheckYourCar.Models
{
    public class VehicleRecall
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public string NotificationType { get; set; }
        public string Comment { get; set; }
        public DateTime RecallDate { get; set; }


    }
}
