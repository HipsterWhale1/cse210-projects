using System;

class Testing
{
    public Entry _testEntry = new Entry();
    public Journal _testJournal = new Journal();
    public int count = -1;
    public TextReader _originalInput = Console.In;
    //main
    public void TestFunction()
    {
        Console.WriteLine("=> TestFunction():");

        TestEntryContents();
        TestGetRandomPrompt();
        TestDisplayPrompt();
        TestContinueEntry();
        TestGetTodaysDate();
        TestDisplayEntry();
        TestPrintEntryContents();
        TestSaveEntry();

        TestAddEntry();
        TestSaveCurrentEntry();
    }
    //#########TESTING ENTRY######
    //resetting class to default every time, so previous tests dont influence it
    public void ResetTestEntry()
    {
        _testEntry = new Entry();
        Console.SetIn(_originalInput);
    }
    public void TestEntryContents()
    {
        Console.WriteLine("=> TestEntryContents():");
        ResetTestEntry();
        
        count = Entry._prompts.Count();
        Console.WriteLine($"Size of entry.prompts is {count}");
    }
    public void TestGetRandomPrompt()
    {
        Console.WriteLine("=> TestGetRandomPrompt():");
        ResetTestEntry();

        TestGetRandomPrompt2();
        TestGetRandomPrompt2();
        TestGetRandomPrompt2();
    }
    public void TestGetRandomPrompt2()
    {
        //no print statement of funtion, since its part of TestGetRandomPrompt()
        Console.WriteLine($"_prompt before GetRandomPrompt(): {_testEntry._prompt}");
        _testEntry.GetRandomPrompt();
        Console.WriteLine($"_prompt after GetRandomPrompt(): {_testEntry._prompt}");
    }
    public void TestDisplayPrompt()
    {
        Console.WriteLine("=> TestDisplayPrompt():");
        ResetTestEntry();

        Console.SetIn(new StringReader("yes"));
        _testEntry.DisplayPrompt();
        Console.WriteLine($"_entryContents contains another prompt: ");
        _testEntry.PrintEntryContents();
    }
    public void TestContinueEntry()
    {
        Console.WriteLine("=> TestContinueEntry():");
        ResetTestEntry();

        //input to continue journaling
        //Console.SetIn(new StringReader("yes"));
        //loops 4 times, ends on the 4th
        Console.SetIn(new StringReader("yes\nyes\nyes\nno\nyes"));
        while (_testEntry._continueJournaling == true)
        {
            _testEntry.ContinueEntry();
        }
    }
    public void TestGetTodaysDate()
    {
        Console.WriteLine("=> TestGetTodaysDate():");
        ResetTestEntry();

        _testEntry.GetTodaysDate();
        Console.WriteLine(_testEntry._date);
    }
    public void TestDisplayEntry()
    {
        Console.WriteLine("=> TestDisplayEntry():");
        ResetTestEntry();

        //resetting _entryContents to what it would be (after modifying it in tests above)
        _testEntry._entryContents.Clear();
        _testEntry._continueJournaling = true;
        Console.SetIn(_originalInput);
        //yes to prompt, journal entry content, no to continue, yes to confirm
        Console.SetIn(new StringReader("yes\nToday was really great! We had a great time lorem ipsum\nno\nyes"));
        Console.WriteLine("DisplayEntry():");
        _testEntry.DisplayEntry();
    }
    public void TestPrintEntryContents()
    {
        Console.WriteLine("=> TestPrintEntryContents():");
        ResetTestEntry();

        _testEntry._entryContents.Clear();
        _testEntry._continueJournaling = true;
        _testEntry._entryContents.Add("this is element 1");
        _testEntry._entryContents.Add("this is element 2");
        _testEntry._entryContents.Add("this is element 3");
        _testEntry._entryContents.Add("this is element 4");
        _testEntry.PrintEntryContents();
    }
    public void TestSaveEntry()
    {
        Console.WriteLine("=> TestPrintEntryContents():");
        ResetTestEntry();

        _testEntry._filePath = $"{AppContext.BaseDirectory}test_journal_entry_.txt";
        //populating necessary values
        _testEntry.GetTodaysDate();
        _testEntry._entryContents.Add("this is element 1 lorem ipsum");
        _testEntry.SaveEntry();
    }
    
    //#########END TESTING ENTRY######

    //#########TESTING JOURNAL######
    public void TestAddEntry()
    {
        Console.WriteLine("=> TestAddEntry():");

        int size;
        _testJournal.AddEntry();
        size = _testJournal._entries.Count();
        Console.WriteLine(_testJournal._entries[Random.Shared.Next(0, size)]);
    }
    public void TestSaveCurrentEntry()
    {
        Console.WriteLine("=> TestSaveJournal():");
        //yes to prompt, journal entry content, no to continue, yes to confirm
        Console.SetIn(new StringReader("yes\nToday was really great! We had a great time lorem ipsum (save to file)\nno\nyes"));
        _testJournal._entries[0].GetTodaysDate();
        _testJournal._entries[0].DisplayEntry();
        Console.WriteLine("Start of actual SaveJournal() call"); 
        _testJournal.SaveCurrentEntry();
        Console.WriteLine("Reached end of testSaveJournal");  
    }
}