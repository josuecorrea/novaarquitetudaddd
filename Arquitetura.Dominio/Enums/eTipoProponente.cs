using System.ComponentModel;

namespace Arquitetura.Dominio.Aggregates.Enums
{
    public enum eTipoProponente
    {
        [Description("Entidade")]
        Entidade = 1,

        [Description("Município")]
        Municipio = 2
    }
}
