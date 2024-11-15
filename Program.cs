using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    // Dictionary för att lagra elever och deras betyg, där nyckeln är elevens namn och värdet är deras betyg.
    private Dictionary<string, int> studentBetyg = new Dictionary<string, int>();

    // Den statiska metoden Main är startpunkten för programmet.
    public static void Main()
    {
        // Skapar en instans av Program-klassen för att kunna anropa icke-statiska metoder.
        Program program = new Program();

        // Anropar metoden Run som innehåller huvudlogiken för programmet.
        program.Run();
    }

    // Metod som innehåller huvudlogiken för programmet.
    public void Run()
    {
        // Lägger till några exempeldata i dictionaryn.
        studentBetyg.Add("Alice", 85);
        studentBetyg.Add("Bob", 78);
        studentBetyg.Add("Charlie", 92);

        // Variabel för att kontrollera när användaren vill avsluta programmet.
        bool avsluta = false;

        // Startar en loop som fortsätter tills användaren väljer att avsluta.
        while (!avsluta)
        {
            // Skriver ut huvudmenyn till användaren.
            Console.WriteLine("\nVälj ett alternativ:");
            Console.WriteLine("1. Lägg till en elev och deras betyg");
            Console.WriteLine("2. Uppdatera en elevs betyg");
            Console.WriteLine("3. Visa alla elever och deras betyg");
            Console.WriteLine("4. Beräkna och visa medelbetyget");
            Console.WriteLine("5. Avsluta");

            // Läser användarens val från tangentbordet.
            string val = Console.ReadLine();

            // Switch-sats som utför olika åtgärder beroende på användarens val.
            switch (val)
            {
                case "1":
                    LäggTillElev(); // Anropar metoden för att lägga till en elev.
                    break;
                case "2":
                    UppdateraBetyg(); // Anropar metoden för att uppdatera en elevs betyg.
                    break;
                case "3":
                    VisaAllaElever(); // Anropar metoden för att visa alla elever och deras betyg.
                    break;
                case "4":
                    VisaMedelbetyg(); // Anropar metoden för att beräkna och visa medelbetyget.
                    break;
                case "5":
                    avsluta = true; // Sätter avsluta till true för att avsluta loopen.
                    break;
                default:
                    Console.WriteLine("Ogiltigt val, försök igen."); // Visar felmeddelande om valet är ogiltigt.
                    break;
            }
        }
    }

    // Metod för att lägga till en ny elev och deras betyg.
    public void LäggTillElev()
    {
        // Ber användaren ange elevens namn.
        Console.Write("Ange elevens namn: ");
        string namn = Console.ReadLine();

        int betyg;

        // Loop för att säkerställa att användaren anger ett giltigt betyg.
        while (true)
        {
            Console.Write("Ange elevens betyg (0-100): ");

            // Kontrollerar att inmatningen är ett heltal mellan 0 och 100.
            if (int.TryParse(Console.ReadLine(), out betyg) && betyg >= 0 && betyg <= 100)
            {
                break; // Avslutar loopen om inmatningen är giltig.
            }
            else
            {
                Console.WriteLine("Ogiltigt betyg, ange ett tal mellan 0 och 100."); // Visar felmeddelande om inmatningen är ogiltig.
            }
        }

        // Kontroll om elevens namn redan finns i dictionaryn.
        if (studentBetyg.ContainsKey(namn))
        {
            Console.WriteLine("Eleven finns redan. Använd alternativet för att uppdatera betyg.");
        }
        else
        {
            // Lägger till elevens namn och betyg i dictionaryn.
            studentBetyg.Add(namn, betyg);
            Console.WriteLine($"Betyget för {namn} har lagts till.");
        }
    }

    // Metod för att uppdatera en befintlig elevs betyg.
    public void UppdateraBetyg()
    {
        // Ber användaren ange namnet på eleven vars betyg ska uppdateras.
        Console.Write("Ange elevens namn för att uppdatera betyget: ");
        string namn = Console.ReadLine();

        // Kontroll om elevens namn finns i dictionaryn.
        if (studentBetyg.ContainsKey(namn))
        {
            Console.Write("Ange det nya betyget (0-100): ");
            int nyttBetyg;

            // Loop för att säkerställa att användaren anger ett giltigt betyg.
            while (!int.TryParse(Console.ReadLine(), out nyttBetyg) || nyttBetyg < 0 || nyttBetyg > 100)
            {
                Console.Write("Ogiltigt betyg, ange ett tal mellan 0 och 100: ");
            }

            // Uppdaterar elevens betyg i dictionaryn.
            studentBetyg[namn] = nyttBetyg;
            Console.WriteLine($"Betyget för {namn} har uppdaterats.");
        }
        else
        {
            Console.WriteLine("Eleven hittades inte."); // Visar felmeddelande om eleven inte finns.
        }
    }

    // Metod för att visa alla elever och deras betyg.
    public void VisaAllaElever()
    {
        // Kontrollerar om dictionaryn är tom.
        if (studentBetyg.Count == 0)
        {
            Console.WriteLine("Inga elever finns i systemet.");
        }
        else
        {
            Console.WriteLine("\nElever och deras betyg:");

            // Loopar genom dictionaryn och visar varje elevs namn och betyg.
            foreach (var elev in studentBetyg)
            {
                Console.WriteLine($"Namn: {elev.Key}, Betyg: {elev.Value}");
            }
        }
    }

    // Metod för att beräkna och visa medelbetyget för alla elever.
    public void VisaMedelbetyg()
    {
        // Kontrollerar om dictionaryn är tom.
        if (studentBetyg.Count == 0)
        {
            Console.WriteLine("Inga elever finns i systemet.");
        }
        else
        {
            // Beräknar medelbetyget som ett decimaltal.
            double medelbetyg = studentBetyg.Values.Average();

            // Visar medelbetyget med två decimaler.
            Console.WriteLine($"Medelbetyget för alla elever är: {medelbetyg:F2}");
        }
    }
}
