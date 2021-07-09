using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameCars.Context;
using TestGameCars.Entities;

namespace TestGameCars
{
    public class InsertGameDB
    {
        string Game;
        int CountPlayer;
        string NamePlayer;
        string BrandCar;
        string NameTrack;
        int Kilometres;
     

        public InsertGameDB(string Game, int CountPlayer, string NamePlayer, string BrandCar, string NameTrack,int Kilometres)
        {
            this.Game = Game;
            this.CountPlayer = CountPlayer;
            this.NamePlayer = NamePlayer;
            this.BrandCar = BrandCar;
            this.NameTrack = NameTrack;
            this.Kilometres = Kilometres;
            
        }
        public void insertData()
        {
            int idLine = 0;
            
            using (var context = new DataContext())
            {
                Line objLinea = new Line { 
                    nameLine = CountPlayer.ToString()
                };

                try
                {
                    context.lines.Add(objLinea);
                    context.SaveChanges();
                }
                catch (Exception ex )
                {

                    Console.WriteLine(ex.Message);
                }

                var id = from r in context.lines
                           select r.idLine;

                foreach (var item in id)
                {
                    idLine = item;
                }
                Track objTrack = new Track
                {
                    kilometres = Kilometres,
                    nameTrack = NameTrack,
                    idLine = idLine
                };

                try
                {
                    context.tracks.Add(objTrack);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        public void insertDataDriver(string nameCar, string driver)
        {
            int idCars = 0;
            int idDrivers = 0;
            try
            {
                using (var context = new DataContext())
                {

                    Car objCar = new Car
                    {
                        brandCar = nameCar
                    };

                    context.cars.Add(objCar);
                    context.SaveChanges();

                    var idCar = from r in context.cars
                                select r.idCar;

                    foreach (var car in idCar)
                    {
                        idCars = car;
                    }

                    Driver objDriver = new Driver
                    {
                        nameDriver = driver,
                        idCar = idCars
                    };

                    context.drivers.Add(objDriver);
                    context.SaveChanges();

                    var idDriver = from r in context.drivers
                                select r.idDriver;

                    foreach (var item in idDriver)
                    {
                        idDrivers = item;
                    }

                    Player objPlayer = new Player
                    {
                        namePlayer = driver,
                        idDriver = idDrivers
                    };

                    context.players.Add(objPlayer);
                    context.SaveChanges();
                }
            
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Driver> selectDataGame()
        {
           
            using (var context = new DataContext())
            {
            
                var listDriver = context.drivers.Include(l => l.car).ToList();
                return listDriver;
            }
                
        }

        public List<GameInital> executeGame(int countDie, List<GameInital> listGame, int kilometers, string car, string nameDriver) 
        {
            Random random = new Random();
            int countTried = 0;
            int advance = 0;
                for (int i = 1; i <= countDie; i++)
                {
                    Console.WriteLine("Lanzamiento numero " + i);
                    countTried++;
                    advance = advance + (random.Next(1, 6) * 100);
                    Console.WriteLine("El total recorrido es: " + advance);
                    if(advance == kilometers || advance > kilometers)
                    {
                        break;
                    }
                }

                listGame.Add(new GameInital { 
                    advance = advance,
                    countTried = countTried,
                    nameDriver = nameDriver,
                    car = car
                });
            return listGame;
        }

        public void DeleteTables()
        {
            using (var context = new DataContext())
            {
                try
                {
                    context.lines.RemoveRange();
                    context.cars.RemoveRange();
                    context.drivers.RemoveRange();
                    context.games.RemoveRange();
                    context.players.RemoveRange();
                    context.tracks.RemoveRange();

                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
               

            }
        }



    }
}
