using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestGameCars.Entities
{
    public class Track
    {
        [Key]
        public int idTrack { get; set; }
        public int kilometres { get; set; }
        public string nameTrack { get; set; }
        public int idLine { get; set; }
        public Line line { get; set; }
        public List<Game> games { get; set; }


    }
}
