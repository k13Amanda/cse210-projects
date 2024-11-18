
public class Comment{

    private string _name;
    private string _commentText;

    public Comment(string name, string text){
        _name = name;
        _commentText = text;
    }


    public string getName() => _name;
    public string getText() => _commentText;
    public void setName(string name) => _name = name;
    public void setText(string text) => _commentText = text;

}
