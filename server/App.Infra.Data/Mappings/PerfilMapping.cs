using App.Domain.Entities;
using App.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.Data.Mappings
{
    public class PerfilMapping : EntityTypeConfiguration<Perfil>
    {
        public override void Map(EntityTypeBuilder<Perfil> builder)
        {
            builder
                .Property(e => e.Nome);

            builder
                .Property(e => e.DataCadastro);

            builder
                .Property(e => e.DataAtualizacao);

            builder
                .Property(e => e.Excluido);

            builder
                .HasMany(e => e.Usuario)
                .WithOne(e => e.Perfil);
        }
    }
}