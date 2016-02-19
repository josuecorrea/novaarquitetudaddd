using Arquitetura.Dominio.Base;
using System.Collections.Generic;

namespace Arquitetura.Dominio.Aggregates.PessoaAgg
{
    public class Pessoa : Entity, IValidator
    {
        #region Propriedades

        public string Nome { get; set; }

        #endregion

        #region Métodos públicos
        

        
        #endregion

        #region Métodos privados



        #endregion

        #region Validação

        public IEnumerable<string[]> Validate()
        {
            var validationResults = new List<string[]>();

            if (false)
            {
                validationResults.Add(new string[] { "Valor inválido." });
            }

            return validationResults;
        }

        #endregion
    }
}
