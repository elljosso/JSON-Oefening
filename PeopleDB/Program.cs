using PeopleDB;

/*
 * Opdracht: ga op zoek naar de comments die starten met TODO
 * en voeg daar de nodig code toe.
 * De opdrachten zitten in dit bestand, en in het bestand Group.cs
 */

Group group = new Group();
string filePath = "../../../database.json";

// try to load data
LoadFromDisk();

// Menu setup
Menu menu = new Menu();
menu.AddOption('1', "Set Group Name", SetGroupName);
menu.AddOption('2', "Add Person", AddPerson);
menu.AddOption('3', "Show Members", ShowMembers);

menu.Start();

// menu had ended. Save everything
SaveToDisk();


// Hier beginnen de opdrachten
void SetGroupName()
{
    Console.Write("Enter group name: ");
    string groepsnaam = Console.ReadLine();
    group.Name = groepsnaam;
}

void AddPerson()
{
    Person person = new Person();
    Console.WriteLine("Geef naam, leeftijd en de hobbies: ");

    person.Name = Console.ReadLine();

    person.Age = int.Parse(Console.ReadLine());

    string[] persoonhobbies = Console.ReadLine().Split(',');

    person.Hobbys.AddRange(persoonhobbies);


    group.People.Add(person);
}

void ShowMembers()
{
    Console.WriteLine($"Group Name: {group.Name}");

    foreach (var person in group.People)
    {
        Console.WriteLine($"Name: {person.Name}, Age: {person.Age}, Hobbies: {string.Join(", ", person.Hobbys)}");
    }
}

void SaveToDisk()
{
    // TODO: gebruik de variabele filePath (hierboven gedeclareerd) 
    // om een JSON versie van de groep op te slaan. Voeg foutafhandeling toe.
    try
    {
        string Json = group.Serialize();

        File.WriteAllText(filePath, Json);

        Console.WriteLine("Group data saved successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error while saving data: {ex.Message}");
    }
}

void LoadFromDisk()
{
    // TODO: gebruik de variabele filePath (hierboven gedeclareerd) 
    // om een JSON versie van de groep te laden. Voeg foutafhandeling toe.
    
    try
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            group = Group.Deserialize(json);
            Console.WriteLine("Date is geladen");
        }
    else
        {
            Console.WriteLine("Geen data gevonden. Start met lege groep");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error laden van de data van de disk: {ex.Message}");
    }
}


