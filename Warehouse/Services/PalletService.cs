using WpfApp1.Warehouse.Data.Contracts;
using WpfApp1.Warehouse.Data.Models;

namespace WpfApp1.Warehouse.Data.Services;

public class PalletService(WarehouseDbContext warehouseDbContext)
    : BaseCrudService<Pallet>(warehouseDbContext), IPalletService;