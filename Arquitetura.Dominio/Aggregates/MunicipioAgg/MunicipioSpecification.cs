using Arquitetura.Domino.Base.Specification;

namespace Arquitetura.Dominio.Aggregates.MunicipioAgg
{
    public static class MunicipioSpecifications
    {
        public static Specification<Municipio> ConsultaTexto(string texto)
        {
            Specification<Municipio> spec = new DirectSpecification<Municipio>(c => true);
            
            if (!string.IsNullOrWhiteSpace(texto))
            {
                spec &= new DirectSpecification<Municipio>(c => c.Descricao.ToUpper().Contains(texto.ToUpper()));
            }

            return spec;
        }
    }
}
