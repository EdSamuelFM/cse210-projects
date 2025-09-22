using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> entries;
    private List<string> prompts;

    public Journal()
    {
        entries = new List<Entry>();
        InitializePrompts();
    }

    private void InitializePrompts()
    {
        prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What made me smile today?",
            "What lesson did I learn today?",
            "What am I grateful for today?",
            "What challenge did I overcome today?",
            "How did I take care of myself today?"
        };
    }

    public void AddEntry(string response, string location = "", string mood = "")
    {
        string randomPrompt = GetRandomPrompt();
        string currentDate = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
        Entry newEntry = new Entry(randomPrompt, response, currentDate, location, mood);
        entries.Add(newEntry);
        Console.WriteLine("Entry added successfully!");
    }

    public void DisplayEntries()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No entries found. Start by writing a new entry!");
            return;
        }

        Console.WriteLine($"\n=== JOURNAL ENTRIES ({entries.Count} total) ===\n");
        for (int i = 0; i < entries.Count; i++)
        {
            Console.WriteLine($"Entry #{i + 1}:");
            entries[i].Display();
        }
    }

    public void SaveToFile(string filename)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                // Write CSV header
                writer.WriteLine("Date,Prompt,Response,Location,Mood");
                
                foreach (var entry in entries)
                {
                    writer.WriteLine(entry.ToCsvString());
                }
            }
            Console.WriteLine($"Journal saved successfully to {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    public void LoadFromFile(string filename)
    {
        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            var loadedEntries = new List<Entry>();
            using (StreamReader reader = new StreamReader(filename))
            {
                // Skip header
                string line = reader.ReadLine();
                
                while ((line = reader.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        Entry entry = Entry.FromCsvString(line);
                        if (entry != null)
                            loadedEntries.Add(entry);
                    }
                }
            }

            entries = loadedEntries;
            Console.WriteLine($"Journal loaded successfully from {filename}. Loaded {entries.Count} entries.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
        }
    }

    public int GetEntryCount()
    {
        return entries.Count;
    }

    public void DisplayJournalStats()
    {
        Console.WriteLine($"\n=== JOURNAL STATISTICS ===");
        Console.WriteLine($"Total entries: {entries.Count}");
        
        if (entries.Count > 0)
        {
            var earliestDate = entries.Min(e => DateTime.Parse(e.Date.Split(' ')[0]));
            var latestDate = entries.Max(e => DateTime.Parse(e.Date.Split(' ')[0]));
            Console.WriteLine($"Date range: {earliestDate:MM/dd/yyyy} to {latestDate:MM/dd/yyyy}");
            
            var moodCounts = entries.Where(e => !string.IsNullOrEmpty(e.Mood))
                                   .GroupBy(e => e.Mood)
                                   .ToDictionary(g => g.Key, g => g.Count());
            if (moodCounts.Any())
            {
                Console.WriteLine("Mood distribution:");
                foreach (var mood in moodCounts)
                {
                    Console.WriteLine($"  {mood.Key}: {mood.Value} entries");
                }
            }
        }
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        return prompts[random.Next(prompts.Count)];
    }

    public void AddCustomPrompt(string newPrompt)
    {
        if (!prompts.Contains(newPrompt))
        {
            prompts.Add(newPrompt);
            Console.WriteLine("Custom prompt added successfully!");
        }
    }
}