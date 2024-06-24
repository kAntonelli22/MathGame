// See https://aka.ms/new-console-template for more information


using System.Diagnostics;

string? response;
Random dice = new();
Stopwatch stopwatch = new();

List<RoundData> history = new List<RoundData>();

void mainMenu()
{
    Console.WriteLine("Welcome to Math Game!\nWhat operation would you like?");

    Console.WriteLine("1. Addition\n2. Subtraction\n3. Multiplication\n4. Division");
    response = Console.ReadLine();

    if (response != null) 
        response.ToLower().Trim();

    if (response == "1" || response == "addition")
        additionGame();
    else if (response == "2" || response == "subtraction")
        subtractionGame();
    else if (response == "3" || response == "multiplication")
        multiplicationGame();
    else if (response == "4" || response == "division")
        divisionGame();
    else if (response == "exit")
        Environment.Exit(0);
    else
    {
        Console.WriteLine("Not a valid response. Please enter one of the four options or exit");
        mainMenu();
    }
} // end of main menu method


void additionGame()
{
    Console.WriteLine("Answer all five questions as quickly and correctly as possible");
    countdown();
    int correctlyAnswered = 0;
    List<string> questions = new List<string>();
    List<TimeSpan> times = new List<TimeSpan>();
    while (correctlyAnswered < 5) {
        int first = dice.Next(0, 10);
        int second = dice.Next(0, 10);
        int answer = first + second;
        string question = $"{first} + {second}";
        questions.Add(question);
        Console.Write($"{question} = ");

        int number = 0;
        stopwatch.Start();
        int.TryParse(Console.ReadLine(), out number);
        stopwatch.Stop();
        TimeSpan time = stopwatch.Elapsed;
        times.Add(time);
        if (number == answer)
            correctlyAnswered++;
        else
            Console.WriteLine("Wrong! the answer was: " + answer);
    }
    RoundData roundData = new(questions, times);
    history.Add(roundData);
    Console.WriteLine("Time: " + roundData.time + "Average per Question: " + roundData.avgTime);
    mainMenu();
} // end of addition method

void subtractionGame()
{
    Console.WriteLine("Answer all five questions as quickly and correctly as possible");
    countdown();
    int correctlyAnswered = 0;
    while (correctlyAnswered < 5) {
        int first = dice.Next(0, 10);
        int second = dice.Next(0, 10);
        int answer = first - second;
        string question = $"{first} - {second}";
        Console.Write($"{question} = ");

        int number = 0;
        int.TryParse(Console.ReadLine(), out number);
        if (number == answer)
            correctlyAnswered++;
        else
            Console.WriteLine("Wrong! the answer was: " + answer);
    }
    Console.WriteLine("Nice Job");
    mainMenu();
} // end of subtraction method

void multiplicationGame()
{
    Console.WriteLine("Answer all five questions as quickly and correctly as possible");
    countdown();
    int correctlyAnswered = 0;
    while (correctlyAnswered < 5) {
        int first = dice.Next(0, 10);
        int second = dice.Next(0, 10);
        int answer = first * second;
        string question = $"{first} * {second}";
        Console.Write($"{question} = ");

        int number = 0;
        int.TryParse(Console.ReadLine(), out number);
        if (number == answer)
            correctlyAnswered++;
        else
            Console.WriteLine("Wrong! the answer was: " + answer);
    }
    Console.WriteLine("Nice Job");
    mainMenu();
} // end of multiplication method

void divisionGame()
{
    Console.WriteLine("Answer all five questions as quickly and correctly as possible");
    countdown();
    int correctlyAnswered = 0;
    while (correctlyAnswered < 5) {
        int first = dice.Next(0, 10);
        int second = dice.Next(0, 10);
        int answer = first / second;
        string question = $"{first} / {second}";
        Console.Write($"{question} = ");
        
        int number = 0;
        int.TryParse(Console.ReadLine(), out number);
        if (number == answer)
            correctlyAnswered++;
        else
            Console.WriteLine("Wrong! the answer was: " + answer);
    }
    Console.WriteLine("Nice Job");
    mainMenu();
} // end of division method


void countdown()
{
    Console.Write("3"); Thread.Sleep(250); Console.Write("."); Thread.Sleep(250);
    Console.Write("."); Thread.Sleep(250); Console.Write(". "); Thread.Sleep(250);
    Console.Write("2"); Thread.Sleep(250); Console.Write("."); Thread.Sleep(250);
    Console.Write("."); Thread.Sleep(250); Console.Write(". "); Thread.Sleep(250);
    Console.Write("1"); Thread.Sleep(250); Console.Write("."); Thread.Sleep(250);
    Console.Write("."); Thread.Sleep(250); Console.Write(".\n"); Thread.Sleep(250);
}


mainMenu();