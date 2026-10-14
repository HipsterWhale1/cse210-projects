using System;

class Program
{
    public List<Journal> _journals = new List<Journal>();

    public static void Main(string[] args)
    {
        Console.WriteLine("hello, this is working");
        Entry testEntry = new Entry();
        testEntry.GetTodaysDate();
        Console.WriteLine(testEntry._date);
    }
    public void LoadJournal()
    {
        int myint = 1;
    }
    public void DisplayMenu()
    {
        int myint = 1;
    }
}