using Arquitetura.Domino.Base.Specification;

namespace Arquitetura.Dominio.Aggregates.UsuarioAgg
{
    public static class UsuarioSpecifications
    {
        public static Specification<Usuario> Consulta()
        {
            Specification<Usuario> spec = new DirectSpecification<Usuario>(c => true);
            
            return spec;
        }
    }
}
