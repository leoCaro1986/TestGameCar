using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestGameCars.Entities
{
    public class Game
    {
        [Key]
        public int idGame { get; set; }
        public string name { get; set; }
        public int idPlayer { get; set; }
        public Player player { get; set; }
        public int idTrack { get; set; }
        public Track track { get; set; }
        public int idLine { get; set; }
        public Line line { get; set; }
        public int idDriver { get; set; }
        public Driver driver { get; set; }
        public int idCar { get; set; }
        public Car car { get; set; }

        //public Game(string name)
        //{
        //    this.name = name;
        //}

        //public void InitGame(int track)
        //{
        //    Player objplayer = new Player();
        //    switch (track)
        //    {
        //        case 1:
        //            objplayer.initPlayers();


        //            break;
        //        case 2:
        //            objplayer.initPlayers();
        //            break;
        //        case 3:
        //            objplayer.initPlayers();
        //            break;
        //        default:
        //            Console.WriteLine("Por favor ingrese un numero del 1 al 3");
        //            break;
        //    }

        //}


    }

}
