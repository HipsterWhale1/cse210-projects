using System;

class Program
{
    public List<Journal> _journals = new List<Journal>();
    public Journal firstJournal = new Journal();
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

        firstJournal.LoadEntries();
        //Lets Journal! Press any key to continue. You may also edit an old entry, or view the entire journal.
        // AddEntry(); EditEntry(); DisplayJournal(); 
        //save entry?
        //saveCurrentEntry (actually, take a look at this, do i need all this? thats a lot of writing files that have no changes
        //also if i want to, add function to edit the prompts
    }
    public void LoadJournal()
    {
        Console.WriteLine("Which journal do you want to load? (number value)");
        //put number in file path
        //if file doesnt exist, apologize. maybe list files that do exist
    }
}