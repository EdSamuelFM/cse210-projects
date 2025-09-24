// ScriptureMemorizer (Creativity: Enhanced user experience)
using System;

public class ScriptureMemorizer
{
    private ScriptureLibrary _library;
    private DifficultyLevel _difficulty;

    public ScriptureMemorizer(ScriptureLibrary library)
    {
        _library = library;
        _difficulty = DifficultyLevel.Medium;
    }

    public void Start()
    {
        Console.WriteLine("Welcome to Scripture Memorizer!");
        Console.WriteLine("===============================");
        
        SelectDifficulty();
        
        while (_library.HasScriptures())
        {
            Scripture scripture = _library.GetRandomScripture();
            MemorizeScripture(scripture);
            
            Console.Write("\nWould you like to practice another scripture? (y/n): ");
            if (Console.ReadLine().ToLower() != "y")
                break;
        }
        
        Console.WriteLine("\nThank you for using Scripture Memorizer!");
    }

    private void SelectDifficulty()
    {
        Console.WriteLine("\nSelect difficulty level:");
        Console.WriteLine("1. Easy (hide 1-2 words at a time)");
        Console.WriteLine("2. Medium (hide 2-3 words at a time)");
        Console.WriteLine("3. Hard (hide 3-5 words at a time)");
        Console.Write("Enter choice (1-3): ");
        
        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1": _difficulty = DifficultyLevel.Easy; break;
            case "2": _difficulty = DifficultyLevel.Medium; break;
            case "3": _difficulty = DifficultyLevel.Hard; break;
            default: _difficulty = DifficultyLevel.Medium; break;
        }
    }

    private void MemorizeScripture(Scripture scripture)
    {
        Console.Clear();
        
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Difficulty: {_difficulty}");
            Console.WriteLine($"Progress: {CalculateProgress(scripture)}% hidden");
            Console.WriteLine("====================\n");
            
            Console.WriteLine(scripture.GetDisplayText());
            
            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nAll words are hidden! Great job memorizing!");
                break;
            }
            
            Console.WriteLine("\nOptions:");
            Console.WriteLine("- Press ENTER to hide more words");
            Console.WriteLine("- Type 'reveal' to show some hidden words");
            Console.WriteLine("- Type 'quit' to exit");
            Console.Write("Your choice: ");
            
            string input = Console.ReadLine().ToLower();
            
            if (input == "quit")
                break;
            else if (input == "reveal")
            {
                // Creativity: Allow revealing words if user is struggling
                scripture.RevealSomeWords(2);
            }
            else
            {
                int wordsToHide = GetWordsToHide();
                scripture.HideRandomWords(wordsToHide);
            }
        }
    }

    private int GetWordsToHide()
    {
        Random random = new Random();
        switch (_difficulty)
        {
            case DifficultyLevel.Easy: return random.Next(1, 3);
            case DifficultyLevel.Medium: return random.Next(2, 4);
            case DifficultyLevel.Hard: return random.Next(3, 6);
            default: return 2;
        }
    }

    private double CalculateProgress(Scripture scripture)
    {
        return Math.Round(((double)(scripture.TotalWordCount() - scripture.VisibleWordCount()) / scripture.TotalWordCount()) * 100);
    }
}

public enum DifficultyLevel
{
    Easy,
    Medium,
    Hard
}