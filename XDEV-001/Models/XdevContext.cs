using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace XDEV_001.Models;

public partial class XdevContext : DbContext
{
    public XdevContext()
    {
    }

    public XdevContext(DbContextOptions<XdevContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbProducto> TbProductos { get; set; }

    public virtual DbSet<TbUsuario> TbUsuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PC\\SQLEXPRESS;Database=XDEV;User Id=sa;Password=root;Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbProducto>(entity =>
        {
            entity.HasKey(e => e.CodProducto).HasName("PK__tb_produ__118203AD93E66316");

            entity.ToTable("tb_producto");

            entity.Property(e => e.CodProducto).HasColumnName("cod_producto");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.FecCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fec_creacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
            entity.Property(e => e.Stock).HasColumnName("stock");
        });

        modelBuilder.Entity<TbUsuario>(entity =>
        {
            entity.HasKey(e => e.CodUsuario).HasName("PK__tb_usuar__EA3C9B1AB83933AE");

            entity.ToTable("tb_usuario");

            entity.Property(e => e.CodUsuario).HasColumnName("cod_usuario");
            entity.Property(e => e.AccessToken).HasColumnName("access_token");
            entity.Property(e => e.Designation).HasColumnName("designation");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FecCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fec_creacion");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(100)
                .HasColumnName("nombre_completo");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.UserMessage).HasColumnName("user_message");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
