using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class Sof205FinalTestContext : DbContext
{
    public Sof205FinalTestContext()
    {
    }

    public Sof205FinalTestContext(DbContextOptions<Sof205FinalTestContext> options)
        : base(options)
    {
    }


    public virtual DbSet<Phuhuynh> Phuhuynhs { get; set; }


    public virtual DbSet<Sinhvien> Sinhviens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=MSI\\SQLEXPRESS;Initial Catalog=SOF205_FINAL_TEST;Integrated Security=True;User ID=NLHGiang;Password=giang123;Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Phuhuynh>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PHUHUYNH__3213E83FA19A3385");

            entity.ToTable("PHUHUYNH");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nghenghiep)
                .HasMaxLength(50)
                .HasColumnName("nghenghiep");
            entity.Property(e => e.Ten)
                .HasMaxLength(50)
                .HasColumnName("ten");
        });

        modelBuilder.Entity<Sinhvien>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SINHVIEN__3213E83F93A9421B");

            entity.ToTable("SINHVIEN");

            entity.HasIndex(e => e.Email, "UQ__SINHVIEN__AB6E6164CDDDC8A7").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Diachi)
                .HasMaxLength(100)
                .HasColumnName("diachi");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IdPh).HasColumnName("idPH");
            entity.Property(e => e.Sdt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("sdt");
            entity.Property(e => e.Ten)
                .HasMaxLength(50)
                .HasColumnName("ten");

            entity.HasOne(d => d.IdPhNavigation).WithMany(p => p.Sinhviens)
                .HasForeignKey(d => d.IdPh)
                .HasConstraintName("FK_SV_PH");
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
