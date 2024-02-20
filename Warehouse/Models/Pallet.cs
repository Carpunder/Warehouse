using WpfApp1.Warehouse.Data.Contracts;

namespace WpfApp1.Warehouse.Data.Models;

public class Pallet : ICodeModel
{
    public List<Box> Boxes { get; set; }
}