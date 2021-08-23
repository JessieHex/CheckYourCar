using System;
using System.ComponentModel.DataAnnotations;

namespace CheckYourCar.Models
{
    public class CarMake
    {
        [Key]
        public int ID { get; set; }
        public string Company { get; set; }

    }
}
