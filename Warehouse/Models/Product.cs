using WpfApp1.Warehouse.Data.Contracts;

namespace WpfApp1.Warehouse.Data.Models;

public class Product : ICodeModel
{
    public string Gtin { get; set; }
    public string Name { get; set; }
    public string Volume { get; set; }
    
    public int BoxId { get; set; }
    public Box Box { get; set; }
}