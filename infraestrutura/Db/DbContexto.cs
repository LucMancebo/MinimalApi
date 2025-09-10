namespace MinimalApi.infraestrutura.Db;

using MinimalApi.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

public class DbContexto : DbContext
{
    private readonly IConfiguration _configurationAppSettings;

    public DbContexto(DbContextOptions<DbContexto> options, IConfiguration configurationAppSettings)
        : base(options)
    {
        _configurationAppSettings = configurationAppSettings;
    }

    public DbSet<Administrador> Administradores { get; set; } = default!;
    public DbSet<Veiculo> Veiculos { get; set; } = default!;

       protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrador>().HasData(
            new Administrador
            {
                Email = "administrador@teste.com",
                Password = "123456",
                Perfil = "Adm",
                Id = 1
            }
        );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var stringDeConexao = _configurationAppSettings.GetConnectionString("mysql");

            if (!string.IsNullOrEmpty(stringDeConexao))
            {
                optionsBuilder.UseMySql(
                    stringDeConexao,
                    ServerVersion.AutoDetect(stringDeConexao));
            }
        }
    }
}