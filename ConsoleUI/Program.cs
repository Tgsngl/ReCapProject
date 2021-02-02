using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            
            ICarService carManager = new CarManager(new InMemoryCarDal());
            
            Car carToAdd = new Car() { CarId = 6, BrandId = 4, ColorId = 1, ModelYear = 2018, DailyPrice = 800, Description = "Lamborgini Aventador     " };
            carManager.Add(carToAdd);
            ListAllVehicles(carManager);
            Console.WriteLine("Şu araba eklendi: "+carToAdd.Description + "\n");

            Car carToUpdate = new Car() { CarId = 3, BrandId = 2, ColorId = 1, ModelYear = 2015, DailyPrice = 450000, Description = "Mercedes-Benz G 63 AMG" };
            carManager.Update(carToUpdate);
            Console.WriteLine("\nAraba güncellendi: " + carToUpdate.CarId + " -" + carToUpdate.Description + "(" + carToUpdate.ModelYear + ")\n");

            Console.WriteLine("Silmek için bir araba seçiniz (1'den 5'e kadar.)");
            int a = Convert.ToInt32(Console.ReadLine());
            
            Car carToDelete = carManager.GetById(a);
            carManager.Delete(carToDelete);
            Console.WriteLine("Araba silindi: " + carToDelete.CarId + ":" + carToDelete.Description + "\n");
            ListAllVehicles(carManager);
        }

        private static void ListAllVehicles(ICarService carService)
        {
            foreach (Car car in carService.GetAll())
            {
                Console.WriteLine("{0}-){1}\t{2}\t\t{3}", car.CarId, car.Description, car.ModelYear, car.DailyPrice+" TL");
            }
        }
    }
}
