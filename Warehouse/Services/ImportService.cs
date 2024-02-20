using WpfApp1.Integration.Contracts;
using WpfApp1.Warehouse.Data.Contracts;
using WpfApp1.Warehouse.Data.Models;

namespace WpfApp1.Warehouse.Data.Services;

public class ImportService : IImportService
{
    private readonly IMarkingService _markingService;
    private readonly WarehouseDbContext _warehouseDbContext;

    public ImportService(IMarkingService markingService,
        WarehouseDbContext warehouseDbContext)
    {
        _markingService = markingService;
        _warehouseDbContext = warehouseDbContext;
    }

    public void ImportProductFromFileByCode(IEnumerable<string> productCodes)
    {
        var marking = _markingService.GetMission();
        var codes = productCodes.Where(x => x.Contains(marking.Mission.Lot.Product.Gtin))
            .Select(x => x[..18]);
        var productCode = new ProductCode(codes.First(), codes.Count());
        var boxesCount = Math.Ceiling(
            Math.Abs((double)productCode.Count / marking.Mission.Lot.Package.BoxFormat));
        var palletsCount = Math.Ceiling(
            Math.Abs(boxesCount / marking.Mission.Lot.Package.PalletFormat));

        while (palletsCount > 0)
        {
            _warehouseDbContext.Pallets.Add(new Pallet
            {
                Code = $"{productCode.Code.Insert(productCode.Code.Length-2, 
                    $"37{marking.Mission.Lot.Package.PalletFormat}")}{GetLastPaletteId}"
            });
            _warehouseDbContext.SaveChanges();
            palletsCount--;
        }
        
        while (boxesCount > 0)
        {
            _warehouseDbContext.Boxes.Add(new Box()
            {
                Code = productCode.Code + GetLastPaletteId()
            });
            _warehouseDbContext.SaveChanges();
            boxesCount--;
        }
    }

    private int GetLastPaletteId() 
        => _warehouseDbContext.Pallets.Max(x => x.Id);
    
    private int GetLastBoxId() 
        => _warehouseDbContext.Boxes.Max(x => x.Id);
    
    private record ProductCode(string Code, int Count);
}