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
            BrandManager brandManager = new BrandManager(new EFBrandDal());
            ColorManager colorManager = new ColorManager(new EFColorDal());

            foreach (var item in carManager.carDetailsDto().Data)
            {
                Console.WriteLine("{0},{1},{2},{3}",item.CarId,item.BrandName,item.ColorName,item.DailyPrice);
            }

            // carManager.Add(new Car { Id = 3, BrandId = 1, ColorId = 2, DailyPrice = 11, ModelYear = 2009, Description = "c" });

            // GetBrand(brandManager);

            //AddCar(carManager);

            // GetColor(colorManager);

            //GetCarsByBrandIdd(carManager);
            //GetCarsByColorIdd(carManager);

            Console.ReadLine();
        }

        private static void GetCarsByColorIdd(CarManager carManager)
        {
            foreach (var item in carManager.GetCarsByColorId(1).Data)
            {
                Console.WriteLine(item.ModelYear + " --- " + item.ColorId);
            }
        }

        private static void GetCarsByBrandIdd(CarManager carManager)
        {
            foreach (var c in carManager.GetCarsByBrandId(5).Data)
            {
                Console.WriteLine(c.Description);
            }
        }

        private static void GetBrand(BrandManager brandManager)
        {
            foreach (var item in brandManager.GetAll().Data)
            {
                Console.WriteLine(item.Name);
            }
        }

        private static void GetColor(ColorManager colorManager)
        {
            foreach (var item in colorManager.GetAll().Data) { Console.WriteLine(item.Name + "-------"); }
        }

        private static void AddCar(CarManager carManager)
        {
            Car car = new Car { BrandId = 2, ColorId = 3, DailyPrice = 10, ModelYear = 1889, Description = "d" };
            carManager.Add(car);

            foreach (var item in carManager.GetAll().Data)
            {
                Console.WriteLine(item.Description);
            }
        }
    }
}