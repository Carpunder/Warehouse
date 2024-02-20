using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using WpfApp1.Warehouse.Data.Contracts;
using WpfApp1.Warehouse.Data.Models;

namespace WpfApp1.Warehouse.Data.Services;

public abstract class BaseCrudService<T> : ICrudService<T>
where T: ICodeModel
{
    private readonly WarehouseDbContext _warehouseDbContext;
    protected readonly DbSet<T> DbSet;
    protected IQueryable<T> DbSetIncludeAll;

    protected BaseCrudService(WarehouseDbContext warehouseDbContext)
    {
        _warehouseDbContext = warehouseDbContext;
        DbSet = _warehouseDbContext.Set<T>();
    }

    public T? GetById(int id) 
        => DbSet.FirstOrDefault(x => x.Id == id);
    
    public int GetLastId()
        => DbSet.Any()
            ? DbSet.Max(x => x.Id)
            : 0;

    public T Create(T model)
    {
        DbSet.Add(model);
        _warehouseDbContext.SaveChanges();
        return model;
    }
}