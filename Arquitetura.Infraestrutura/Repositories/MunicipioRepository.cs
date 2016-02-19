using Arquitetura.Dominio.Aggregates.MunicipioAgg;
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
    public class MunicipioRepository : Repository<Municipio>, IMunicipioRepository
    {
        #region Construtor

        public MunicipioRepository(MainBCUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion
    }
}
