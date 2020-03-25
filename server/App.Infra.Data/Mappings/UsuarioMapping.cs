using App.Domain.Entities;
using App.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.Data.Mappings
{
    public class UsuarioMapping : EntityTypeConfiguration<Usuario>
    {
        public override void Map(EntityTypeBuilder<Usuario> builder)
        {
            builder
                .Property(e => e.Id);

            builder
                .Property(e => e.Nome);

            builder
                .Property(e => e.Email);

            builder
                .Property(e => e.Senha);

            builder
                .Property(e => e.PerfilId);

            builder
                .Property(e => e.DataCadastro);

            builder
                .Property(e => e.DataAtualizacao);

            builder
                .Property(e => e.Excluido);

            builder
                .HasOne(e => e.Perfil)
                .WithMany(e => e.Usuario)
                .HasForeignKey(e => e.PerfilId);
        }
    }
}