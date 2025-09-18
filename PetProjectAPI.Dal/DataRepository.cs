using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetProjectAPI.Dal;

public class DataEntity
{
    public DateTime Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Value { get; set; }
}

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<DataEntity> DataEntities => Set<DataEntity>();
}

public interface IDataRepository
{
    Task SaveAsync(DataEntity entity);
    Task<List<DataEntity>> GetAllAsync();
}

public class DataRepository : IDataRepository
{
    private readonly DataContext _context;
    public DataRepository(DataContext context)
    {
        _context = context;
    }

    public async Task SaveAsync(DataEntity entity)
    {
        _context.DataEntities.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<DataEntity>> GetAllAsync()
    {
        return await _context.DataEntities.ToListAsync();
    }
}
