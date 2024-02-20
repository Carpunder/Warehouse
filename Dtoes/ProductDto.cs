namespace WpfApp1.Dtoes;

public class ProductDto
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Gtin { get; set; }
    public string Name { get; set; }
    public string Volume { get; set; }
    public BoxDto Box { get; set; }
}