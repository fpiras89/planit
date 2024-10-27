using Microsoft.EntityFrameworkCore;
using Planit.Application.Interfaces;
using Planit.Domain.Entities;
using System.Linq.Expressions;

namespace Planit.Persistence;
public class ApplicationDbContext : DbContext, IDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Capacity> Capacities { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectAllocation> ProjectAllocations { get; set; }
    public DbSet<ProjectDemand> ProjectDemands { get; set; }
    public DbSet<Resource> Resources { get; set; }
    public DbSet<ResourceSkill> ResourceSkills { get; set; }
    public DbSet<Setting> Settings { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<SkillCategory> SkillCategories { get; set; }
    public DbSet<User> Users { get; set; }

    public T AddOne<T>(T entity) where T : class
    {
        var result = Set<T>().Add(entity);
        return result.Entity;
    }

    public void AddRange<T>(params T[] entities) where T : class
    {
        Set<T>().AddRangeAsync(entities);
    }

    public Task<List<T>> AllAsync<T>(Expression<Func<T, bool>>? predicate = null) where T : class
    {
        var query = Query<T>();
        if (predicate is not null)
        {
            query = query.Where(predicate);
        }
        return query.ToListAsync();
    }

    public T RemoveOne<T>(T entity) where T : class
    {
        var result = Set<T>().Remove(entity);
        return result.Entity;
    }

    public void RemoveRange<T>(params T[] entities) where T : class
    {
        Set<T>().RemoveRange(entities);
    }

    public Task<T?> FirstAsync<T>(Expression<Func<T, bool>>? predicate = null) where T : class
    {
        var query = Query<T>();
        if (predicate is not null)
        {
            query = query.Where(predicate);
        }
        return query.FirstOrDefaultAsync();
    }

    public IQueryable<T> Query<T>() where T : class
    {
        return Set<T>().AsQueryable();
    }

    public T UpdateOne<T>(T entity) where T : class
    {
        var result = Set<T>().Update(entity);
        return result.Entity;
    }

    public void UpdateRange<T>(params T[] entities) where T : class
    {
        Set<T>().UpdateRange(entities);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(PersistenceAssembly.Assembly);
    }
}
