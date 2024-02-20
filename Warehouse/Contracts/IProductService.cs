using WpfApp1.Warehouse.Data.Models;

namespace WpfApp1.Warehouse.Data.Contracts;

public interface IProductService : ICrudService<Product>
{
    IEnumerable<Product> GetAllByGtin(string gtin);
}