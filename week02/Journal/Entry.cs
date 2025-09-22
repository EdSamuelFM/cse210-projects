using System;

public class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }
    public string Location { get; set; } // Additional creative feature
    public string Mood { get; set; } // Additional creative feature

    public Entry(string prompt, string response, string date, string location = "", string mood = "")
    {
        Prompt = prompt;
        Response = response;
        Date = date;
        Location = location;
        Mood = mood;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}");
        if (!string.IsNullOrEmpty(Location))
            Console.WriteLine($"Location: {Location}");
        if (!string.IsNullOrEmpty(Mood))
            Console.WriteLine($"Mood: {Mood}");
        Console.WriteLine("----------------------------");
    }

    public string ToCsvString()
    {
        // Proper CSV formatting with quotes and escaping
        return $"\"{EscapeCsvField(Date)}\",\"{EscapeCsvField(Prompt)}\",\"{EscapeCsvField(Response)}\",\"{EscapeCsvField(Location)}\",\"{EscapeCsvField(Mood)}\"";
    }

    private string EscapeCsvField(string field)
    {
        if (string.IsNullOrEmpty(field)) return "";
        // Escape quotes by doubling them and wrap in quotes if contains comma or quote
        string escaped = field.Replace("\"", "\"\"");
        if (escaped.Contains(",") || escaped.Contains("\"") || escaped.Contains("\n"))
            return $"\"{escaped}\"";
        return escaped;
    }

    public static Entry FromCsvString(string csvLine)
    {
        var fields = ParseCsvLine(csvLine);
        if (fields.Length >= 3)
        {
            string location = fields.Length > 3 ? fields[3] : "";
            string mood = fields.Length > 4 ? fields[4] : "";
            return new Entry(UnescapeCsvField(fields[1]), UnescapeCsvField(fields[2]), 
                           UnescapeCsvField(fields[0]), location, mood);
        }
        return null;
    }

    private static string[] ParseCsvLine(string csvLine)
    {
        var fields = new List<string>();
        bool inQuotes = false;
        int start = 0;

        for (int i = 0; i < csvLine.Length; i++)
        {
            if (csvLine[i] == '"')
            {
                inQuotes = !inQuotes;
            }
            else if (csvLine[i] == ',' && !inQuotes)
            {
                fields.Add(csvLine.Substring(start, i - start));
                start = i + 1;
            }
        }
        fields.Add(csvLine.Substring(start));

        // Remove surrounding quotes and unescape
        for (int i = 0; i < fields.Count; i++)
        {
            fields[i] = UnescapeCsvField(fields[i]);
        }

        return fields.ToArray();
    }

    private static string UnescapeCsvField(string field)
    {
        if (string.IsNullOrEmpty(field)) return "";
        field = field.Trim();
        if (field.StartsWith("\"") && field.EndsWith("\""))
        {
            field = field.Substring(1, field.Length - 2);
            field = field.Replace("\"\"", "\"");
        }
        return field;
    }
}