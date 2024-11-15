using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    // Dictionary för att lagra elevnamn och deras betyg
    private Dictionary<string, int> studentBetyg = new Dictionary<string, int>();

    public void Main()
    {
        studentBetyg.Add("Alice", 85);
        studentBetyg.Add("Bob", 78);
        studentBetyg.Add("Charlie", 92);
        bool avsluta = false;

        while (!avsluta)
        {
            Console.WriteLine("\nVälj ett alternativ:");
            Console.WriteLine("1. Lägg till en elev och deras betyg");
            Console.WriteLine("2. Uppdatera en elevs betyg");
            Console.WriteLine("3. Visa alla elever och deras betyg");
            Console.WriteLine("4. Beräkna och visa medelbetyget");
            Console.WriteLine("5. Avsluta");

            string val = Console.ReadLine();

            switch (val)
            {
                case "1":
                    LäggTillElev();
                    break;
                case "2":
                    UppdateraBetyg();
                    break;
                case "3":
                    VisaAllaElever();
                    break;
                case "4":
                    VisaMedelbetyg();
                    break;
                case "5":
                    avsluta = true;
                    break;
                default:
                    Console.WriteLine("Ogiltigt val, försök igen.");
                    break;
            }
        }
    }

    public void LäggTillElev()
    {
        Console.Write("Ange elevens namn: ");
        string namn = Console.ReadLine();

        int betyg;
        while (true)
        {
            Console.Write("Ange elevens betyg (0-100): ");
            if (int.TryParse(Console.ReadLine(), out betyg) && betyg >= 0 && betyg <= 100)
            {
                break;
            }
            else
            {
                Console.WriteLine("Ogiltigt betyg, ange ett tal mellan 0 och 100.");
            }
        }

        if (studentBetyg.ContainsKey(namn))
        {
            Console.WriteLine("Eleven finns redan. Använd alternativet för att uppdatera betyg.");
        }
        else
        {
            studentBetyg.Add(namn, betyg);
            Console.WriteLine($"Betyget för {namn} har lagts till.");
        }
    }

    public void UppdateraBetyg()
    {
        Console.Write("Ange elevens namn för att uppdatera betyget: ");
        string namn = Console.ReadLine();

        if (studentBetyg.ContainsKey(namn))
        {
            Console.Write("Ange det nya betyget (0-100): ");
            int nyttBetyg;
            while (!int.TryParse(Console.ReadLine(), out nyttBetyg) || nyttBetyg < 0 || nyttBetyg > 100)
            {
                Console.Write("Ogiltigt betyg, ange ett tal mellan 0 och 100: ");
            }
            studentBetyg[namn] = nyttBetyg;
            Console.WriteLine($"Betyget för {namn} har uppdaterats.");
        }
        else
        {
            Console.WriteLine("Eleven hittades inte.");
        }
    }

    public void VisaAllaElever()
    {
        if (studentBetyg.Count == 0)
        {
            Console.WriteLine("Inga elever finns i systemet.");
        }
        else
        {
            Console.WriteLine("\nElever och deras betyg:");
            foreach (var elev in studentBetyg)
            {
                Console.WriteLine($"Namn: {elev.Key}, Betyg: {elev.Value}");
            }
        }
    }

    public void VisaMedelbetyg()
    {
        if (studentBetyg.Count == 0)
        {
            Console.WriteLine("Inga elever finns i systemet.");
        }
        else
        {
            double medelbetyg = studentBetyg.Values.Average();
            Console.WriteLine($"Medelbetyget för alla elever är: {medelbetyg:F2}");
        }
    }
}

// Starta programmet
public static class Start
{
    public static void Main()
    {
        Program program = new Program();
        program.Main();
    }
}
