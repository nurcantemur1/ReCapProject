using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System.Drawing;

CarManager carManager = new CarManager(new EFCarDal());
BrandManager brandManager = new BrandManager(new EFBrandDal());
ColorManager colorManager = new ColorManager(new EFColorDal());
UserManager userManager = new UserManager(new EFUserDal());
CustomerManager customerManager = new CustomerManager(new EFCustomerDal());
RentalManager rentalManager = new RentalManager(new EFRentalDal());

//  Rental rental=new Rental() {CarId=2,CustomerId=1,RentDate=DateTime.Now ,ReturnDate=DateTime.Now};
arabakiralateslimet(rentalManager);


//var a = rentalManager.GetbyId(2).Data;

//Console.WriteLine("{0}/{1}/{2}/{3}/{4}", a.Id, a.CarId, a.CustomerId, a.RentDate,a.ReturnDate);


//userandcustAdd(userManager, customerManager);

//branggetall(brandManager);

// carDetailsDto0(carManager);

// carManager.Add(new Car { Id = 3, BrandId = 1, ColorId = 2, DailyPrice = 11, ModelYear = 2009, Description = "c" });

// GetBrand(brandManager);

//AddCar(carManager);

// GetColor(colorManager);

//GetCarsByBrandIdd(carManager);
//GetCarsByColorIdd(carManager);

Console.ReadLine();

void userandcustAdd(UserManager userManager, CustomerManager customerManager)
{
    User user = new User() { FirstName = "x", LastName = "b", Email = "c", Password = "hn" };
    userManager.Add(user);
    Customer customer = new Customer() { UserId = user.Id, CompanyName = "gh" };
    customerManager.Add(customer);
    foreach (var item in userManager.GetAll().Data)
    {
        Console.WriteLine("kullanıcı =" + item.Id + " ---- " + item.FirstName);
    }
    Console.WriteLine(" ------------- ");
    foreach (var item in customerManager.GetAll().Data)
    {
        Console.WriteLine("müşteri =" + item.Id + " ---- " + item.UserId + "///" + item.CompanyName);
    }
}

void branggetall(BrandManager brandManager)
{
    Brand brand = new Brand() { Id = 4, Name = "hh" };
    brandManager.Add(brand);
    foreach (var item in brandManager.GetAll().Data)
    {
        Console.WriteLine(item.Name);
    }
}

void carDetailsDto0(CarManager carManager)
{
    foreach (var item in carManager.carDetailsDto().Data)
    {
        Console.WriteLine("{0},{1},{2},{3}", item.CarId, item.BrandName, item.ColorName, item.DailyPrice);
    }
}

void GetCarsByColorIdd(CarManager carManager)
{
    foreach (var item in carManager.GetCarsByColorId(1).Data)
    {
        Console.WriteLine(item.ModelYear + " --- " + item.ColorId);
    }
}

void GetCarsByBrandIdd(CarManager carManager)
{
    foreach (var c in carManager.GetCarsByBrandId(5).Data)
    {
        Console.WriteLine(c.Description);
    }
}

void GetBrand(BrandManager brandManager)
{
    foreach (var item in brandManager.GetAll().Data)
    {
        Console.WriteLine(item.Name);
    }
}

void GetColor(ColorManager colorManager)
{
    foreach (var item in colorManager.GetAll().Data) { Console.WriteLine(item.Name + "-------"); }
}

void AddCar(CarManager carManager)
{
    Car car = new Car { BrandId = 2, ColorId = 3, DailyPrice = 10, ModelYear = 1889, Description = "d" };
    carManager.Add(car);

    foreach (var item in carManager.GetAll().Data)
    {
        Console.WriteLine(item.Description);
    }
}

static void arabakiralateslimet(RentalManager rentalManager)
{
    Rental rental = new Rental() { CarId = 3, CustomerId = 1, RentDate = DateTime.Now, ReturnDate = null };

    rentalManager.kirala(rental);
    Console.WriteLine("araba kiralandı");

    rental.ReturnDate = DateTime.Now;
    rentalManager.teslimet(rental);
    Console.WriteLine("teslim edildi -" + rental.ReturnDate + "----------" + rental.CarId);
}