// ReflectionActivity.cs

public class ReflectionActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private List<string> _usedPrompts;
    private List<string> _usedQuestions;
    private Random _random;

    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
        _random = new Random();
        _usedPrompts = new List<string>();
        _usedQuestions = new List<string>();
    }

    public override void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        DisplayRandomPrompt();
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            DisplayRandomQuestion();
            ShowSpinner(10); // Pause for 10 seconds per question
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }

    private string GetRandomItem(List<string> sourceList, List<string> usedList)
    {
        if (!sourceList.Except(usedList).Any())
        {
            // All items have been used, so reset the used list
            usedList.Clear();
        }

        string item;
        do
        {
            int index = _random.Next(sourceList.Count);
            item = sourceList[index];
        } while (usedList.Contains(item));

        usedList.Add(item);
        return item;
    }

    public void DisplayRandomPrompt()
    {
        string prompt = GetRandomItem(_prompts, _usedPrompts);
        Console.WriteLine($"--- {prompt} ---");
    }

    public void DisplayRandomQuestion()
    {
        string question = GetRandomItem(_questions, _usedQuestions);
        Console.Write($"> {question} ");
    }
}