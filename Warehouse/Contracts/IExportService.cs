namespace WpfApp1.Warehouse.Data.Contracts;

public interface IExportService
{
    string GetMapByProductGtin(string gtin);
}