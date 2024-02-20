using Microsoft.EntityFrameworkCore;
using WpfApp1.Warehouse.Data.Contracts;
using WpfApp1.Warehouse.Data.Models;

namespace WpfApp1.Warehouse.Data.Services;

public class BoxService : BaseCrudService<Box>, IBoxService
{
    public BoxService(WarehouseDbContext warehouseDbContext) : base(warehouseDbContext)
    {
        DbSetIncludeAll = DbSet.Include(x => x.Pallet).AsNoTracking();
    }
}