using DaneshkarShop.Domain.Entities.Role;
using DaneshkarShop.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace DaneshkarShop.Data.AppDbContext;

public class DaneshkarDbContext : DbContext
{
    #region Ctor

    public DaneshkarDbContext(DbContextOptions<DaneshkarDbContext> options) 
        : base(options)
    {

    }


    #endregion

    #region Db Sets
    public DbSet<User> Users { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<UserSelectedRole> UserSelectedRoles { get; set; }

    #endregion

    #region Model Creating

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var cascadeFKs = modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

        foreach (var fk in cascadeFKs)
            fk.DeleteBehavior = DeleteBehavior.Restrict;


        base.OnModelCreating(modelBuilder);
    }

    #endregion


}

