using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System.Drawing;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EFCarDal());
           // carManager.Add(new Car { Id = 3, BrandId = 1, ColorId = 2, DailyPrice = 11, ModelYear = 2009, Description = "c" });
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Description);
            }
            BrandManager brandManager = new BrandManager(new EFBrandDal());
            
            foreach (var item in brandManager.GetAll())
            {
                Console.WriteLine(item.Name);
            }

            ColorManager colorManager = new ColorManager(new EFColorDal());
            



            foreach (var item in colorManager.GetAll()) { Console.WriteLine(item.Name); }
            Console.WriteLine("hhhhhhhhh");


            Console.ReadLine();
        }
    }
}