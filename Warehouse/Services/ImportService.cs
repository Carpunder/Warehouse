using WpfApp1.Integration.Contracts;
using WpfApp1.Warehouse.Data.Contracts;
using WpfApp1.Warehouse.Data.Models;

namespace WpfApp1.Warehouse.Data.Services;

public class ImportService(
    IMarkingService markingService,
    IPalletService palletService,
    IBoxService boxService,
    IProductService productService)
    : IImportService
{
    public void ImportProductFromFileByCode(IEnumerable<string> productCodes)
    {
        var marking = markingService.GetMission();
        var rawCodes = productCodes.Where(x => x.Contains(marking.Mission.Lot.Product.Gtin)).ToList();
        var codes = rawCodes.Select(x => x[..18]);
        var productCode = new ProductCode(codes.First(), codes.Count());
        var codesCount = productCode.Count;
        
        var boxesCount = Math.Ceiling(
            Math.Abs((double)productCode.Count / marking.Mission.Lot.Package.BoxFormat));
        var palletsCount = Math.Ceiling(
            Math.Abs(boxesCount / marking.Mission.Lot.Package.PalletFormat));

        while (palletsCount > 0)
        {
            var pallet = palletService.Create(new Pallet
            {
                Code = $"{productCode.Code.Insert(productCode.Code.Length-2, 
                    $"37{marking.Mission.Lot.Package.PalletFormat}")}{palletService.GetLastId()+1}"
            });

            if (boxesCount > 0)
            {
                for (var i = 0; i < marking.Mission.Lot.Package.PalletFormat; i++)
                {
                    var box = boxService.Create(new Box
                    {
                        Code = $"{productCode.Code.Insert(productCode.Code.Length-2, 
                            $"37{marking.Mission.Lot.Package.BoxFormat}")}{boxService.GetLastId()+1}",
                        PalletId = pallet.Id
                    });
                    
                    if (codesCount > 0)
                    {
                        for (var j = 0; j < marking.Mission.Lot.Package.BoxFormat; j++)
                        {
                            productService.Create(new Product
                            {
                                BoxId = box.Id,
                                Code = rawCodes[codesCount-1],
                                Gtin = marking.Mission.Lot.Product.Gtin,
                                Name = marking.Mission.Lot.Product.Name,
                                Volume = marking.Mission.Lot.Package.Volume
                            });
                            codesCount--;
                            
                            if(codesCount <= 0)
                                break;
                        }
                    }
                    
                    boxesCount--;
                    if(boxesCount <= 0)
                        break;
                }
            }
            
            palletsCount--;
        }
    }
    
    private record ProductCode(string Code, int Count);
}