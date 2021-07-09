using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestGameCars.Entities
{
    public class Player
    {
        [Key]
        public int idPlayer { get; set; }
        public int countPlayer { get; set; }
        public string namePlayer { get; set; }
        public int idDriver { get; set; }
        public Driver driver { get; set; }
        public List<Game> games { get; set; }

        public Player()
        {

        }

        public void initPlayers()
        {
            Console.WriteLine("Ingrese el numero de jugadores");
            countPlayer = Convert.ToInt32(Console.ReadLine());
           
            for (int i = 0; i < countPlayer; i++)
            {
                Console.WriteLine("Ingrese el nombre del jugador");
                namePlayer = Console.ReadLine();
            }

        }
    }
}
