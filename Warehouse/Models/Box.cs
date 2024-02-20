using WpfApp1.Warehouse.Data.Contracts;

namespace WpfApp1.Warehouse.Data.Models;

public class Box : ICodeModel
{
    public int PalletId { get; set; }
    public Pallet Pallet { get; set; }
}