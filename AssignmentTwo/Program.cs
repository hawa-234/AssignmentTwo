using System;

class StudentQuizSystem
{
    static void Main()
    {
        string name, studentId;
        GetStudentInfo(out name, out studentId);

        string operation = ChooseOperation(out int choice);

        int totalCorrect, totalWrong, totalQuestions;
        totalQuestions = 10;

        RunQuiz(choice, totalQuestions, out totalCorrect, out totalWrong);

        PrintResult(name, studentId, totalCorrect, totalWrong, totalQuestions);
    }

    // Method 1: Xogta ardayga
    static void GetStudentInfo(out string name, out string studentId)
    {
        Console.Write("Gali magaca: ");
        name = Console.ReadLine();

        Console.Write("Gali ID: ");
        studentId = Console.ReadLine();
    }

    // Method 2: Dooro hawsha xisaabta
    static string ChooseOperation(out int choice)
    {
        Console.WriteLine("Dooro nooca xisaabta:");
        Console.WriteLine("1. Kudar");
        Console.WriteLine("2. Kajar");
        Console.WriteLine("3. Isku dhufasho");
        Console.WriteLine("4. Qayb");
        Console.Write("Doorashadaada (1-4): ");
        choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1: return "Kudar";
            case 2: return "Kajar";
            case 3: return "Isku dhufasho";
            case 4: return "Qayb";
            default:
                Console.WriteLine("Doorasho khaldan. Barnaamijku wuu xirmayaa.");
                Environment.Exit(0);
                return ""; // fallback
        }
    }

    // Method 3: Quiz-ka soconaya
    static void RunQuiz(int choice, int totalQuestions, out int totalCorrect, out int totalWrong)
    {
        totalCorrect = 0;
        totalWrong = 0;

        Random rnd = new Random();
        string symbol = "";

        for (int i = 1; i <= totalQuestions; i++)
        {
            int num1 = rnd.Next(10, 50);
            int num2 = rnd.Next(1, 20);
            int correctAnswer = 0;

            switch (choice)
            {
                case 1: correctAnswer = num1 + num2; symbol = "+"; break;
                case 2: correctAnswer = num1 - num2; symbol = "-"; break;
                case 3: correctAnswer = num1 * num2; symbol = "×"; break;
                case 4: correctAnswer = num1 / num2; symbol = "/"; break;
            }

            Console.Write($"Q{i}: {num1} {symbol} {num2} = ");
            int userAnswer = int.Parse(Console.ReadLine());

            if (userAnswer == correctAnswer)
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
    }

    // Method 4: Soo bandhig natiijada
    static void PrintResult(string name, string studentId, int totalCorrect, int totalWrong, int totalQuestions)
    {
        Console.WriteLine("\nNATIJADA:");
        Console.WriteLine("Magaca\tID\tT.Sax\tT.Khl");
        Console.WriteLine($"{name}\t({studentId})\t{totalCorrect}\t{totalWrong}");
        Console.WriteLine($"Waxaad ka heshay: {totalCorrect}/{totalQuestions}");
    }
}