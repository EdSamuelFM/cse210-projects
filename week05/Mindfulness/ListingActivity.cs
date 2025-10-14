public class ListingActivity : Activity
{
    private List<string> _prompts;
    private Random _random;
    private List<string> _usedPrompts;

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
        _random = new Random();
        _usedPrompts = new List<string>();
    }

    public override void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("List as many responses as you can to the following prompt:");
        DisplayRandomPrompt();
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        List<string> userList = GetListFromUser();
        Console.WriteLine($"You listed {userList.Count} items!");

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        if (!_prompts.Except(_usedPrompts).Any())
        {
            _usedPrompts.Clear();
        }
        string prompt;
        do
        {
            int index = _random.Next(_prompts.Count);
            prompt = _prompts[index];
        } while (_usedPrompts.Contains(prompt));
        
        _usedPrompts.Add(prompt);
        return prompt;
    }

    private void DisplayRandomPrompt()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine($"--- {prompt} ---");
    }

    private List<string> GetListFromUser()
    {
        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrEmpty(item))
            {
                items.Add(item);
            }
        }
        return items;
    }

}
