using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoAulaEF_Identity.Models;

namespace ProjetoAulaEF_Identity.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            if (Database.IsSqlite())
            {
                // Ajusta o tamanho das colunas para o SQLite
                foreach (var entity in builder.Model.GetEntityTypes())
                {
                    foreach (var property in entity.GetProperties())
                    {
                        if (property.ClrType == typeof(string) && property.GetMaxLength() == null)
                        {
                            property.SetColumnType("TEXT");
                        }
                    }
                }
            }
        }
    }
}
