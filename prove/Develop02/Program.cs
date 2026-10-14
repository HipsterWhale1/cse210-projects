using System;

class Program
{
    //public List<Journal> _journals = new List<Journal>();
    //apparently better than just .\ 

    public static void Main()
    {
        Console.WriteLine("Program main:");
        Testing test = new Testing();
        test.TestFunction();
    }
    public void DisplayMenu()
    {
        //hello user! syudies and prophets have said its good to keep a journal
        //would you like to
        //read the whole journal? a specific entry? add a new entry? edit the prompts?
    }
    public void LoadJournal()
    {
        Console.WriteLine("Which journal do you want to load? (number value)");
        //put number in file path
        //if file doesnt exist, apologize. maybe list files that do exist
    }
    public void EditJournal()
    {
    }

    
}