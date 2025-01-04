using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPatern.WIthCar
{
    // Step 1: Product - Define the object to be built
    public class Car
    {
        public string Engine { get; set; }
        public string Wheels { get; set; }
        public string Body { get; set; }

        public override string ToString()
        {
            return $"Car with Engine: {Engine}, Wheels: {Wheels}, Body: {Body}";
        }
    }

    // Step 2: Builder Interface
    public interface ICarBuilder
    {
        void SetEngine(string engine);
        void SetWheels(string wheels);
        void SetBody(string body);
        Car GetCar();
    }

    // Step 3: Concrete Builder
    public class SportsCarBuilder : ICarBuilder
    {
        private Car _car = new Car();

        public void SetEngine(string engine)
        {
            _car.Engine = engine;
        }

        public void SetWheels(string wheels)
        {
            _car.Wheels = wheels;
        }

        public void SetBody(string body)
        {
            _car.Body = body;
        }

        public Car GetCar()
        {
            return _car;
        }
    }

    // Step 4: Director
    public class CarDirector
    {
        private readonly ICarBuilder _builder;

        public CarDirector(ICarBuilder builder)
        {
            _builder = builder;
        }

        public Car BuildCar()
        {
            _builder.SetEngine("V8 Engine");
            _builder.SetWheels("Alloy Wheels");
            _builder.SetBody("Sports Body");
            return _builder.GetCar();
        }
    }

    // Step 5: Client
    public static class Use
    {
      public  static void Run()
        {
            ICarBuilder builder = new SportsCarBuilder();
            CarDirector director = new CarDirector(builder);

            Car car = director.BuildCar();

            Console.WriteLine(car);
        }
    }
    //Car with Engine: V8 Engine, Wheels: Alloy Wheels, Body: Sports Body





}
