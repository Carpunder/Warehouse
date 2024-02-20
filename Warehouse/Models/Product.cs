namespace WpfApp1.Warehouse.Data.Models;

public class Product
{
    public int Id { get; set; }
    public string Gtin { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public double Volume { get; set; }
    public int BoxFormat { get; set; }
    public int PalletFormat { get; set; }
    
    public Guid BoxId { get; set; }
    public Box Box { get; set; }
}