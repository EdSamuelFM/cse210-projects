using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();
        InitializeWords(text);
    }

    private void InitializeWords(string text)
    {
        string[] wordArray = text.Split(' ');
        foreach (string wordText in wordArray)
        {
            _words.Add(new Word(wordText));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        List<Word> visibleWords = _words.Where(word => !word.IsHidden).ToList();
        
        if (visibleWords.Count == 0) return;
        
        numberToHide = Math.Min(numberToHide, visibleWords.Count);
        
        for (int i = 0; i < numberToHide; i++)
        {
            int randomIndex = _random.Next(visibleWords.Count);
            visibleWords[randomIndex].Hide();
            visibleWords.RemoveAt(randomIndex); 
        }
    }

    public string GetDisplayText()
    {
        string displayText = _reference.GetDisplayText() + " ";
        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }
        return displayText.Trim();
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden);
    }

    public int VisibleWordCount()
    {
        return _words.Count(word => !word.IsHidden);
    }

    public int TotalWordCount()
    {
        return _words.Count;
    }

    // Creativity: Method to reveal some words if user is struggling
    public void RevealSomeWords(int numberToReveal)
    {
        List<Word> hiddenWords = _words.Where(word => word.IsHidden).ToList();
        numberToReveal = Math.Min(numberToReveal, hiddenWords.Count);
        
        for (int i = 0; i < numberToReveal; i++)
        {
            int randomIndex = _random.Next(hiddenWords.Count);
            hiddenWords[randomIndex].Reveal();
            hiddenWords.RemoveAt(randomIndex);
        }
    }
}