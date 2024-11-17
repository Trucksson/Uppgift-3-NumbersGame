using System;

namespace NumbersGame
{
    internal class Program // 
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int targetNumber = random.Next(1, 21); // Slumpmässigt nummer mellan 1 och 20
            int userGuess = 0;
            int maxAttempts = 5; // Max antal gissningar = 5
            int attempts = 0;

            Console.WriteLine("Välkommen!");
            Console.WriteLine("Jag tänker på ett nummer mellan 1 och 20.");
            Console.WriteLine("Kan du gissa vilket? Du får 5 försök.");

            while (userGuess != targetNumber)
            {
                Console.Write("Skriv in din gissning: ");

                if (int.TryParse(Console.ReadLine(), out userGuess)) // Konverterar inmatningen till heltal 
                {
                    if (userGuess < 1 || userGuess > 20) // Om gissningen är utanför intervallet
                    {
                        Console.WriteLine("Vänligen ange ett nummer mellan 1 och 20.");
                        continue;
                    }
                    attempts++; // Ökar antalet försök 

                    //metoden CheckGuess för att få feedback
                    string feedback = CheckGuess(userGuess, targetNumber);

                    Console.WriteLine(feedback);

                    if (userGuess == targetNumber)
                        break;

                    if (attempts == maxAttempts)
                        Console.WriteLine("Tyvärr, du lyckades inte gissa talet på 5 försök.");
                }
                else
                {
                    Console.WriteLine("Vänligen ange ett tal mellan 1 och 20.");
                }

                if (userGuess != targetNumber && attempts >= maxAttempts)
                {
                    Console.WriteLine("Tyvärr, det var alla försök.");
                    Console.WriteLine($"Det rätta numret var {targetNumber}.");
                }
            }

            Console.WriteLine("Tack för att du spelade!");
            Console.ReadLine();
        }

        // Metod för att kontrollera användarens gissning
        static string CheckGuess(int userGuess, int targetNumber)
        {
            if (userGuess < targetNumber)
                return "Tyvärr, du gissade för lågt.";
            else if (userGuess > targetNumber)
                return "Tyvärr, du gissade för högt.";
            else
                return "Wohoo, du klarade det!";
        }
    }
}