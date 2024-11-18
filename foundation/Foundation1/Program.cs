using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Foundation1 World!");

        Video video1 = new Video("Cute Cats", "John Smith", 60);

        Comment comment1 = new Comment("I loved that video");

        video1.AddComment(comment1);

        Console.WriteLine ($"Title: {video1.GetTitle()}");
        Console.WriteLine ($"Author: {video1.getAuthor()}");
        Console.WriteLine ($"Lenght: {video1.getLength()}");
        Console.WriteLine($"Number of Comments: {video1.getNumberOfComments}");

        foreach (Comment comment in video1.getCommentsText())
        {
            Console.WriteLine($"{comment.GetName()}: {comment.GetText()}");
        }
    }    
}