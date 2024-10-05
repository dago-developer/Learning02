
public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    // Lista de prompts que se mostrará aleatoriamente
    private static readonly List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    // Definir Random una sola vez
    private static readonly Random _random = new Random();

    // Crear una nueva entrada
    public void AddEntry()
    {
        // Selecciona un prompt aleatorio de la lista
        string prompt = _prompts[_random.Next(_prompts.Count)];

        Console.WriteLine(prompt);
        string response = Console.ReadLine();
        string date = DateTime.Now.ToShortDateString();

        Console.Write("Where are you writing from?: ");
        string place = Console.ReadLine();

        _entries.Add(new Entry
        {
            Prompt = prompt,
            Response = response,
            Date = date,
            Place = place
        });
    }

    // Mostrar todas las entradas
    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
        }
        else
        {
            foreach (var entry in _entries)
            {
                entry.DisplayEntry();
            }
        }
    }

    // Guardar las entradas en un archivo
    public void SaveToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine($"{entry.Date}~|~{entry.Prompt}~|~{entry.Response}~|~{entry.Place}");
            }
        }

        Console.WriteLine("Journal saved.");
    }

    // Cargar las entradas desde un archivo
    public void LoadFromFile(string fileName)
    {
        if (File.Exists(fileName))
        {
            _entries.Clear();
            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                string[] parts = line.Split("~|~");
                _entries.Add(new Entry
                {
                    Date = parts[0],
                    Prompt = parts[1],
                    Response = parts[2],
                    Place = parts[3]
                });
            }

            Console.WriteLine("Journal loaded.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
