using AutoMapper;
using Newtonsoft.Json;
using WpfApp1.Dtoes;
using WpfApp1.Warehouse.Data.Contracts;

namespace WpfApp1.Warehouse.Data.Services;

public class ExportService(IProductService productService, IMapper mapper) 
    : IExportService
{
    public string GetMapByProductGtin(string gtin)
    {
        var products = productService.GetAllByGtin(gtin);
        return JsonConvert.SerializeObject(mapper.Map<IEnumerable<ProductDto>>(products));
    }
}