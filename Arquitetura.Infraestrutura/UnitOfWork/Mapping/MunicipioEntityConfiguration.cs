using System.Data.Entity.ModelConfiguration;
using Arquitetura.Dominio.Aggregates.MunicipioAgg;

namespace Arquitetura.Infraestrutura.UnitOfWork.Mapping
{
    class MunicipioEntityConfiguration : EntityTypeConfiguration<Municipio>
    {
        public MunicipioEntityConfiguration()
        {
            // Configurando propriedades e chaves
            this.HasKey(c => c.Id);

            this.Property(c => c.Id)
                .HasColumnName("municipio_id")
                .IsRequired();

            this.Property(c => c.Descricao)
                .HasColumnName("descricao")
                .IsRequired();

            //Configurando a Tabela
            this.ToTable("municipio");
        }
    }
}
