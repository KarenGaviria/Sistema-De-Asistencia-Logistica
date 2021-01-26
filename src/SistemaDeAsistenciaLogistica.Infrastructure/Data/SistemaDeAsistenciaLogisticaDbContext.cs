using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SistemaDeAsistenciaLogistica.Core.Domain;

namespace SistemaDeAsistenciaLogistica.Infrastructure.Data
{
    public partial class SistemaDeAsistenciaLogisticaDbContext : DbContext
    {
        public SistemaDeAsistenciaLogisticaDbContext()
        {
        }

        public SistemaDeAsistenciaLogisticaDbContext(DbContextOptions<SistemaDeAsistenciaLogisticaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aspnetroleclaims> Aspnetroleclaims { get; set; }
        public virtual DbSet<Aspnetroles> Aspnetroles { get; set; }
        public virtual DbSet<Aspnetuserclaims> Aspnetuserclaims { get; set; }
        public virtual DbSet<Aspnetuserlogins> Aspnetuserlogins { get; set; }
        public virtual DbSet<Aspnetuserroles> Aspnetuserroles { get; set; }
        public virtual DbSet<Aspnetusers> Aspnetusers { get; set; }
        public virtual DbSet<Aspnetusertokens> Aspnetusertokens { get; set; }
        public virtual DbSet<Barrios> Barrios { get; set; }
        public virtual DbSet<Colores> Colores { get; set; }
        public virtual DbSet<Cotizacion> Cotizacion { get; set; }
        public virtual DbSet<Efmigrationshistory> Efmigrationshistory { get; set; }
        public virtual DbSet<EntregaPedido> EntregaPedido { get; set; }
        public virtual DbSet<EntregaPedidoRelacionTipoProducto> EntregaPedidoRelacionTipoProducto { get; set; }
        public virtual DbSet<EstadoProduccion> EstadoProduccion { get; set; }
        public virtual DbSet<Insumos> Insumos { get; set; }
        public virtual DbSet<Inventario> Inventario { get; set; }
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<PedidoRelacionProduccion> PedidoRelacionProduccion { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<Produccion> Produccion { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<ReciboPago> ReciboPago { get; set; }
        public virtual DbSet<TipoProducto> TipoProducto { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("database=sistem;server=localhost;port=3306;user id=root", x => x.ServerVersion("10.4.14-mariadb"));
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aspnetroleclaims>(entity =>
            {
                entity.ToTable("aspnetroleclaims");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ClaimType)
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ClaimValue)
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasColumnType("varchar(127)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Aspnetroleclaims)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetRoleClaims_AspNetRoles_RoleId");
            });

            modelBuilder.Entity<Aspnetroles>(entity =>
            {
                entity.ToTable("aspnetroles");

                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("varchar(127)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ConcurrencyStamp)
                    .HasColumnType("varchar(256)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(256)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.NormalizedName)
                    .HasColumnType("varchar(256)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Aspnetuserclaims>(entity =>
            {
                entity.ToTable("aspnetuserclaims");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserClaims_UserId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ClaimType)
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ClaimValue)
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnType("varchar(767)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserclaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserClaims_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetuserlogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("aspnetuserlogins");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider)
                    .HasColumnType("varchar(127)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ProviderKey)
                    .HasColumnType("varchar(127)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ProviderDisplayName)
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnType("varchar(767)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserlogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserLogins_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetuserroles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("aspnetuserroles");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_AspNetUserRoles_RoleId");

                entity.Property(e => e.UserId)
                    .HasColumnType("varchar(127)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.RoleId)
                    .HasColumnType("varchar(127)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Aspnetuserroles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserroles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetusers>(entity =>
            {
                entity.ToTable("aspnetusers");

                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("varchar(767)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.AccessFailedCount).HasColumnType("int(11)");

                entity.Property(e => e.ConcurrencyStamp)
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(256)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.LockoutEnd).HasColumnType("timestamp");

                entity.Property(e => e.NormalizedEmail)
                    .HasColumnType("varchar(256)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.NormalizedUserName)
                    .HasColumnType("varchar(256)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.PasswordHash)
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.SecurityStamp)
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.UserName)
                    .HasColumnType("varchar(256)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Aspnetusertokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("aspnetusertokens");

                entity.Property(e => e.UserId)
                    .HasColumnType("varchar(127)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.LoginProvider)
                    .HasColumnType("varchar(127)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(127)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Value)
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetusertokens)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserTokens_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Barrios>(entity =>
            {
                entity.HasKey(e => e.IdBarrio)
                    .HasName("PRIMARY");

                entity.ToTable("barrios");

                entity.Property(e => e.IdBarrio)
                    .HasColumnName("Id_Barrio")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NombreBarrio)
                    .HasColumnName("Nombre_Barrio")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Colores>(entity =>
            {
                entity.HasKey(e => e.IdColor)
                    .HasName("PRIMARY");

                entity.ToTable("colores");

                entity.Property(e => e.IdColor)
                    .HasColumnName("Id_Color")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Color)
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Cotizacion>(entity =>
            {
                entity.HasKey(e => e.IdCotizacion)
                    .HasName("PRIMARY");

                entity.ToTable("cotizacion");

                entity.HasIndex(e => e.IdPerfil)
                    .HasName("Id_Usuarios");

                entity.HasIndex(e => e.IdProducto)
                    .HasName("Id_Producto");

                entity.Property(e => e.IdCotizacion)
                    .HasColumnName("Id_Cotizacion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cantidad).HasColumnType("int(11)");

                entity.Property(e => e.IdPerfil)
                    .HasColumnName("Id_Perfil")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdProducto)
                    .HasColumnName("Id_Producto")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ValorTotal)
                    .HasColumnName("Valor_Total")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.Cotizacion)
                    .HasForeignKey(d => d.IdPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cotizacion_ibfk_1");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Cotizacion)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cotizacion_ibfk_2");
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId)
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<EntregaPedido>(entity =>
            {
                entity.HasKey(e => e.IdEntregaPedido)
                    .HasName("PRIMARY");

                entity.ToTable("entrega_pedido");

                entity.HasIndex(e => e.IdPedido)
                    .HasName("Id_Pedido");

                entity.HasIndex(e => e.IdProduccion)
                    .HasName("Id_Produccion");

                entity.Property(e => e.IdEntregaPedido)
                    .HasColumnName("Id_Entrega_Pedido")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FechaEntrega)
                    .HasColumnName("Fecha_Entrega")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdPedido)
                    .HasColumnName("Id_Pedido")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdProduccion)
                    .HasColumnName("Id_Produccion")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.EntregaPedido)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("entrega_pedido_ibfk_2");

                entity.HasOne(d => d.IdProduccionNavigation)
                    .WithMany(p => p.EntregaPedido)
                    .HasForeignKey(d => d.IdProduccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("entrega_pedido_ibfk_1");
            });

            modelBuilder.Entity<EntregaPedidoRelacionTipoProducto>(entity =>
            {
                entity.HasKey(e => e.IdEntregaPedidoRelacionTipoProducto)
                    .HasName("PRIMARY");

                entity.ToTable("entrega_pedido_relacion_tipo_producto");

                entity.HasIndex(e => e.IdEntregaPedido)
                    .HasName("Id_Entrega_Pedido");

                entity.HasIndex(e => e.IdTipoProducto)
                    .HasName("Id_Tipo_Producto");

                entity.Property(e => e.IdEntregaPedidoRelacionTipoProducto)
                    .HasColumnName("Id_entrega_pedido_relacion_tipo_producto")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdEntregaPedido)
                    .HasColumnName("Id_Entrega_Pedido")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTipoProducto)
                    .HasColumnName("Id_Tipo_Producto")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdEntregaPedidoNavigation)
                    .WithMany(p => p.EntregaPedidoRelacionTipoProducto)
                    .HasForeignKey(d => d.IdEntregaPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("entrega_pedido_relacion_tipo_producto_ibfk_1");

                entity.HasOne(d => d.IdTipoProductoNavigation)
                    .WithMany(p => p.EntregaPedidoRelacionTipoProducto)
                    .HasForeignKey(d => d.IdTipoProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("entrega_pedido_relacion_tipo_producto_ibfk_2");
            });

            modelBuilder.Entity<EstadoProduccion>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PRIMARY");

                entity.ToTable("estado_produccion");

                entity.Property(e => e.IdEstado)
                    .HasColumnName("Id_Estado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EstadoProduccion1)
                    .HasColumnName("Estado_Produccion")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Insumos>(entity =>
            {
                entity.HasKey(e => e.IdInsumo)
                    .HasName("PRIMARY");

                entity.ToTable("insumos");

                entity.HasIndex(e => e.IdColor)
                    .HasName("Id_Color");

                entity.HasIndex(e => e.IdProveedor)
                    .HasName("Id_Proveedor");

                entity.Property(e => e.IdInsumo)
                    .HasColumnName("Id_Insumo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdColor)
                    .HasColumnName("Id_Color")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdProveedor)
                    .HasColumnName("Id_Proveedor")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NombreInsumo)
                    .HasColumnName("Nombre_Insumo")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.IdColorNavigation)
                    .WithMany(p => p.Insumos)
                    .HasForeignKey(d => d.IdColor)
                    .HasConstraintName("insumos_ibfk_3");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.Insumos)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("insumos_ibfk_2");
            });

            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.HasKey(e => e.IdInventario)
                    .HasName("PRIMARY");

                entity.ToTable("inventario");

                entity.HasIndex(e => e.IdInsumo)
                    .HasName("Id_Insumo");

                entity.HasIndex(e => e.IdPerfil)
                    .HasName("inventario_ibfk_2");

                entity.Property(e => e.IdInventario)
                    .HasColumnName("Id_Inventario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cantidad)
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnName("Fecha_Ingreso")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdInsumo)
                    .HasColumnName("Id_Insumo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdPerfil)
                    .HasColumnName("Id_Perfil")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ValorTotal)
                    .HasColumnName("Valor_Total")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ValorUnidadValorMetro)
                    .HasColumnName("Valor_Unidad/Valor_Metro")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdInsumoNavigation)
                    .WithMany(p => p.Inventario)
                    .HasForeignKey(d => d.IdInsumo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("inventario_ibfk_1");

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.Inventario)
                    .HasForeignKey(d => d.IdPerfil)
                    .HasConstraintName("inventario_ibfk_2");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.HasKey(e => e.IdMaterial)
                    .HasName("PRIMARY");

                entity.ToTable("material");

                entity.Property(e => e.IdMaterial)
                    .HasColumnName("Id_Material")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NombreMaterial)
                    .HasColumnName("Nombre_Material")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.IdPedido)
                    .HasName("PRIMARY");

                entity.ToTable("pedido");

                entity.HasIndex(e => e.IdBarrio)
                    .HasName("Id_Barrio");

                entity.HasIndex(e => e.IdCotizacion)
                    .HasName("Id_Cotizacion");

                entity.Property(e => e.IdPedido)
                    .HasColumnName("Id_Pedido")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FechaPedido)
                    .HasColumnName("Fecha_Pedido")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdBarrio)
                    .HasColumnName("Id_Barrio")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdCotizacion)
                    .HasColumnName("Id_Cotizacion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LugarEntrega)
                    .HasColumnName("Lugar_Entrega")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.IdBarrioNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.IdBarrio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pedido_ibfk_3");

                entity.HasOne(d => d.IdCotizacionNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.IdCotizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pedido_ibfk_2");
            });

            modelBuilder.Entity<PedidoRelacionProduccion>(entity =>
            {
                entity.HasKey(e => e.IdPedidoRelacionProduccion)
                    .HasName("PRIMARY");

                entity.ToTable("pedido_relacion_produccion");

                entity.HasIndex(e => e.IdPedido)
                    .HasName("Id_Pedido");

                entity.HasIndex(e => e.IdProduccion)
                    .HasName("Id_Produccion");

                entity.Property(e => e.IdPedidoRelacionProduccion)
                    .HasColumnName("Id_Pedido_Relacion_Produccion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdPedido)
                    .HasColumnName("Id_Pedido")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdProduccion)
                    .HasColumnName("Id_Produccion")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.PedidoRelacionProduccion)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pedido_relacion_produccion_ibfk_1");

                entity.HasOne(d => d.IdProduccionNavigation)
                    .WithMany(p => p.PedidoRelacionProduccion)
                    .HasForeignKey(d => d.IdProduccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pedido_relacion_produccion_ibfk_2");
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.HasKey(e => e.IdUsuarios)
                    .HasName("PRIMARY");

                entity.ToTable("perfil");

                entity.HasIndex(e => e.AspnetusersId)
                    .HasName("perfil_ibfk_1");

                entity.Property(e => e.IdUsuarios)
                    .HasColumnName("Id_Usuarios")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AspnetusersId)
                    .HasColumnName("aspnetusers_Id")
                    .HasColumnType("varchar(767)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Direccion)
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.PrimerApellido)
                    .IsRequired()
                    .HasColumnName("Primer_Apellido")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.PrimerNombre)
                    .IsRequired()
                    .HasColumnName("Primer_Nombre")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.Aspnetusers)
                    .WithMany(p => p.Perfil)
                    .HasForeignKey(d => d.AspnetusersId)
                    .HasConstraintName("perfil_ibfk_1");
            });

