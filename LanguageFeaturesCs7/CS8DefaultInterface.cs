using System;
public class Program
{
    public static void Main()
    {
        IAddress addr = new C("123 Any St", "San Diego", "CA", "11111");
        Console.WriteLine(addr.Formatted());
    }
}

public class C : IAddress
{
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }

    public C(string addr1, string city, string state, string zip)
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