using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
[TestClass]
public class DefaultInterfaceTester
{
    [TestMethod]
    public void AddressInterfaceTest()
    {
        IAddress addr = new Location("123 Any St", "San Diego", "CA", "11111");
        Assert.AreEqual("123 Any St\r\n\r\nSan Diego, CA 11111", addr.Formatted());
    }
}

public class Location : IAddress
{
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }

    public Location(string addr1, string city, string state, string zip)
    {
        Address1 = addr1;
        City = city;
        State = state;
        Zip = zip;
    }
}

interface IAddress
{
    string Address1 { get; set; }
    string Address2 { get; set; }
    string City { get; set; }
    string State { get; set; }
    string Zip { get; set; }

    public string Formatted()
    {
        return $"{Address1}\r\n{Address2}\r\n{City}, {State} {Zip}";
    }
}