            modelBuilder.Entity<Produccion>(entity =>
            {
                entity.HasKey(e => e.IdProduccion)
                    .HasName("PRIMARY");

                entity.ToTable("produccion");

                entity.HasIndex(e => e.IdEstado)
                    .HasName("Id_Estado");

                entity.HasIndex(e => e.IdPerfil)
                    .HasName("produccion_ibfk_3");

                entity.HasIndex(e => e.IdProducto)
                    .HasName("Id_Producto");

                entity.Property(e => e.IdProduccion)
                    .HasColumnName("Id_Produccion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cantidad).HasColumnType("int(11)");

                entity.Property(e => e.DetalleProducto)
                    .HasColumnName("Detalle_Producto")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.FechaProduccion)
                    .HasColumnName("Fecha_Produccion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdEstado)
                    .HasColumnName("Id_Estado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdPerfil)
                    .HasColumnName("Id_Perfil")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdProducto)
                    .HasColumnName("Id_Producto")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Produccion)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("produccion_ibfk_2");

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.Produccion)
                    .HasForeignKey(d => d.IdPerfil)
                    .HasConstraintName("produccion_ibfk_3");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Produccion)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("produccion_ibfk_1");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PRIMARY");

                entity.ToTable("producto");

                entity.HasIndex(e => e.IdMaterial)
                    .HasName("Id_Material");

