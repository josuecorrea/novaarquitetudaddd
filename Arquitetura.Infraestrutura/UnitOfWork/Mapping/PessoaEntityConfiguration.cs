using System.Data.Entity.ModelConfiguration;
using Arquitetura.Dominio.Aggregates.PessoaAgg;

namespace Arquitetura.Infraestrutura.UnitOfWork.Mapping
{
    class PessoaEntityConfiguration : EntityTypeConfiguration<Pessoa>
    {
        public PessoaEntityConfiguration()
        {
            // Configurando propriedades e chaves
            this.HasKey(c => c.Id);

            this.Property(c => c.Id)
                .HasColumnName("pessoa_id")
                .IsRequired();

            //Configurando a Tabela
            this.ToTable("pessoa");
        }
    }
}
