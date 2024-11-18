
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;

public class Video
{

    private string _title;
    private string _author;
    private double _lengthSeconds;
    private List<Comment> _comments;

    public Video(string title, string author, int seconds){
        _title = title;
        _author = author;
        _lengthSeconds = seconds;
        _comments = new List<Comment>();
    }


    public string GetTitle() => _title;
    public string GetAuthor() => _author;
    public double GetLength() => _lengthSeconds;
    public List<Comment> GetComments() => _comments;
    
    public void AddComment(Comment comment) => _comments.Add(comment);
   public int GetNumberOfComments() => _comments.Count;

}