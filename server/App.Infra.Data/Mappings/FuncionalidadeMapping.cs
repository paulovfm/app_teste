using App.Domain.Entities;
using App.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.Data.Mappings
{
    public class FuncionalidadeMapping : EntityTypeConfiguration<Funcionalidade>
    {
        public override void Map(EntityTypeBuilder<Funcionalidade> builder)
        {
            builder
                .Property(e => e.Nome);

            builder
                .Property(e => e.DataCadastro);

            builder
                .Property(e => e.DataAtualizacao);

            builder
                .Property(e => e.Excluido);
        }
    }
}