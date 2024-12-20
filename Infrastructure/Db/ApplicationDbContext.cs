using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Db;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<AccountEntity> Accounts { get; set; }
    public DbSet<DeviceEntity> Devices { get; set; }
    public DbSet<InvitationEntity> Invitations { get; set; }
    public DbSet<MemberEntity> Members { get; set; }
    public DbSet<RevokedAccountEntity> RevokedAccounts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AccountEntity>(entity =>
        {
            entity.HasKey(a => a.AccountId);

            entity.Property(a => a.AccountId).IsRequired();
            entity.Property(a => a.MobileNumber).IsRequired();
            entity.Property(a => a.Name).HasMaxLength(100);
            entity.Property(a => a.ImageUrl).HasMaxLength(500);
            entity.Property(a => a.Blocked).IsRequired();
            entity.Property(a => a.JoinedDate).IsRequired();
            entity.Property(a => a.LastUpdated).IsRequired();

            entity.Property(a => a.Permissions)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());

            entity.HasMany<DeviceEntity>(a => a.Devices)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<DeviceEntity>(entity =>
        {
            entity.HasKey(d => d.DeviceId);

            entity.Property(d => d.DeviceId).IsRequired();
            entity.Property(d => d.DeviceType).IsRequired();
            entity.Property(d => d.RefreshToken).IsRequired();
            entity.Property(d => d.FcmToken).IsRequired();
            entity.Property(d => d.LastAccessTime).IsRequired();
        });

        modelBuilder.Entity<InvitationEntity>(entity =>
        {
            entity.HasKey(i => i.MobileNumber);

            entity.Property(i => i.MobileNumber).IsRequired();
            entity.Property(i => i.InviterId).IsRequired();
        });

        modelBuilder.Entity<MemberEntity>(entity =>
        {
            entity.HasKey(m => m.Id);

            entity.Property(m => m.Id).IsRequired();

            entity.Property(m => m.Ancestors)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());

            entity.Property(m => m.Parent).IsRequired();

            entity.Property(m => m.Children)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
        });

        modelBuilder.Entity<RevokedAccountEntity>(entity =>
        {
            entity.HasKey(r => r.Id);

            entity.Property(r => r.Id).IsRequired();
            entity.Property(r => r.RevokedTime).IsRequired();
        });
    }
}