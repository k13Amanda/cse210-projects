// Reference: Keeps track of the book, chapter, and verse information.


using System.Runtime.CompilerServices;


public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;


    public string Book
    { 
    get { return _book; }
    set { _book = value; }
    }
    public int Chapter{
    get { return _chapter; }
    set { _chapter = value; }   
    }
    public int Verse
    {
    get { return _verse; }
    set { _verse = value; }
    }
    public int EndVerse
    {
    get { return _endVerse; }
    set { _endVerse = value; }
    }


    public Reference( string book, int chapter, int verse, int endVerse)
    {
    _book = book;
    _chapter = chapter;
    _verse = verse;
    _endVerse = endVerse;
    }

    public Reference( string book, int chapter, int verse)
    {
    _book = book;
    _chapter = chapter;
    _verse = verse;
    EndVerse = 0;
    }

    public string GetDisplayText()
    {
        if (_endVerse > 0)
        {
            return $"{Book} {Chapter}:{Verse}-{EndVerse}";
        }
        else
        {
            return $"{Book} {Chapter}:{Verse}";
        }
    }
}