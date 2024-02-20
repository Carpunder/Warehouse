namespace WpfApp1.Warehouse.Data.Models;

public class Box
{
    public int Id { get; set; }
    public string Code { get; set; }
    
    public Guid PalletId { get; set; }
    public Pallet Pallet { get; set; }
}