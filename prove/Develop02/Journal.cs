using System.IO;

public class Journal
{
    //apparently better than just .\
    public static string _folder = AppContext.BaseDirectory;
    //AppDomain.CurrentDomain.BaseDirectory;
    public Entry currentEntry;
    public List<Entry> _entries = new List<Entry>();
    //prints all entries
    public Journal()
    {
        Directory.CreateDirectory(_folder);
    }
    public void DisplayJournal()
    {
        foreach(Entry entryElement in _entries)
        {
            Console.WriteLine(entryElement._date);
            Console.WriteLine(entryElement._date);
            foreach(string element in entryElement._entryContents)
            {
                Console.WriteLine(element);
            }
        }
    }
    public void AddEntry()
    {
        currentEntry = new Entry();
        _entries.Add(currentEntry);
    }
    public void SaveJournal()
    {
        string fileName = "journal_entry_";
        string extension = ".txt";
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
            if (Path.Exists($"{_folder}{fileName}{count}{extension}"))//currentEntry._filePath
            {
                count++;
            }
            else
            {
                currentEntry._filePath = $"{_folder}{fileName}{count}{extension}";
                Console.WriteLine($"Current _folder is: {_folder}");
                Console.WriteLine($"Current fileName is: {fileName}");
                Console.WriteLine($"Current file count is: {count}");
                Console.WriteLine($"So current filePath is: {currentEntry._filePath}");
                break;
            }
        }
        Console.WriteLine($"this is supposed to be the filepath: {currentEntry._filePath}");
        currentEntry.SaveEntry();

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