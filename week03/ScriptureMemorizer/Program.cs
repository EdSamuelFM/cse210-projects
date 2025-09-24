using System;

class Program
{
    static void Main(string[] args)
    {
        // Demonstration of creativity and exceeding requirements:
        // 1. Scripture library with multiple scriptures
        // 2. Random scripture selection
        // 3. Difficulty levels (easy, medium, hard) that control how many words are hidden each time
        // 4. Progress tracking showing percentage of words hidden
        // 5. Ability to reveal words again if user struggles
        
        ScriptureLibrary library = new ScriptureLibrary();
        library.AddScripture(new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");
        library.AddScripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.");
        library.AddScripture(new Reference("Philippians", 4, 13), "I can do all this through him who gives me strength.");
        library.AddScripture(new Reference("Psalm", 23, 1, 6), "The Lord is my shepherd, I lack nothing. He makes me lie down in green pastures, he leads me beside quiet waters, he refreshes my soul. He guides me along the right paths for his name's sake.");
        
        ScriptureMemorizer memorizer = new ScriptureMemorizer(library);
        memorizer.Start();
    }
}
