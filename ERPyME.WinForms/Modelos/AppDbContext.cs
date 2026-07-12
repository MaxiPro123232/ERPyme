using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ERPyME.WinForms.Modelos;

/// <summary>
/// DbContext mapeado exactamente contra el esquema de "Base de datos.sql"
/// (base ERPyME en localhost\SQLEXPRESS). Si la base no existe, la crea con
/// el mismo esquema y la carga con la configuración inicial (usuarios, grupos, permisos y rubros).
/// </summary>
public class AppDbContext : DbContext
{
    private const string ConnectionString =
        @"Server=localhost\SQLEXPRESS;Database=ERPyME;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False";

    public DbSet<Grupo> Grupos => Set<Grupo>();
    public DbSet<Permiso> Permisos => Set<Permiso>();
    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Proveedor> Proveedores => Set<Proveedor>();
    public DbSet<Rubro> Rubros => Set<Rubro>();
    public DbSet<Producto> Productos => Set<Producto>();
    public DbSet<Compra> Compras => Set<Compra>();
    public DbSet<DetalleCompra> DetallesCompra => Set<DetalleCompra>();
    public DbSet<Venta> Ventas => Set<Venta>();
    public DbSet<DetalleVenta> DetallesVenta => Set<DetalleVenta>();
    public DbSet<CuentaCorriente> CuentasCorrientes => Set<CuentaCorriente>();
    public DbSet<Pago> Pagos => Set<Pago>();
    public DbSet<Auditoria> Auditorias => Set<Auditoria>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(ConnectionString, o => o.UseCompatibilityLevel(120));

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<Grupo>(e =>
        {
            e.ToTable("grupos");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).HasColumnName("id_grupo");
            e.Property(x => x.Codigo).HasColumnName("codigo").HasMaxLength(20);
            e.Property(x => x.Nombre).HasColumnName("nombre").HasMaxLength(100);
            e.Property(x => x.Descripcion).HasColumnName("descripcion").HasMaxLength(255);
            e.Property(x => x.Estado).HasColumnName("estado");
            e.HasIndex(x => x.Codigo).IsUnique();
        });

        mb.Entity<Permiso>(e =>
        {
            e.ToTable("permisos");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).HasColumnName("id_permiso");
            e.Property(x => x.Codigo).HasColumnName("codigo").HasMaxLength(50);
            e.Property(x => x.Descripcion).HasColumnName("descripcion").HasMaxLength(255);
            e.HasIndex(x => x.Codigo).IsUnique();
        });

        mb.Entity<Usuario>(e =>
        {
            e.ToTable("usuarios");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).HasColumnName("id_usuario");
            e.Property(x => x.NombreUsuario).HasColumnName("usuario").HasMaxLength(50);
            e.Property(x => x.Nombre).HasColumnName("nombre").HasMaxLength(100);
            e.Property(x => x.Apellido).HasColumnName("apellido").HasMaxLength(100);
            e.Property(x => x.Email).HasColumnName("email").HasMaxLength(150);
            e.Property(x => x.ClaveHash).HasColumnName("clave_hash").HasMaxLength(255);
            e.Property(x => x.Estado).HasColumnName("estado");
            e.HasIndex(x => x.NombreUsuario).IsUnique();
            e.HasIndex(x => x.Email).IsUnique();
        });

        // usuario_grupo
        mb.Entity<Usuario>()
          .HasMany(u => u.Grupos).WithMany(g => g.Usuarios)
          .UsingEntity<Dictionary<string, object>>("usuario_grupo",
              j => j.HasOne<Grupo>().WithMany().HasForeignKey("id_grupo"),
              j => j.HasOne<Usuario>().WithMany().HasForeignKey("id_usuario"),
              j => j.ToTable("usuario_grupo"));

        // grupo_permiso
        mb.Entity<Grupo>()
          .HasMany(g => g.Permisos).WithMany(p => p.Grupos)
          .UsingEntity<Dictionary<string, object>>("grupo_permiso",
              j => j.HasOne<Permiso>().WithMany().HasForeignKey("id_permiso"),
              j => j.HasOne<Grupo>().WithMany().HasForeignKey("id_grupo"),
              j => j.ToTable("grupo_permiso"));

        mb.Entity<Cliente>(e =>
        {
            e.ToTable("clientes");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).HasColumnName("id_cliente");
            e.Property(x => x.Codigo).HasColumnName("codigo").HasMaxLength(20);
            e.Property(x => x.Nombre).HasColumnName("nombre").HasMaxLength(150);
            e.Property(x => x.Cuit).HasColumnName("cuit").HasMaxLength(20);
            e.Property(x => x.Telefono).HasColumnName("telefono").HasMaxLength(30);
            e.Property(x => x.Email).HasColumnName("email").HasMaxLength(150);
            e.Property(x => x.Direccion).HasColumnName("direccion").HasMaxLength(200);
            e.Property(x => x.Estado).HasColumnName("estado");
            e.HasIndex(x => x.Codigo).IsUnique();
        });

        mb.Entity<Proveedor>(e =>
        {
            e.ToTable("proveedores");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).HasColumnName("id_proveedor");
            e.Property(x => x.Codigo).HasColumnName("codigo").HasMaxLength(20);
            e.Property(x => x.Nombre).HasColumnName("nombre").HasMaxLength(150);
            e.Property(x => x.Cuit).HasColumnName("cuit").HasMaxLength(20);
            e.Property(x => x.Telefono).HasColumnName("telefono").HasMaxLength(30);
            e.Property(x => x.Email).HasColumnName("email").HasMaxLength(150);
            e.Property(x => x.Direccion).HasColumnName("direccion").HasMaxLength(200);
            e.Property(x => x.Estado).HasColumnName("estado");
            e.HasIndex(x => x.Codigo).IsUnique();
        });

        mb.Entity<Rubro>(e =>
        {
            e.ToTable("rubros");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).HasColumnName("id_rubro");
            e.Property(x => x.Codigo).HasColumnName("codigo").HasMaxLength(20);
            e.Property(x => x.Nombre).HasColumnName("nombre").HasMaxLength(100);
            e.Property(x => x.Descripcion).HasColumnName("descripcion").HasMaxLength(255);
            e.Property(x => x.Estado).HasColumnName("estado");
            e.HasIndex(x => x.Codigo).IsUnique();
        });

        mb.Entity<Producto>(e =>
        {
            e.ToTable("productos");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).HasColumnName("id_producto");
            e.Property(x => x.Codigo).HasColumnName("codigo").HasMaxLength(20);
            e.Property(x => x.Nombre).HasColumnName("nombre").HasMaxLength(150);
            e.Property(x => x.Descripcion).HasColumnName("descripcion").HasMaxLength(255);
            e.Property(x => x.Precio).HasColumnName("precio").HasColumnType("decimal(12,2)");
            e.Property(x => x.StockActual).HasColumnName("stock_actual");
            e.Property(x => x.StockMinimo).HasColumnName("stock_minimo");
            e.Property(x => x.Estado).HasColumnName("estado");
            e.Property(x => x.RubroId).HasColumnName("id_rubro");
            e.HasOne(x => x.Rubro).WithMany(r => r.Productos).HasForeignKey(x => x.RubroId);
            e.HasIndex(x => x.Codigo).IsUnique();
        });

        mb.Entity<Compra>(e =>
        {
            e.ToTable("compras");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).HasColumnName("id_compra");
            e.Property(x => x.Numero).HasColumnName("numero").HasMaxLength(30);
            e.Property(x => x.Fecha).HasColumnName("fecha").HasColumnType("date");
            e.Property(x => x.Total).HasColumnName("total").HasColumnType("decimal(12,2)");
            e.Property(x => x.ProveedorId).HasColumnName("id_proveedor");
            e.Property(x => x.UsuarioId).HasColumnName("id_usuario");
            e.HasOne(x => x.Proveedor).WithMany().HasForeignKey(x => x.ProveedorId);
            e.HasOne(x => x.Usuario).WithMany().HasForeignKey(x => x.UsuarioId).OnDelete(DeleteBehavior.Restrict);
            e.HasIndex(x => x.Numero).IsUnique();
        });

        mb.Entity<DetalleCompra>(e =>
        {
            e.ToTable("detalle_compra");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).HasColumnName("id_detalle_compra");
            e.Property(x => x.Cantidad).HasColumnName("cantidad");
            e.Property(x => x.PrecioUnitario).HasColumnName("precio_unitario").HasColumnType("decimal(12,2)");
            e.Property(x => x.Subtotal).HasColumnName("subtotal").HasColumnType("decimal(12,2)");
            e.Property(x => x.CompraId).HasColumnName("id_compra");
            e.Property(x => x.ProductoId).HasColumnName("id_producto");
            e.HasOne(x => x.Compra).WithMany(c => c.Detalles).HasForeignKey(x => x.CompraId);
            e.HasOne(x => x.Producto).WithMany().HasForeignKey(x => x.ProductoId).OnDelete(DeleteBehavior.Restrict);
        });

        mb.Entity<Venta>(e =>
        {
            e.ToTable("ventas");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).HasColumnName("id_venta");
            e.Property(x => x.Numero).HasColumnName("numero").HasMaxLength(30);
            e.Property(x => x.Fecha).HasColumnName("fecha").HasColumnType("date");
            e.Property(x => x.Total).HasColumnName("total").HasColumnType("decimal(12,2)");
            e.Property(x => x.Estado).HasColumnName("estado").HasMaxLength(30);
            e.Property(x => x.FormaPago).HasColumnName("forma_pago").HasMaxLength(50);
            e.Property(x => x.ImportePagado).HasColumnName("importe_pagado").HasColumnType("decimal(12,2)");
            e.Property(x => x.ClienteId).HasColumnName("id_cliente");
            e.Property(x => x.UsuarioId).HasColumnName("id_usuario");
            e.HasOne(x => x.Cliente).WithMany().HasForeignKey(x => x.ClienteId);
            e.HasOne(x => x.Usuario).WithMany().HasForeignKey(x => x.UsuarioId).OnDelete(DeleteBehavior.Restrict);
            e.HasIndex(x => x.Numero).IsUnique();
        });

        mb.Entity<DetalleVenta>(e =>
        {
            e.ToTable("detalle_venta");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).HasColumnName("id_detalle_venta");
            e.Property(x => x.Cantidad).HasColumnName("cantidad");
            e.Property(x => x.PrecioUnitario).HasColumnName("precio_unitario").HasColumnType("decimal(12,2)");
            e.Property(x => x.Subtotal).HasColumnName("subtotal").HasColumnType("decimal(12,2)");
            e.Property(x => x.VentaId).HasColumnName("id_venta");
            e.Property(x => x.ProductoId).HasColumnName("id_producto");
            e.HasOne(x => x.Venta).WithMany(v => v.Detalles).HasForeignKey(x => x.VentaId);
            e.HasOne(x => x.Producto).WithMany().HasForeignKey(x => x.ProductoId).OnDelete(DeleteBehavior.Restrict);
        });

        mb.Entity<CuentaCorriente>(e =>
        {
            e.ToTable("cuentas_corrientes");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).HasColumnName("id_cuenta_corriente");
            e.Property(x => x.SaldoAnterior).HasColumnName("saldo_anterior").HasColumnType("decimal(12,2)");
            e.Property(x => x.Debitos).HasColumnName("debitos").HasColumnType("decimal(12,2)");
            e.Property(x => x.Creditos).HasColumnName("creditos").HasColumnType("decimal(12,2)");
            e.Property(x => x.SaldoActual).HasColumnName("saldo_actual").HasColumnType("decimal(12,2)");
            e.Property(x => x.Estado).HasColumnName("estado").HasMaxLength(30);
            e.Property(x => x.ClienteId).HasColumnName("id_cliente");
            e.HasOne(x => x.Cliente).WithOne(c => c.CuentaCorriente).HasForeignKey<CuentaCorriente>(x => x.ClienteId);
            e.HasIndex(x => x.ClienteId).IsUnique();
        });

        mb.Entity<Pago>(e =>
        {
            e.ToTable("pagos");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).HasColumnName("id_pago");
            e.Property(x => x.Fecha).HasColumnName("fecha").HasColumnType("date");
            e.Property(x => x.Importe).HasColumnName("importe").HasColumnType("decimal(12,2)");
            e.Property(x => x.FormaPago).HasColumnName("forma_pago").HasMaxLength(50);
            e.Property(x => x.Observaciones).HasColumnName("observaciones").HasMaxLength(255);
            e.Property(x => x.CuentaCorrienteId).HasColumnName("id_cuenta_corriente");
            e.HasOne(x => x.CuentaCorriente).WithMany(cc => cc.Pagos).HasForeignKey(x => x.CuentaCorrienteId);
        });

        mb.Entity<Auditoria>(e =>
        {
            e.ToTable("auditorias");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).HasColumnName("id_auditoria");
            e.Property(x => x.FechaHora).HasColumnName("fecha_hora").HasColumnType("datetime2");
            e.Property(x => x.Accion).HasColumnName("accion").HasMaxLength(100);
            e.Property(x => x.Detalle).HasColumnName("detalle").HasMaxLength(255);
            e.Property(x => x.UsuarioId).HasColumnName("id_usuario");
            e.Property(x => x.VentaId).HasColumnName("id_venta");
            e.Property(x => x.CompraId).HasColumnName("id_compra");
            e.HasOne(x => x.Usuario).WithMany().HasForeignKey(x => x.UsuarioId).OnDelete(DeleteBehavior.Restrict);
        });
    }

    /// <summary>Crea la base (si no existe) y carga la configuración inicial si está vacía:
    /// usuarios con sus grupos y permisos (necesarios para iniciar sesión) y los rubros base.
    /// No se cargan datos de ejemplo (productos, clientes ni proveedores).</summary>
    public static void Inicializar()
    {
        using var db = new AppDbContext();
        db.Database.EnsureCreated();

        if (db.Usuarios.Any()) return;

        // Seguridad: grupos, permisos y usuarios (RF06-RF09)
        var permisos = new[]
        {
            new Permiso { Codigo = "USU_ABM",  Descripcion = "Gestionar usuarios y grupos" },
            new Permiso { Codigo = "PROD_ABM", Descripcion = "Gestionar productos y rubros" },
            new Permiso { Codigo = "CLI_ABM",  Descripcion = "Gestionar clientes" },
            new Permiso { Codigo = "PROV_ABM", Descripcion = "Gestionar proveedores" },
            new Permiso { Codigo = "VTA_REG",  Descripcion = "Registrar ventas" },
            new Permiso { Codigo = "CPR_REG",  Descripcion = "Registrar compras" },
            new Permiso { Codigo = "CTA_GES",  Descripcion = "Gestionar cuentas corrientes y pagos" },
            new Permiso { Codigo = "REP_VER",  Descripcion = "Ver reportes e indicadores" },
            new Permiso { Codigo = "AUD_VER",  Descripcion = "Consultar auditoría" }
        };

        var gAdmin = new Grupo { Codigo = "ADM", Nombre = "Administradores", Descripcion = "Acceso total al sistema" };
        gAdmin.Permisos.AddRange(permisos);
        var gVentas = new Grupo { Codigo = "VEN", Nombre = "Ventas", Descripcion = "Registro de ventas y gestión de clientes" };
        gVentas.Permisos.AddRange(permisos.Where(p => p.Codigo is "CLI_ABM" or "VTA_REG" or "REP_VER"));

        var admin = new Usuario
        {
            NombreUsuario = "admin", Nombre = "Administrador", Apellido = "General",
            Email = "admin@miempresa.com", ClaveHash = PasswordHasher.Hash("admin")
        };
        admin.Grupos.Add(gAdmin);
        var vendedor = new Usuario
        {
            NombreUsuario = "vendedor", Nombre = "Laura", Apellido = "Gómez",
            Email = "ventas@miempresa.com", ClaveHash = PasswordHasher.Hash("vendedor")
        };
        vendedor.Grupos.Add(gVentas);
        db.Usuarios.AddRange(admin, vendedor);

        // Rubros base: necesarios para poder dar de alta productos
        // (el alta de producto exige un rubro y aún no hay pantalla de rubros)
        db.Rubros.AddRange(
            new Rubro { Codigo = "RUB001", Nombre = "Informática" },
            new Rubro { Codigo = "RUB002", Nombre = "Audio" },
            new Rubro { Codigo = "RUB003", Nombre = "Oficina" },
            new Rubro { Codigo = "RUB004", Nombre = "Varios" });

        db.Auditorias.Add(new Auditoria
        {
            Usuario = admin, Accion = "Inicialización",
            Detalle = "Base de datos creada con la configuración inicial del sistema"
        });

        db.SaveChanges();
    }
}
