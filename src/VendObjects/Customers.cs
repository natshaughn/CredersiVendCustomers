namespace VendObjects;

using VendDatabase;

public class Customer
{
    private CustomerRecord record = new CustomerRecord {};

    public Customer(int id, string name)
    {
        this.record.Id = id;
        this.record.Name = name;
    }

    public string Address1 {get { return this.record.Address1; }}
    public string Address2 {get { return this.record.Address2; }}
    public string Address3 {get { return this.record.Address3; }}
    public string Contact {get { return this.record.Contact; }}
    public int Id {get { return this.record.Id; }}
    public int Machines {get { return this.record.Machines; }}
    public string Name {get { return this.record.Name; }}
    public string PostCode {get { return this.record.PostCode; }}

    public string Category {get {
        if (this.Machines < 1)
        {
            return "Lead";
        }
        else if (this.Machines > 200)
        {
            return "Platinum";
        }
        else if (this.Machines >= 20)
        {
            return "Gold";
        }
        else if (this.Machines >= 6)
        {
            return "Silver";
        }
        else if (this.Machines == 1)
        {
            return "Aluminum";
        }

        return "Bronze";
    }}

    public Customer SetAddress1(string address1)
    {
        this.record.Address1 = address1;
        return this;
    }

    public Customer SetAddress2(string address2)
    {
        this.record.Address2 = address2;
        return this;
    }

    public Customer SetAddress3(string address3)
    {
        this.record.Address3 = address3;
        return this;
    }

    public Customer SetContact(string contact)
    {
        this.record.Contact = contact;
        return this;
    }

    public Customer SetMachines(int machines)
    {
        this.record.Machines = machines;
        return this;
    }

    public Customer SetPostCode(string postCode)
    {
        this.record.PostCode = postCode;
        return this;
    }

    public override string ToString()
    {
        string ret = "";
        ret += "Customer    : "+this.Id+"\n";
        ret += " - Name     : "+this.Name+"\n";
        ret += " - Category : "+this.Category+"\n";
        ret += " - Contact  : "+this.Contact+"\n";
        ret += " - Machines : "+this.Machines+"\n";
        ret += " - Address  : "+this.Address1+"\n";
        if (this.Address2 != null && this.Address2.Length > 0)
        {
            ret += "              "+this.Address2+"\n";
        }

        if (this.Address3 != null && this.Address3.Length > 0)
        {
            ret += "              "+this.Address3+"\n";
        }

        ret += "              "+this.PostCode+"\n";
        return ret;
    }
}

public class Customers
{
    private CustomersDatabase db = new CustomersDatabase();

    private Func<CustomerRecord, Customer> AsCustomer = (record) =>
    {
        return new Customer(record.Id, record.Name)
            .SetAddress1(record.Address1)
            .SetAddress2(record.Address2)
            .SetAddress3(record.Address3)
            .SetContact(record.Contact)
            .SetMachines(record.Machines)
            .SetPostCode(record.PostCode);
    };
    
    private Func<Customer, CustomerRecord> AsRecord = (customer) =>
    {
        return new CustomerRecord
        {
            Address1 = customer.Address1,
            Address2 = customer.Address2,
            Address3 = customer.Address3,
            Contact = customer.Contact,
            Id = customer.Id,
            Machines = customer.Machines,
            Name = customer.Name,
            PostCode = customer.PostCode
        };
    };

    public void Add(Customer customer)
    {
        this.db.CreateRecord(AsRecord(customer));
    }

    public int Count()
    {
        return this.db.GetCount();
    }
    
    public Customer Create(int id, string name)
    {
        return new Customer(id, name);
    }

    public List<Customer> List()
    {
        List<Customer> customers = new List<Customer>();
        foreach (CustomerRecord record in this.db.ListAll())
        {
            customers.Add(AsCustomer(record));
        }

        return customers;
    }

    public int NextId()
    {
        return this.db.GetMaxId()+1;
    }

    public Customer Query(int id)
    {
        return AsCustomer(this.db.GetById(id));
    }

    public void RemoveAll()
    {
        this.db.RemoveAll();
    }
}
