using Catalogo.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Infra.Contexts
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext() { }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<ProdutoItem> Produtos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder
            //    .UseSqlServer("Data source=.\\SQLEXPRESS;Initial Catalog=Catalogo;User Id=ivanteste;Password=10203040; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }

    }
}
