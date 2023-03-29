namespace VendObjects.Tests;

using VendObjects;
using VendDatabase;

public class CustomersTest

{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void leadTest()
    {
        Customer customer = new Customer(2, "Jack");
        customer.SetMachines(0);
        Assert.That(customer.Category, Is.EqualTo("Lead"));
    }

    [Test]
    public void aluminiumTest()
    {
        Customer customer = new Customer(3, "Jack");
        customer.SetMachines(1);
        Assert.That(customer.Category, Is.EqualTo("Aluminum"));
    }

    [Test]
    public void silverTest()
    {
        Customer customer = new Customer(4, "Jack");
        Customer customerTwo = new Customer(40, "Jill");
        customer.SetMachines(6);
        customerTwo.SetMachines(19);
        Assert.That(customer.Category, Is.EqualTo("Silver"));
        Assert.That(customerTwo.Category, Is.EqualTo("Silver"));
    }

    [Test]
    public void goldTest()
    {
        Customer customer = new Customer(5, "Jack");
        Customer customerTwo = new Customer(50, "Jill");
        customer.SetMachines(20);
        customerTwo.SetMachines(199);
        Assert.That(customer.Category, Is.EqualTo("Gold"));
        Assert.That(customerTwo.Category, Is.EqualTo("Gold"));
    }

    [Test]
    public void platinumTest()
    {
        Customer customer = new Customer(6, "Jack");
        Customer customerTwo = new Customer(60, "Jill");
        customer.SetMachines(200);
        customerTwo.SetMachines(201);
        Assert.That(customer.Category, Is.EqualTo("Platinum"));
        Assert.That(customerTwo.Category, Is.EqualTo("Platinum"));
    }

    [Test]
    public void bronzeTest()
    {
        Customer customer = new Customer(7, "Jack");
        Customer customerTwo = new Customer(70, "Jill");
        customer.SetMachines(2);
        customerTwo.SetMachines(5);
        Assert.That(customer.Category, Is.EqualTo("Bronze"));
        Assert.That(customerTwo.Category, Is.EqualTo("Bronze"));
    }

    [Test]
    public void negativeMachinesTest()
    {
        Customer customer = new Customer(1, "Jack");
        customer.SetMachines(-5);
        Assert.That(customer.Machines, Is.EqualTo(-5));
    }
    
    [Test]
    public void removeAllCustomersTest()
    {
        Customers db = new Customers();

        db.RemoveAll();
        db.Add(db.Create(71, "Nathan"));
        db.Add(db.Create(83, "Will"));
        db.Add(db.Create(92, "Tommy"));
        Assert.That(db.Count(), Is.EqualTo(3));

        db.RemoveAll();
        Assert.That(db.Count(), Is.EqualTo(0));
    }

    [Test]
    public void addCustomerFunctionTest() 
    {
        Customers db = new Customers();

        db.RemoveAll();
        db.Add(db.Create(523, "Jack"));
        db.Add(db.Create(642, "Jill"));
        db.Add(db.Create(764, "Jebediah"));
        
        // newCustomer.RemoveAll();

        Assert.That(db.Count(), Is.EqualTo(3));
    }

    [Test]
    public void nextIdTest()
    {
        Customers db = new Customers();

        db.RemoveAll();
        db.Add(db.Create(3, "Frank"));

        Assert.That(db.NextId(), Is.EqualTo(4));

    }

    [Test]
    public void removeAllCustomersTest()
    {
        Customers db = new Customers();
        db.RemoveAll();
        db.Add(db.Create(71, "Nathan"));
        db.Add(db.Create(83, "Will"));
        db.Add(db.Create(92, "Tommy"));
        Assert.That(db.Count(), Is.EqualTo(3));
        db.RemoveAll();
        Assert.That(db.Count(), Is.EqualTo(0));
    }

    [Test]
    public void addCustomerFunctionTest()
    {
        Customers db = new Customers();
        db.RemoveAll();
        db.Add(db.Create(523, "Jack"));
        db.Add(db.Create(642, "Jill"));
        db.Add(db.Create(764, "Jebediah"));
        Assert.That(db.Count(), Is.EqualTo(3));
    }

    [Test]
    public void nextIdTest()
    {
        Customers db = new Customers();
        db.RemoveAll();
        db.Add(db.Create(3, "Frank"));
        Assert.That(db.NextId(), Is.EqualTo(4));
    }
}


