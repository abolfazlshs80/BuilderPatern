using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPatern.WIthoutCar
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

    // Step 2: Client - Manually build the object
  public  static  class Use
    {
        static void Run()
        {
            // Create a car and set its properties manually
            Car car = new Car
            {
                Engine = "V8 Engine",
                Wheels = "Alloy Wheels",
                Body = "Sports Body"
            };

            Console.WriteLine(car);
        }
    }
  // output :Car with Engine: V8 Engine, Wheels: Alloy Wheels, Body: Sports Body
}
