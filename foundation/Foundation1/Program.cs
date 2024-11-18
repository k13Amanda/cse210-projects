using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Foundation1 World!");

        Video video1 = new Video("Cute Cats", "John Smith", 60);

        Comment comment1 = new Comment("Alice", "I loved that video");

        video1.AddComment(comment1);

        Console.WriteLine ($"Title: {video1.GetTitle()}");
        Console.WriteLine ($"Author: {video1.GetAuthor()}");
        Console.WriteLine ($"Lenght: {video1.GetLength()} seconds");
        Console.WriteLine($"Number of Comments: {video1.GetNumberOfComments()}");

        foreach (Comment comment in video1.GetComments())
        {
            Console.WriteLine($"{comment.GetName()}: {comment.GetText()}");
        }
    }    
}