// Scripture: Keeps track of both the reference and the text of the scripture. Can hide words 
// and get the rendered display of the text.


using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

 public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        string[] wordsArray = text.Split(' ');

        foreach (string word in wordsArray)
        {
            _words.Add(new Word(word));
        }
    }

    public string GetDisplayText()
    {
        List<string> displayedWords = new List<string>();

        foreach (Word word in _words)
        {
            displayedWords.Add(word.GetDisplayText());
        }

        return $"{_reference.GetDisplayText()} {string.Join(" ", displayedWords)}";
    }

    public void HideRandomWords(int numberToHide)
    {
        Random rand = new Random();
        int hiddenCount = 0;

        while (hiddenCount < numberToHide && !IsCompletelyHidden())
        {
            int index = rand.Next(_words.Count);
            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                hiddenCount++;
            }
        }
    }


    public bool IsCompletelyHidden()
    {
       foreach (Word word in _words)
       {
            if (!word.IsHidden())
            {
                return false;
            }
       }
       return true;
    }

}