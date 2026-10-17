using System;
using System.IO;

public class Journal
{
    //apparently better than just .\
    public static string _folder = AppContext.BaseDirectory;
    //AppDomain.CurrentDomain.BaseDirectory;
    public string _fileName = "journal_entry_";
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
        List<string> textFile;
        //Console.WriteLine("started 'while' in LoadEntries()");
        while (fileCounter < fileCount)
        {
            string filePath = $"{_folder}{_fileName}{fileCounter}{_extension}";
            Console.WriteLine($"Filepath: {filePath}");
            if (File.Exists(filePath))
            {
                textFile = File.ReadAllLines(filePath).ToList();
            }
            else
            {
                //Console.WriteLine("There are no entries to load. Choose a different action");
                return;
            }
            //setting _date as first line
            _entries.Add(new Entry());
            _entries[fileCounter]._date = textFile[0];
            //j testing, remove this when done
            Console.WriteLine(_entries[fileCounter]._date);
            //filling out _entryContent
            _entries[fileCounter]._entryContents.Add(textFile[1]);
            Console.WriteLine($"Lines in file{fileCounter}: {textFile.Count()}");
            for (int lineCounter = 2; lineCounter < textFile.Count(); lineCounter++)
            {
                //Console.WriteLine("Started loop");
                if (textFile[lineCounter][^1] == '&')
                {
                    _entries[fileCounter]._entryContents.Add(textFile[lineCounter]);
                    //Console.WriteLine($"Filecount: {fileCounter}, line count: {lineCounter}, yes &");
                    sectionCounter++;
                }
                else
                {
                    _entries[fileCounter]._entryContents[sectionCounter] += textFile[lineCounter];
                    //Console.WriteLine($"Filecount: {fileCounter}, line count: {lineCounter}, no &");
                }
                //Console.WriteLine("completed loop");
            }
            sectionCounter = 0;
        fileCounter++;
        }
    }
    //has test
    public void AddEntry()
    {
        Console.WriteLine("=> Start actual function");
        int newest = _entries.Count - 1;
        Console.WriteLine($"var newest is: {newest}");
        if (newest == -1)
        {
            _currentEntry = new Entry();
            _entries.Add(_currentEntry);
            newest++;
        }
        else
        {
            if (_entries[newest]._date == DateTime.Today.ToString("MM/dd/yyyy"))
            {
                Console.WriteLine($"There is already an entry for todays date: {_entries[newest]._date}, you may add more in this entry");
                _currentEntry = _entries[newest];
            }
            else
            {
                _currentEntry = new Entry();
                //Console.WriteLine($"count of entriesbefore: {_entries.Count()}");
                _entries.Add(_currentEntry);
                //Console.WriteLine($"count of entries after: {_entries.Count()}");
            }
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
            for (int i = 0; i < entryElement._entryContents.Count(); i++)
            {
                List<string> elementList = entryElement._entryContents;
                elementList[i] = entryElement._entryContents[i];
                if (elementList[i][^1] == '&')
                {
                    elementList[i] = elementList[i][..^1];
                    //element = element.Substring(0, element.length - 1);
                    
                }
                    //Console.WriteLine(elementList[i]);
            }
        }
    }
    //called in EditEntry()
    public void ChooseEntry1()
    {
        int fileCount = Directory.EnumerateFiles(_folder).Count();
        //debugging
        if (fileCount != _entries.Count)
        {
            Console.WriteLine($"fileCount is {fileCount} but _entries.Count is {_entries.Count}");
        }
        Console.Write($"there are {fileCount} entries in your journal.");
        
        int entryCount = 0;
        foreach (Entry entryElement in _entries)
        {
            Console.WriteLine($"Entry {entryCount}: {entryElement._date}");
            entryCount++;
        }
        ChooseEntry2(entryCount);
    }
    public void ChooseEntry2(int entryCount)
    {
        Console.WriteLine("Which entry do you want to edit? (choose a number from above)");
        string response = Console.ReadLine();
        if (int.Parse(response) >= 0 && int.Parse(response) <= entryCount)
        {
            _currentEntry = _entries[int.Parse(response)];
        }
        else
        {
            Console.WriteLine("Do you want to edit an existing entry? yes/no");
            response = Console.ReadLine();
            if (response == "yes")
            {
                ChooseEntry2(entryCount);
            }
            //else nothing
        }
    }
    //has test
    public void SaveCurrentEntry()
    {
        //int count = 0;
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

        int newest = _entries.Count - 1;
        Console.WriteLine($"var newest is: {newest}");
        if (_entries[newest]._date == DateTime.Today.ToString("MM/dd/yyyy"))
        {
                //if (Path.Exists($"{_folder}{_fileName}{count}{_extension}"))//currentEntry._filePath
            //setting the path it will save as to the correct iteration of journal
            _currentEntry._filePath = $"{_folder}{_fileName}{newest}{_extension}";
            //just printing what these things are
            Console.WriteLine($"Current _folder is: {_folder}");
            Console.WriteLine($"Current fileName is: {_fileName}");
            Console.WriteLine($"Current file count is: {newest + 1}");
            Console.WriteLine($"So current filePath is: {_currentEntry._filePath}");
        }
        else
        {
            _currentEntry._filePath = $"{_folder}{_fileName}{newest+1}{_extension}";
            //just printing what these things are
            Console.WriteLine($"Current _folder is: {_folder}");
            Console.WriteLine($"Current fileName is: {_fileName}");
            Console.WriteLine($"Current file count is: {newest + 2}");
            Console.WriteLine($"So current filePath is: {_currentEntry._filePath}");
        }
        Console.WriteLine($"this is supposed to be the filepath: {_currentEntry._filePath}");
        _currentEntry.SaveEntry();
        
        //int count = 0;
        // while (true)
        // {
        //     if (Path.Exists($"{_folder}{_fileName}{count}{_extension}"))//currentEntry._filePath
        //     {
        //         count++;
        //     }
        //     else
        //     {
        //         //setting the path it will save as to the correct iteration of journal
        //         _currentEntry._filePath = $"{_folder}{_fileName}{count}{_extension}";
        //         //just printing what these things are
        //         Console.WriteLine($"Current _folder is: {_folder}");
        //         Console.WriteLine($"Current fileName is: {_fileName}");
        //         Console.WriteLine($"Current file count is: {count}");
        //         Console.WriteLine($"So current filePath is: {_currentEntry._filePath}");

        //         break;
        //     }
        //
        // Console.WriteLine($"this is supposed to be the filepath: {_currentEntry._filePath}");
        // _currentEntry.SaveEntry();

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