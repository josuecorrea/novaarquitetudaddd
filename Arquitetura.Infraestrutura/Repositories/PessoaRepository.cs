using Arquitetura.Dominio.Aggregates.PessoaAgg;
using Arquitetura.Infraestrutura.Base;
using Arquitetura.Dominio.Repositories.Interfaces;
using Arquitetura.Infraestrutura.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquitetura.Infraestrutura.Repositories
{
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        #region Construtor

        public PessoaRepository(MainBCUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion
    }
}
