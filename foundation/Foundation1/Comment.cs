
public class Comment{

    private string _name;
    private string _commentText;

    public Comment(string name, string text)
    {
        _name = name;
        _commentText = text;
    }

    public string GetName() => _name;
    public string GetText() => _commentText;
    public void SetName(string name) => _name = name;
    public void SetText(string text) => _commentText = text;

}
