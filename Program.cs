using System;
using SpaceObjectsLibrary;



class Program
{
    static void Main(string[] args)
    {
        var sun = new Star("Sun", "Yellow");
        var mercury = new Planet("Mercury", 57910, 87.97, "Gray");
        var venus = new Planet("Venus", 108200, 224.70, "Yellow");

        var earth = new Planet("Earth", 149600, 365.26, "Blue");
        var moon = new Moon("Moon", earth, 384, 27.32);
        earth.AddMoon(moon);

        var planets = new List<Planet> { mercury, venus, earth };

        Console.WriteLine("skriv inn antall dager siden tid 0: ");
        double days = Convert.ToDouble(Console.ReadLine());


        Console.WriteLine("skriv inn en planet, eller sol for solsystemet");
        string chosenName = Console.ReadLine();

        if (chosenName.Equals("Sun", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine($"viser solsystemet for {days} dager siden tid 0 ");

            foreach (var planet in planets)
            {
                var (x, y) = planet.CalculatePosition(days);
                Console.WriteLine($"{planet.Name} sin posisjon:" +
                    $" ({x:N2}, {y:N2})");


                

            }

        }
        else
        {
            var planet = planets.FirstOrDefault(p => p.Name.Equals(chosenName, StringComparison.OrdinalIgnoreCase));
            if (planet != null)
            {
                var (x, y) = planet.CalculatePosition(days);
                Console.WriteLine($"{planet.Name} psin posisjon {days} days: ({x:N2}, {y:N2})");

                
                foreach (var currentmoon in planet.Moons) // antar at du har lagt til måner til planeten 
                {
                    var (moonX, moonY) = currentmoon.CalculatePosition(days);
                    Console.WriteLine($" - {currentmoon.Name} position: ({moonX:N2}, {moonY:N2})");
                }
            }
            else
            {
                Console.WriteLine("Planet ikke funnet.");
            }
        }
    }
}

    
