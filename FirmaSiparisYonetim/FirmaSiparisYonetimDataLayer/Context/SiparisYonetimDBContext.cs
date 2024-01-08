using FirmaSiparisYonetimDataLayer.Tables;
using Microsoft.EntityFrameworkCore;

namespace FirmaSiparisYonetimDataLayer.Context
{
    public class SiparisYonetimDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("User ID=DESKTOP-TVKKTR0\\mypc;Server=(localdb)\\MSSQLLocalDB;Database=FirmaSiparisYonetimAPI;Integrated Security=true;");
        }

        public virtual DbSet<Firma> Firma { get; set; }
        public virtual DbSet<Urun> Urun { get; set; }
        public virtual DbSet<Siparis> Siparis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Urun>()
                .HasOne<Firma>(u => u.Firma)
                .WithMany(f => f.Urunler)
                .HasForeignKey(u => u.FirmaId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Siparis>()
                .HasOne<Firma>(f => f.Firma)
                .WithMany(f => f.Siparisler)
                .HasForeignKey(s => s.FirmaId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Siparis>()
                .HasOne<Urun>(u => u.Urun)
                .WithMany(u => u.Siparisler)
                .HasForeignKey(s => s.UrunId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
