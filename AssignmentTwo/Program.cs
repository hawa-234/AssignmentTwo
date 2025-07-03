using System;

class StudentQuizSystem
{
    static void Main()
    {
        Console.WriteLine("Gali magaca: ");
        string name = Console.ReadLine();

        Console.WriteLine("Gali ID: ");
        string studentId = Console.ReadLine();

        Console.WriteLine("\nDooro nooca xisaabta:");
        Console.WriteLine("1. Kudar");
        Console.WriteLine("2. Kajar");
        Console.WriteLine("3. Isku dhufasho");
        Console.WriteLine("4. Qeyb");
        Console.Write("Doorashadaada (1-4): ");
        int choice = int.Parse(Console.ReadLine());

        string operation = "";
        switch (choice)
        {
            case 1: operation = "+"; break;
            case 2: operation = "-"; break;
            case 3: operation = "*"; break;
            case 4: operation = "/"; break;
            default:
                Console.WriteLine("Doorasho khaldan. Barnaamijka wuu xirayaa.");
                return;
        }

        int totalCorrect = 0;
        int totalWrong = 0;

        Console.WriteLine($"\n{operation} Xisaabta {name} ayaa bilaabatay...\n");

        Random rnd = new Random();

        for (int i = 1; i <= 10; i++)
        {
            int num1 = rnd.Next(10, 50);
            int num2 = rnd.Next(1, 20); // num2 never 0

            if (choice == 4)
                num1 = num1 - (num1 % num2); // ensure divisible

            double correctAnswer = 0;

            switch (choice)
            {
                case 1: correctAnswer = num1 + num2; break;
                case 2: correctAnswer = num1 - num2; break;
                case 3: correctAnswer = num1 * num2; break;
                case 4: correctAnswer = (double)num1 / num2; break;
            }

            Console.Write($"Q{i}: {num1} {operation} {num2} = ");
            string input = Console.ReadLine();
            double userAnswer;

            if (double.TryParse(input, out userAnswer))
            {
                if (Math.Abs(userAnswer - correctAnswer) < 0.001)
                {
                    Console.WriteLine("Sax ✅\n");
                    totalCorrect++;
                }
                else
                {
                    Console.WriteLine($"Khalad ❌. Jawaabta saxda ah: {correctAnswer}\n");
                    totalWrong++;
                }
            }
            else
            {
                Console.WriteLine($"Khalad ❌. Jawaab sax ah: {correctAnswer}\n");
                totalWrong++;
            }
        }

        // Final result in table format
        Console.WriteLine("NATIJADA:");
        Console.WriteLine("magaca\tID\tT.Sax\tT.Khl");
        Console.WriteLine($"{name}\t({studentId})\t{totalCorrect}\t{totalWrong}");
    }
}