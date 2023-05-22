using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            carManager.Add(new Car { Id = 3, BrandId = 1, ColorId = 2, DailyPrice = 11, ModelYear = 2009, Description = "c" });
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.DailyPrice);
            }

            Console.ReadLine();
        }
    }
}