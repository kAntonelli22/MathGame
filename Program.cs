// See https://aka.ms/new-console-template for more information


using System.Diagnostics;

string? response;
Random dice = new();
Stopwatch stopwatch = new();

List<RoundData> history = new List<RoundData>();

void mainMenu()
{
    Console.WriteLine("Welcome to Math Game!\nWhat operation would you like?");

    Console.WriteLine("1. Addition\n2. Subtraction\n3. Multiplication\n4. Division\n5. Random\n6. Game History");
    response = Console.ReadLine();

    if (response != null) 
        response.ToLower().Trim();


    if (response == "1" || response == "2" || response == "3" ||response == "4" || response == "5")
        gameRound(response);
    else if (response == "6")
    {
        foreach (RoundData round in history)
            Console.WriteLine(round.ToString());
        Console.WriteLine("press enter to return to menu");
        Console.ReadLine();
        mainMenu();
    }
    else if (response == "exit")
        Environment.Exit(0);
    else
    {
        Console.WriteLine("Not a valid response. Please enter one of the four options or exit");
        mainMenu();
    }
} // end of main menu method

void gameRound(string response)
{
    Console.WriteLine("Answer all five questions as quickly and correctly as possible");
    countdown();
    int correctlyAnswered = 0;
    List<string> questions = new List<string>();
    List<TimeSpan> times = new List<TimeSpan>();
    while (correctlyAnswered < 5) {
        var tuple = new Tuple<int, string>(0, "");
        // choose random sign if user selected random
        if (response == "5")
            tuple = createEquation($"{dice.Next(1, 5)}");
        else
            tuple = createEquation(response);
        // add question to list of questions
        questions.Add(tuple.Item2);
        Console.Write(tuple.Item2);

        // start stop watch and wait for user response
        int userAnswer = 0;
        stopwatch.Start();
        int.TryParse(Console.ReadLine(), out userAnswer);
        // get the time elasped then reset the stopwatch and add the time to a list
        TimeSpan time = stopwatch.Elapsed;
        stopwatch.Reset();
        times.Add(time);
        // check the users answer
        if (userAnswer == tuple.Item1)
            correctlyAnswered++;
        else
            Console.WriteLine("Wrong! the answer was: " + tuple.Item1);
    }
    RoundData roundData = new(questions, times);
    history.Add(roundData);
    Console.WriteLine("Time: " + roundData.time + "Average per Question: " + roundData.avgTime);
    mainMenu();
} // end of game round method

Tuple<int, string> createEquation(string response)
{
    int first = dice.Next(0, 100);
    int second = dice.Next(0, 100);
    if (response == "4")
    {
        while (first == 0 || second == 0 || first % second != 0)
        {
            first = dice.Next(0, 100);
            second = dice.Next(0, 100);
        }
    }
    switch (response)
    {
        case "1":
            first = dice.Next(0, 50);
            second = dice.Next(0, 50);
            return new Tuple<int, string>(first + second, $"{first} + {second} = ");
        case "2":
            first = dice.Next(0, 20);
            second = dice.Next(0, 20);
            return new Tuple<int, string>(first - second, $"{first} - {second} = ");
        case "3":
            first = dice.Next(0, 15);
            second = dice.Next(0, 15);
            return new Tuple<int, string>(first * second, $"{first} * {second} = ");
        default:
            return new Tuple<int, string>(first / second, $"{first} / {second} = ");
    }
}

void countdown()
{
    Console.Write("3"); Thread.Sleep(250); Console.Write("."); Thread.Sleep(250);
    Console.Write("."); Thread.Sleep(250); Console.Write(". "); Thread.Sleep(250);
    Console.Write("2"); Thread.Sleep(250); Console.Write("."); Thread.Sleep(250);
    Console.Write("."); Thread.Sleep(250); Console.Write(". "); Thread.Sleep(250);
    Console.Write("1"); Thread.Sleep(250); Console.Write("."); Thread.Sleep(250);
    Console.Write("."); Thread.Sleep(250); Console.Write(".\n"); Thread.Sleep(250);
}

// starts game
mainMenu();