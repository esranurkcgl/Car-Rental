// See https://aka.ms/new-console-template for more information

using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

CarTest();

//ColorTest();

//BrandTest();

static void CarTest()
{
    CarManager carManager = new CarManager(new EfCarDal());

    var result = carManager.GetCarDetails();

    if (result.success == true)
    {
        foreach (var car in result.Data)
        {
            Console.WriteLine("Car: " + car.CarName + " / " + car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice);
        }
    }

    else
        Console.WriteLine(result.message);
}

static void ColorTest()
{
    ColorManager colorManager = new ColorManager(new EfColorDal());

    var result = colorManager.GetAll();

    if (result.success == true)
    {
        foreach (var color in result.Data)
        {
            Console.WriteLine("ID: " + color.Id + " Color: " + color.Name);
        }
    }

    else
    {
        Console.WriteLine(result.message);
    }
}

static void BrandTest()
{
    BrandManager brandManager = new BrandManager(new EfBrandDal());
    var result = brandManager.GetAll();

    if (result.success == true)
    {
        foreach (var brand in result.Data)
        {
            Console.WriteLine("ID: " + brand.Id + " Brand " + brand.Name);
        }
    }
    else
        Console.WriteLine(result.message);
}