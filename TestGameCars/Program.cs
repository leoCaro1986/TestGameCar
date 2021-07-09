using System;
using System.Collections.Generic;
using System.Linq;
using TestGameCars.Entities;

namespace TestGameCars
{
    class Program
    {
        static void Main(string[] args)
        {
            List<GameInital> executeGame = new List<GameInital>();
                
            string Game;
            int CountPlayer;
            string NamePlayer = "";
            string BrandCar = "";
            string NameTrack;
            int Kilometres;
            Console.WriteLine("Bienvenido al juego The Cars");
            Console.WriteLine("Ingrese el nombre del Juego");
            Game = Console.ReadLine();
            Console.WriteLine("Ingrese la cantidad de jugadores");
            CountPlayer = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese el nombre de la pista");
            NameTrack = Console.ReadLine();
            Console.WriteLine("ingrese en metros la longitud de la pista");
            Kilometres = Convert.ToInt32(Console.ReadLine());

            InsertGameDB objInsertGameDB = new InsertGameDB(Game, CountPlayer, NamePlayer, BrandCar, NameTrack, Kilometres);
            objInsertGameDB.insertData();

            for (int i = 0; i < CountPlayer; i++)
            {
                Console.WriteLine("Ingrese nombre del Jugador");
                NamePlayer = Console.ReadLine();
                Console.WriteLine("Ingrese la marca del vehiculo");
                BrandCar = Console.ReadLine();
                objInsertGameDB.insertDataDriver(BrandCar,NamePlayer);
            }
            Console.WriteLine();
            Console.WriteLine("******************** JUEGO CREADO CORRECTAMENTE **********************");
            Console.WriteLine();
            List<Driver> driversGame= objInsertGameDB.selectDataGame();
            Console.WriteLine("Comencemos el juego...");
            Console.WriteLine();
            Console.WriteLine("Ingrese la cantidad de veces que se lanzara el dado");
            int countDie = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(NameTrack + ", La cantidad de metros de la pista es: " + Kilometres);
            foreach (var item in driversGame)
            {
                Console.WriteLine();
                Console.WriteLine("Jugador :"+ item.nameDriver + ", Carro de tipo:" + item.car.brandCar);
              
                executeGame =objInsertGameDB.executeGame(countDie, executeGame,Kilometres, item.car.brandCar, item.nameDriver);
            }

            var result = executeGame.OrderByDescending(x => x.advance).ThenBy(c => c.countTried).ToList();

            Console.WriteLine("El ganador del juego es: " +
                                result[0].nameDriver + ",con un recorrido de: " + result[0].advance +
                                ",con un numero de intentos de:" + result[0].countTried);
            Console.WriteLine();
            Console.WriteLine("El podio quedo de la siguiente Manera:");
            for (int i = 1; i <= result.Count; i++)
            {
               Console.WriteLine( i + "-Puesto:" + result[i].nameDriver);
            }
           
            objInsertGameDB.DeleteTables();
            Console.ReadKey();

        }
    }
}
