using App.Domain.Entities;
using App.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.Data.Mappings
{
    public class PerfilFuncionalidadeMapping : EntityTypeConfiguration<PerfilFuncionalidade>
    {
        public override void Map(EntityTypeBuilder<PerfilFuncionalidade> builder)
        {
            builder
                .Property(e => e.Id);

            builder
                .Property(e => e.PerfilId);

            builder
                .Property(e => e.FuncionalidadeId);

            builder
                .Property(e => e.DataCadastro);

            builder
                .Property(e => e.DataAtualizacao);

            builder
                .Property(e => e.Excluido);

            builder
                .HasOne(e => e.Perfil)
                .WithMany(e => e.PerfilFuncionalidade)
                .HasForeignKey(e => e.PerfilId);

            builder
                .HasOne(e => e.Funcionalidade)
                .WithMany(e => e.PerfilFuncionalidade)
                .HasForeignKey(e => e.FuncionalidadeId);

        }
    }
}