namespace VendDatabase;

using Microsoft.EntityFrameworkCore;

class CustomersContext : DbContext
{
    public DbSet<CustomerRecord> Customers { get; set; } = default!; // Initialized to avoid Non-nullable warning
    private string DatabasePath { get; }

    public CustomersContext()
    {
        string localAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        this.DatabasePath = System.IO.Path.Join(localAppDataPath, "VendCustomers.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DatabasePath}");
}

public class CustomerRecord
{
    public string Address1 { get; set; } = "";
    public string Address2 { get; set; } = "";
    public string Address3 { get; set; } = "";
    public string Contact { get; set; } = "";
    public int Id { get; set; } = 0;
    public int Machines { get; set; } = 0;
    public string Name { get; set; } = "";
    public string PostCode { get; set; } = "";
}

public class CustomersDatabase
{
    private CustomersContext context = new CustomersContext();

    public void CreateRecord(CustomerRecord record)
    {
        this.context.Add(record);
        this.context.SaveChanges();
    }

    public CustomerRecord GetById(int id)
    {
        return this.context.Customers.Where((c) => c.Id == id).First();
    }

    public int GetCount()
    {
        return this.context.Customers.Count();
    }

    public int GetMaxId()
    {
        int count = this.context.Customers.Count();
        return (count < 1) ? 0 : this.context.Customers.Max((c) => c.Id);
    }

    public List<CustomerRecord> ListAll()
    {
        return this.context.Customers.OrderBy((c) => c.Id).ToList<CustomerRecord>();
    }

    public void RemoveAll()
    {
        this.context.RemoveRange(this.context.Customers);
        this.context.SaveChanges();
    }
}
