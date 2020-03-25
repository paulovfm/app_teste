

using App.Domain.Entities;
using App.Infra.Data.Extensions;
using App.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Context
{
    public class WebAppContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Perfil> Perfil { get; set; }

        public DbSet<Funcionalidade> Funcionalidade { get; set; }

        public DbSet<PerfilFuncionalidade> PerfilFuncionalidade { get; set; }

        public WebAppContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new UsuarioMapping());
            modelBuilder.AddConfiguration(new PerfilMapping());
            modelBuilder.AddConfiguration(new FuncionalidadeMapping());
            modelBuilder.AddConfiguration(new PerfilFuncionalidadeMapping());

            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.EnableSensitiveDataLogging();
        //    // ...
        //}
    }
}