                entity.HasIndex(e => e.IdTipoProducto)
                    .HasName("Id_Tipo_Producto");

                entity.Property(e => e.IdProducto)
                    .HasColumnName("Id_Producto")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdMaterial)
                    .HasColumnName("Id_Material")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTipoProducto)
                    .HasColumnName("Id_Tipo_Producto")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.PrecioUnidad)
                    .HasColumnName("Precio_Unidad")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdMaterialNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.IdMaterial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("producto_ibfk_2");

                entity.HasOne(d => d.IdTipoProductoNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.IdTipoProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("producto_ibfk_1");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.IdProveedor)
                    .HasName("PRIMARY");

                entity.ToTable("proveedor");

                entity.Property(e => e.IdProveedor)
                    .HasColumnName("Id_Proveedor")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Direccion)
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Distribuidora)
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Telefono)
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<ReciboPago>(entity =>
            {
                entity.HasKey(e => e.IdReciboPago)
                    .HasName("PRIMARY");

                entity.ToTable("recibo_pago");

                entity.HasIndex(e => e.IdPedido)
                    .HasName("Id_Pedido");

                entity.Property(e => e.IdReciboPago)
                    .HasColumnName("Id_Recibo_Pago")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdPedido)
                    .HasColumnName("Id_Pedido")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.ReciboPago)
                    .HasForeignKey(d => d.IdPedido)
                    .HasConstraintName("recibo_pago_ibfk_1");
            });

            modelBuilder.Entity<TipoProducto>(entity =>
            {
                entity.HasKey(e => e.IdTipoProducto)
                    .HasName("PRIMARY");

                entity.ToTable("tipo_producto");

                entity.Property(e => e.IdTipoProducto)
                    .HasColumnName("Id_Tipo_Producto")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NombreProducto)
                    .HasColumnName("Nombre_producto")
                    .HasColumnType("varchar(12)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
