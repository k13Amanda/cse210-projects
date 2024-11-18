using System;

class Program
{
    static void Main(string[] args)
    {

        List<Video> videos = new List<Video>();

        Video video1 = new Video("Cute Cats", "John Smith", 60);
        video1.AddComment (new Comment("Alice", "I loved that video"));
        video1.AddComment (new Comment("Adam", "That video was awesome"));
        video1.AddComment (new Comment("Susan", "I love cats also"));
        video1.AddComment (new Comment("Ben", "That was so cute"));
        videos.Add(video1);

        Video video2 = new Video("Cute Dogs", "Alex Johnson", 70);
        video2.AddComment (new Comment("Sam", "That dog video was awesome"));
        video2.AddComment (new Comment("Sue", "I love dogs also"));
        video2.AddComment (new Comment("Nephi", "Those were some cute dogs"));
        videos.Add(video2);

        Video video3 = new Video("Cool Science", "Amy Adams", 110);
        video3.AddComment (new Comment("Kaden", "I loved that video"));
        video3.AddComment (new Comment("Landon", "That video was awesome"));
        video3.AddComment (new Comment("Susan", "I love Science"));
        video3.AddComment (new Comment("Adam", "That was so cool"));
        videos.Add(video3);

        Video video4 = new Video("How to make a Paper Airplane", "Frank Colter", 90);
        video4.AddComment (new Comment("Jaxon", "I loved that first airplane"));
        video4.AddComment (new Comment("Carson", "That video was so helpful"));
        video4.AddComment (new Comment("Ben", "Those were some awesome airplanes"));
        videos.Add(video4);


        foreach (Video video in videos)
            { 
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"{comment.GetName()}: {comment.GetText()}");
            }

        Console.WriteLine("");
        }    
    }    
}