using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestGameCars.Entities
{
    public class Driver
    {
        [Key]
        public int idDriver { get; set; }
        public string nameDriver { get; set; }
        public Player player { get; set; }
        public int idCar { get; set; }
        public Car car { get; set; }
        public List<Game> games { get; set; }
    }
}
