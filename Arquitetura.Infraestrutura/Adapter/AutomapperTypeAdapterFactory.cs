using AutoMapper;
using Arquitetura.Dominio.Aggregates.PessoaAgg;
using Arquitetura.DTO;
using Arquitetura.Dominio.Aggregates.MunicipioAgg;

namespace Arquitetura.Infraestrutura.Adapter
{
    public class AutomapperTypeAdapterFactory : ITypeAdapterFactory
    {
        #region Constructor

        /// <summary>
        /// Create a new Automapper type adapter factory
        /// </summary>
        public AutomapperTypeAdapterFactory()
        {
            // Mapeamentos
            Mapper.CreateMap<Pessoa, PessoaDTO>();
            Mapper.CreateMap<Municipio, MunicipioDTO>();
        }

        #endregion

        #region ITypeAdapterFactory Members

        public ITypeAdapter Create()
        {
            return new AutomapperTypeAdapter();
        }

        #endregion
    }
}
