using System.ComponentModel;

namespace Arquitetura.Dominio.Aggregates.Enums
{
    public enum eStatusSolicitacao
    {
        [Description("Para Análise")]
        ParaAnalise = 0,
    
        [Description("Em Análise de Documentação")]
        EmAnaliseDeDocumentacao = 1,

        [Description("Em Diligência")]
        EmDiligencia = 2,

        [Description("Retorno de Diligência")]
        RetornoDeDiligencia = 3,

        [Description("Em Análise Técnica")]
        EmAnaliseTecnica = 4,

        [Description("Para Autorização Legislativa")]
        ParaAutorizacaoLegislativa = 5,

        [Description("Em Análise Jurídica")]
        EmAnaliseJuridica = 6,

        [Description("Convênio Celebrado")]
        ConvenioCelebrado = 7,

        [Description("Reprovada")]
        Reprovada = 8
    }
}
