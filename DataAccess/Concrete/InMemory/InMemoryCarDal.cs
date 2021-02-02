using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            
            Console.WriteLine("--Araba-------------------------Modeli----------Fiyatı\n");
            _cars = new List<Car>()
            {
                
                new Car{CarId=1, BrandId=1, ColorId=1, ModelYear=2016, DailyPrice=150, Description=" Citroen HB C4 1.6 HDI"},
                new Car{CarId=2, BrandId=1, ColorId=1, ModelYear=2018, DailyPrice=170, Description=" Ford Focus sedan 1.6 TDI "},
                new Car{CarId=3, BrandId=2, ColorId=3, ModelYear=2017, DailyPrice=250, Description=" Volkswagen Passat 2.0 TDI "},
                new Car{CarId=4, BrandId=2, ColorId=2, ModelYear=2019, DailyPrice=180, Description=" Ford Focus 1.6 TDI sedan "},
                new Car{CarId=5, BrandId=2, ColorId=2, ModelYear=2020, DailyPrice=160, Description=" Toyota Corolla 1.5 TDI "},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.CarId == id);
        }
        

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        
    }
}
