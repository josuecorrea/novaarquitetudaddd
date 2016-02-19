using System.ComponentModel;

namespace Arquitetura.Dominio.Aggregates.Enums
{
    public enum ePermissao
    {
        [Description("Administrador")]
        Administrador = 1,

        [Description("Concedente")]
        Concedente = 2,

        [Description("Convenente")]
        Convenente = 3,

        [Description("Gestor")]
        Gestor = 4,

        [Description("Interveniente")]
        Interveniente = 5,
    }
}
