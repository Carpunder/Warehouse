using Microsoft.EntityFrameworkCore;
using WpfApp1.Warehouse.Data.Contracts;
using WpfApp1.Warehouse.Data.Models;

namespace WpfApp1.Warehouse.Data.Services;

public class ProductService : BaseCrudService<Product>, IProductService
{
    public ProductService(WarehouseDbContext warehouseDbContext) : base(warehouseDbContext)
    {
        DbSetIncludeAll = DbSet.Include(x => x.Box).ThenInclude(x => x.Pallet)
            .AsNoTracking();
    }

    public IEnumerable<Product> GetAllByGtin(string gtin)
        => DbSetIncludeAll.Where(x => x.Gtin == gtin);
}