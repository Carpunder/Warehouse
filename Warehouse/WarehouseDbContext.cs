using System.Configuration;
using Microsoft.EntityFrameworkCore;
using WpfApp1.Warehouse.Data.Models;

namespace WpfApp1.Warehouse.Data;

public class WarehouseDbContext : DbContext
{
    private const string WarehouseDbConnStringKey = "WarehouseDb";
    
    public DbSet<Pallet> Pallets { get; set; }
    public DbSet<Box> Boxes { get; set; }
    public DbSet<Product> Products { get; set; }
    
    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(ConfigurationManager.AppSettings[WarehouseDbConnStringKey]);
    }
}