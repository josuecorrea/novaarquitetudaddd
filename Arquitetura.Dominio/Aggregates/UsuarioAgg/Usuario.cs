using Arquitetura.Dominio.Aggregates.Enums;
using Arquitetura.Dominio.Aggregates.MunicipioAgg;
using Arquitetura.Dominio.Base;
using System.Collections.Generic;

namespace Arquitetura.Dominio.Aggregates.UsuarioAgg
{
    public class Usuario : Entity, IValidator
    {
        #region Propriedades

        public eTipoProponente? TipoProponente { get; set; }

        public ePermissao? Permissao { get; set; }

        public string NomeUsuario { get; set; }

        public string Cpf { get; set; }

        public string Senha { get; set; }

        public string Cargo { get; set; }

        public bool Ativo { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string LocalDeTrabalho { get; set; }

        public int? MunicipioId { get; set; }

        public virtual Municipio Municipio { get; set; }

        public string CnpjProponente { get; set; }

        public string NomeProponente { get; set; }

        public string ResponsavelInstitucional { get; set; }

        public string CpfInstitucional { get; set; }

        public string CargoResponsavelInstitucional { get; set; }

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
