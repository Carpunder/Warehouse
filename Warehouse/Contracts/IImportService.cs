namespace WpfApp1.Warehouse.Data.Contracts;

public interface IImportService
{
    void ImportProductFromFileByCode(IEnumerable<string> productCodes);
}