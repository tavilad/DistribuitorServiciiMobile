using DataMapper;
using DataMapper.Interfaces;
using DistribuitorServiciiMobile.Models;
using ServiceLayer.Controllers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ConsoleApp1
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            DistribuitorServiciiMobileContext context = new DistribuitorServiciiMobileContext();
            IAbonamentRepository abonamentRepository = new AbonamentRepository(context);
            AbonamentController abonamentController = new AbonamentController(abonamentRepository);
            Abonament abonament = new Abonament()
            {
                Pret = 1000,
                DataInceput = DateTime.Now,
                DataSfarsit = new DateTime(2020, 9, 14),
            };

            await abonamentController.AddAbonament(abonament);

            IEnumerable<Abonament> abonamentList = await abonamentController.GetAllAbonament();

            foreach (var entry in abonamentList)
            {
                Console.WriteLine(entry.Pret);
                Console.WriteLine(entry.DataInceput);
                Console.WriteLine(entry.DataSfarsit);
            }
        }
    }
}
