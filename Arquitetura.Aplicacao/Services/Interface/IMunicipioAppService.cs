using Arquitetura.Dominio.Aggregates.MunicipioAgg;
using Arquitetura.DTO;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Arquitetura.Aplicacao.Services.Interface
{
    public interface IMunicipioAppService : IDisposable
    {
        MunicipioDTO FindMunicipio(int municipioId);

        List<MunicipioDTO> FindMunicipios<KProperty>(string texto, Expression<Func<Municipio, KProperty>> orderByExpression, bool ascending = true);

        List<MunicipioDTO> FindMunicipios<KProperty>(string texto, Expression<Func<Municipio, KProperty>> orderByExpression, bool ascending, int pageIndex, int pageCount);

        long CountMunicipios(string texto);
    }
}
