﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheckYourCar.Models
{
    public class CarMake
    {
        [Key]
        public int ID { get; set; }
        public string Company { get; set; }

    }
}
