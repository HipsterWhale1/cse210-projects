using System.IO;

public class Journal
{
    //apparently better than just .\
    public static string _folder = AppContext.BaseDirectory;
    //AppDomain.CurrentDomain.BaseDirectory;
    string _fileName = "journal_entry_";
    string _extension = ".txt";
    public Entry _currentEntry;
    public List<Entry> _entries = new List<Entry>();
    //prints all entries
    public Journal()
    {
        Directory.CreateDirectory(_folder);
    }
    public void LoadEntries()
    {
        int fileCount = Directory.GetFiles(_folder).Length;
        int fileCounter = 0;
        int sectionCounter = 0;
        int lineCounter = 1;
        List<string> textFile;

        while (fileCounter < fileCount)
        {
            string filePath = $"{_folder}{_fileName}{fileCounter}{_extension}";

            textFile = File.ReadAllLines(filePath);
            //setting _date as first line
            _entries[fileCounter]._date = textFile[0];
            //filling out _entryContent
            while (textFile[lineCounter] != null)
            {
                if (textFile[lineCounter][^1] == "&")
                {
                    entryCounter++;
                }
                else
                {
                    _entries[fileCounter]._entryContents[sectionCounter] = textFile[lineCounter];
                    lineCounter++;
                }
            }
            sectionCounter = 0;
            lineCounter = 1;
        }
    }
    public void AddEntry()
    {
        int newest = _entries.Count;
        if (_entries[newest]._date == DateTime.Today.ToString("MM/dd/yyyy"))
        {
            _currentEntry = _entries[newest];
        }
        else
        {
            _currentEntry = new Entry();
            _entries.Add(_currentEntry);
        }
    }
    public void EditEntry()
    {
        ChooseEntry1();
        _currentEntry.DisplayPrompt();
        _currentEntry.ContinueEntry();
        //do you want to view entry before saving?
        //DisplayEntry()
        //do you want to save entry?
        //SaveEntry()
        //ask or warn about overwrites if file already exists
        //double check that adding to an entry is adding at end of list containing original entry contents

    }
    public void DisplayJournal()
    {
        foreach(Entry entryElement in _entries)
        {
            Console.WriteLine(entryElement._date);
            foreach(string element in entryElement._entryContents)
            {
                if (element^[1] == "&")
                {
                    element = element.Substring(0, element.length - 1);
                }
                    Console.WriteLine(element);
            }
        }
    }
    //called in EditEntry()
    public void ChooseEntry1()
    {
        int fileCount = Directory.EnumerateFiles(_folder).Count;
        //debugging
        if (fileCount != _entries.Count)
        {
            Console.WriteLine($"fileCount is {fileCount} but _entries.Count is {_entries.Count}");
        }
        Console.Write($"there are {fileCount} entries in your journal.");
        
        foreach (Entry entryElement in _entries);
        {
            int entryCount = 0;
            Console.Writeline($"Entry {entryCount}: {entryElement._date}");
            entryCount++;
        }
        ChooseEntry(entryCount);
    }
    public void ChooseEntry2(int entryCount)
    {
        Console.WriteLine("Which entry do you want to edit? (choose a number from above)");
        string response = Console.ReadLine();
        if (response >= 0 && response <= entryCount)
        {
            _currentEntry = _entries[response];
        }
        else
        {
            Console.Writeline("Do you want to edit an existing entry? yes/no");
            response = Console.ReadLine();
            if (response == "yes")
            {
                ChooseEntry();
            }
            //else nothing
        }
    }
    public void SaveCurrentEntry()
    {
        int count = 0;
        // do
        // {
        //     filePath = Path.Combine(_folder, $"{fileName}{count}{extension}");
        //     count++;
        // }
        // while (File.Exists(fileName));
        // using (StreamWriter output = new StreamWriter(fileName))
        // {
        //     foreach (Entry entryElement in _entries)
        //     {
        //         output.WriteLine(entryElement._date);

        //         foreach (string element in entryElement._entryContents)
        //         {
        //             output.WriteLine(element);
        //         }
        //     }
        // }

        // Console.WriteLine($"Journal saved to: {fileName}");

        while (true)
        {
            if (Path.Exists($"{_folder}{_fileName}{count}{_extension}"))//currentEntry._filePath
            {
                count++;
            }
            else
            {
                //setting the path it will save as to the correct iteration of journal
                _currentEntry._filePath = $"{_folder}{_fileName}{count}{_extension}";
                //just printing what these things are
                Console.WriteLine($"Current _folder is: {_folder}");
                Console.WriteLine($"Current fileName is: {fileName}");
                Console.WriteLine($"Current file count is: {count}");
                Console.WriteLine($"So current filePath is: {_currentEntry._filePath}");

                break;
            }
        }
        Console.WriteLine($"this is supposed to be the filepath: {_currentEntry._filePath}");
        _currentEntry.SaveEntry();

        // using (StreamWriter output = new StreamWriter(filePath))
        // {  
        //     // foreach (Entry entryElement in _entries)
        //     // {
        //     output.WriteLine(entryElement._date);
        //     foreach (string element in entryElement._entryContents)
        //     {
        //         output.WriteLine(element);
        //     }
        //     // }
        // }
    }
}