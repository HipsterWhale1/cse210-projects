public class Entry

{
    public string _date = "";
    public List<string> _prompt = new List<string>();
    public string _response = "";

    public static void Display()
    {
        int myint = 1;
    }
    
    public void SetPromptList()
    {
        
    }
    public void GetERandomPrompt()
    {
        int myint = 1;
    }
    public void GetTodaysDate()
    {
        DateTime dayTime = DateTime.Today; 
        _date = dayTime.ToString();
        _date = _date[..^12]; 
    }
}