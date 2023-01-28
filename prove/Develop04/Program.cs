class JournalEntry
{
    public string prompt;
    public string response;
    public string date;

    public JournalEntry(string prompt, string response, string date)
    {
        this.prompt = prompt;
        this.response = response;
        this.date = date;
    }
}

class Journal
{
    public List<JournalEntry> entries;

    public Journal()
    {
        entries = new List<JournalEntry>();
    }

    public void AddEntry(string prompt, string response, string date)
    {
        JournalEntry newEntry = new JournalEntry(prompt, response, date);
        entries.Add(newEntry);
    }

    public void DisplayEntries()
    {
        foreach (JournalEntry entry in entries)
        {
            Console.WriteLine("Prompt: " + entry.prompt);
            Console.WriteLine("Response: " + entry.response);
            Console.WriteLine("Date: " + entry.date);
            Console.WriteLine();
        }
    }
}

class JournalFile
{
    public void SaveJournal(Journal journal, string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (JournalEntry entry in journal.entries)
            {
                string line = entry.prompt + "|" + entry.response + "|" + entry.date;
                writer.WriteLine(line);
            }
        }
    }

    public Journal LoadJournal(string filename)
    {
        Journal journal = new Journal();

        using (StreamReader reader = new StreamReader(filename))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] parts = line.Split('|');
                string prompt = parts[0];
                string response = parts[1];
                string date = parts[2];

                JournalEntry entry = new JournalEntry(prompt, response, date);
                journal.entries.Add(entry);
            }
        }

        return journal;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        JournalFile journalFile = new JournalFile();

        while (true)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine("Enter a prompt:");
                string prompt = Console.ReadLine();
                Console.WriteLine("Enter a response:");
                string response = Console.ReadLine();
                Console.WriteLine("Enter a date:");
                string date = Console.ReadLine();

                journal.AddEntry(prompt, response, date);
            }
            else if (choice == 2)
            {
                journal.DisplayEntries();
            }
            else if (choice == 3)
            {
                Console.WriteLine("Enter a file name:");
                string filename = Console.ReadLine();
                journalFile.SaveJournal(journal, filename);
                Console.WriteLine("Journal saved to file successfully.");
            }
            else if (choice == 4)
            {
                Console.WriteLine("Enter a file name:");
                string filename = Console.ReadLine();
                journal = journalFile.LoadJournal(filename);
                Console.WriteLine("Journal loaded from file successfully.");
            }      
            else if (choice == 5)
            {
            break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
            }
        }
    }
}

// Add at least five different prompts to the list of prompts.
string[] prompts = { "Describe your day", "What did you learn today?", "What are you grateful for?", "What challenges did you face today?", "What are your plans for tomorrow?" };