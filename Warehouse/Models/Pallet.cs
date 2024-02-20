namespace WpfApp1.Warehouse.Data.Models;

public class Pallet
{
    public int Id { get; set; }
    public string Code { get; set; }
    
    public List<Box> Boxes { get; set; }
}