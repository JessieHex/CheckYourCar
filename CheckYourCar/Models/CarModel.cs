using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheckYourCar.Models
{
    public class CarModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]

        public int ID { get; set; }

        public int CompanyID { get; set; }

        public string Model { get; set; }
    }
}
