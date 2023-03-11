using VendObjects;

// ----------------------------------------------------------------------------
// Helpers
// ----------------------------------------------------------------------------

Func<string, string> Input = (prompt) =>
{
    Console.Write(prompt+" > ");
    string? line = Console.ReadLine();
    return (line == null) ? "" : line;
};

Func<string, string> InputLine = (prompt) =>
{
    Console.WriteLine(prompt+" : ");
    string? line = Console.ReadLine();
    Console.WriteLine("");
    return (line == null) ? "" : line;
};

Func<string, int> InputNumber = (prompt) =>
{
    string line = InputLine(prompt);
    if (line.Length < 1) {
        return 0;
    }

    return Int32.Parse(line);
};

Action<string> LogHead = (text) =>
{
    Console.WriteLine("");
    Console.WriteLine("------------------------------------------------------------");
    Console.WriteLine(text);
    Console.WriteLine("------------------------------------------------------------");
    Console.WriteLine("");
};

Action<string> LogLine = (text) =>
{
    Console.WriteLine(text);
};

Action<string> LogWork = (text) =>
{
    Console.WriteLine("");
    Console.WriteLine(text);
    Console.WriteLine("");
};

// ----------------------------------------------------------------------------
// Commands
// ----------------------------------------------------------------------------

Action AddCommand = () =>
{
    Customers db = new Customers();
    int id = db.NextId();

    LogWork("Enter customer details:");
    db.Add(db.Create(id, InputLine("Company name"))
        .SetAddress1(InputLine("Address line 1"))
        .SetAddress2(InputLine("Address line 2 (optional)"))
        .SetAddress3(InputLine("Address line 3 (optional)"))
        .SetPostCode(InputLine("Post Code"))
        .SetContact(InputLine("Contact name"))
        .SetMachines(InputNumber("Machine count [0]")));
    
    LogWork(String.Format("Customer with ID {0} created!", id));
};

Action ListCommand = () =>
{
    Customers db = new Customers();
    if (db.Count() < 1)
    {
        return;
    }

    LogLine("");
    foreach (Customer customer in db.List())
    {
        LogLine(customer.ToString());
    }
};

Action QueryCommand = () =>
{
    Customers db = new Customers();
    LogLine(db.Query(InputNumber("Company ID")).ToString());
};

Action QuitCommand = () =>
{
    LogWork("Goodbye!");
};

Action SmokeTestsCommand = () =>
{
    LogWork("This will empty the database after smoke testing!");
    string command = Input("Are you sure? (yes/[no])");
    if (!command.ToUpper().Equals("YES"))
    {
        LogLine("");
        return;
    }
    
    LogHead("Smoke Tests");
    LogLine("Connect to customers database...");
    Customers db = new Customers();

    LogLine("Create customer records...");
    db.Add(db.Create(7, "Galaxy Ltd")
        .SetContact("Douglas Adams")
        .SetMachines(4)
        .SetAddress1("42 Galaxy Street")
        .SetAddress2("Adamstown")
        .SetAddress3("Shropshire")
        .SetPostCode("GX22 42P"));

    db.Add(db.Create(8, "Alpha Ltd")
        .SetContact("Jane Smith")
        .SetMachines(40)
        .SetAddress1("2 Created Wibble")
        .SetAddress2("Hippo")
        .SetAddress3("Obvious")
        .SetPostCode("AL22 42P"));

    db.Add(db.Create(203, "Hello World Limited")
        .SetContact("Floz Martin")
        .SetAddress1("32 Hello World")
        .SetAddress3("Essex")
        .SetPostCode("HW20 22A"));

    db.Add(db.Create(222, "Big Company Ltd")
        .SetMachines(400)
        .SetAddress1("59 Yellow Road")
        .SetAddress3("Bridgnorth")
        .SetPostCode("BC10 19C"));

    db.Add(db.Create(2, "Jones Jumpers Ltd")
        .SetContact("John Jones")
        .SetMachines(4)
        .SetAddress1("99 Ninety Nine")
        .SetAddress2("Jonestown")
        .SetAddress3("Essex")
        .SetPostCode("JJ33 33J"));

    LogWork("List all customers:");
    foreach (Customer customer in db.List())
    {
        LogLine(customer.ToString());
    }

    LogWork("List customer by id:");
    LogLine(db.Query(203).ToString());

    LogWork("Finally, remove all records...");
    db.RemoveAll();
};

// ----------------------------------------------------------------------------
// Main
// ----------------------------------------------------------------------------

string command = "";
Dictionary<string, Action> commands = new Dictionary<string, Action>()
{
    {"ADD", AddCommand},
    {"EXIT", QuitCommand},
    {"LIST", ListCommand},
    {"QUERY", QueryCommand},
    {"QUIT", QuitCommand},
    {"SMOKE", SmokeTestsCommand}
};

LogHead("Credersi-vend Customers");
while (!(command.Equals("QUIT") || command.Equals("EXIT")))
{
    command = Input("Command").ToUpper();
    if (commands.ContainsKey(command))
    {
        commands[command]();
    }
    else if (command.Equals("HELP") || command.Equals("?"))
    {
        LogWork("Type quit to exit, or one of the following commands:");
        foreach (string key in commands.Keys)
        {
            LogLine(key.ToLower());
        }

        LogLine("");
    }
    else if (command.Length < 1) {
        // Do nothing!
    }
    else
    {
        LogWork(String.Format("Unrecognised command: {0}", command));
    }
}
