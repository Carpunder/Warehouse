namespace WpfApp1.Warehouse.Data.Contracts;

public interface ICrudService<T> 
    where T: ICodeModel
{
    public T? GetById(int id);
    public int GetLastId();
    public T Create(T model);
}