using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool running = true;

        Console.WriteLine("=== WELCOME TO YOUR PERSONAL JOURNAL ===");
        Console.WriteLine("This program helps you maintain a consistent journaling habit!");

        while (running)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal);
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    SaveJournal(journal);
                    break;
                case "4":
                    LoadJournal(journal);
                    break;
                case "5":
                    journal.DisplayJournalStats();
                    break;
                case "6":
                    AddCustomPrompt(journal);
                    break;
                case "7":
                    running = false;
                    Console.WriteLine("Thank you for journaling! Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("\n=== JOURNAL MENU ===");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display journal entries");
        Console.WriteLine("3. Save journal to file");
        Console.WriteLine("4. Load journal from file");
        Console.WriteLine("5. Show journal statistics");
        Console.WriteLine("6. Add custom prompt");
        Console.WriteLine("7. Exit");
        Console.Write("Choose an option (1-7): ");
    }

    static void WriteNewEntry(Journal journal)
    {
        Console.WriteLine("\n=== NEW JOURNAL ENTRY ===");
        Console.WriteLine("Take a moment to reflect on your day...\n");

        Console.Write("Would you like to add location information? (y/n): ");
        string addLocation = Console.ReadLine().ToLower();
        string location = "";
        if (addLocation == "y" || addLocation == "yes")
        {
            Console.Write("Enter location: ");
            location = Console.ReadLine();
        }

        Console.Write("How are you feeling right now? (optional): ");
        string mood = Console.ReadLine();

        Console.WriteLine("\nTake a deep breath and think about today...");
        Console.WriteLine("Press any key when you're ready to write...");
        Console.ReadKey();
        Console.WriteLine();

        Console.WriteLine("Now, write about your day. When finished, press Enter twice:");
        string response = GetMultiLineInput();

        journal.AddEntry(response, location, mood);
    }

    static void SaveJournal(Journal journal)
    {
        Console.Write("Enter filename to save (e.g., myjournal.csv): ");
        string filename = Console.ReadLine();
        
        // Ensure .csv extension
        if (!filename.ToLower().EndsWith(".csv"))
            filename += ".csv";

        journal.SaveToFile(filename);
    }

    static void LoadJournal(Journal journal)
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();
        
        if (!File.Exists(filename))
        {
            Console.WriteLine("File does not exist. Please check the filename and try again.");
            return;
        }

        journal.LoadFromFile(filename);
    }

    static void AddCustomPrompt(Journal journal)
    {
        Console.Write("Enter your custom journal prompt: ");
        string prompt = Console.ReadLine();
        journal.AddCustomPrompt(prompt);
    }

    static string GetMultiLineInput()
    {
        string input = "";
        string line;
        int emptyLineCount = 0;

        while (true)
        {
            line = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
            {
                emptyLineCount++;
                if (emptyLineCount >= 2) // Two consecutive empty lines ends input
                    break;
            }
            else
            {
                emptyLineCount = 0;
                input += line + "\n";
            }
        }

        return input.Trim();
    }
}

/*
CREATIVITY AND EXCEEDED REQUIREMENTS:
1. Enhanced CSV Support: Properly handles commas, quotes, and multi-line content in CSV files
   that can be opened in Excel without formatting issues.

2. Additional Entry Information: Added location and mood tracking to provide more context
   to journal entries.

3. Journal Statistics: Provides insights like total entries, date range, and mood distribution
   to help users see patterns in their journaling habits.

4. Multi-line Input Support: Allows users to write longer entries with proper paragraph support.

5. Custom Prompts: Users can add their own journal prompts to personalize their experience.

6. User Experience Enhancements: 
   - Thoughtful prompts and pacing for reflection
   - Clear feedback on operations
   - Statistics to encourage consistent journaling
   - Proper error handling for file operations

7. Professional CSV Handling: Implements proper CSV parsing and escaping that handles:
   - Fields containing commas
   - Fields containing quotes
   - Multi-line content
   - Proper header format for Excel compatibility

These features address additional barriers to journaling such as:
- Lack of context about entries over time
- Desire for more personalized prompts
- Need for richer entry information
- Wanting to see patterns and insights from past entries
*/
