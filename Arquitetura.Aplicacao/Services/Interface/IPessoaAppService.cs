using Arquitetura.Dominio.Aggregates.PessoaAgg;
using Arquitetura.DTO;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Arquitetura.Aplicacao.Services.Interface
{
    public interface IPessoaAppService : IDisposable
    {
        PessoaDTO AddPessoa(PessoaDTO pessoaDTO);

        void UpdatePessoa(PessoaDTO pessoaDTO);

        void RemovePessoa(int pessoaId);

        PessoaDTO FindPessoa(int pessoaId);

        List<PessoaDTO> FindPessoas<KProperty>(string texto, Expression<Func<Pessoa, KProperty>> orderByExpression, bool ascending, int pageIndex, int pageCount);

        List<PessoaDTO> FindPessoas<KProperty>(string texto, Expression<Func<Pessoa, KProperty>> orderByExpression, bool ascending = true);

        long CountPessoas(string texto);
    }
}
