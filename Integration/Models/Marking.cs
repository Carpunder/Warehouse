namespace WpfApp1.Integration.Models;

public class Marking
{
    public Mission Mission { get; set; }
}

public class Mission
{
    public Lot Lot { get; set; }
}

public class Lot
{
    public Package Package { get; set; }
    public Product Product { get; set; }
}

public class Package
{
    public string Volume { get; set; }
    public int BoxFormat { get; set; }
    public int PalletFormat { get; set; }
}

public class Product
{
    public string Name { get; set; }
    public string Gtin { get; set; }
}