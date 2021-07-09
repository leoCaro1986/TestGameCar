using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestGameCars.Entities
{
    public class Car
    {
        [Key]
        public int idCar { get; set; }
        public  string brandCar { get; set; }
        public Driver driver { get; set; }
        public List<Game> games { get; set; }
    }
}
