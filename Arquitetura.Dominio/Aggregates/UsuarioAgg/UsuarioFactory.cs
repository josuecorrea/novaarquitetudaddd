
using Arquitetura.Dominio.Aggregates.Enums;
namespace Arquitetura.Dominio.Aggregates.UsuarioAgg
{
    public static class PessoaFactory
    {
        public static Usuario CreateUsuario(
            eTipoProponente? tipoProponente,
            ePermissao? permissao,
            string nomeUsuario,
            string cpf,
            string senha,
            string cargo,
            bool ativo,
            string email,
            string telefone,
            string localDeTrabalho,
            int? municipioId,
            string cnpjProponente,
            string nomeProponente,
            string responsavelInstitucional,
            string cpfInstitucional,
            string cargoResponsavelInstitucional)
        {
            var usuario = new Usuario();

            usuario.TipoProponente = tipoProponente;
            usuario.Permissao = permissao;
            usuario.NomeUsuario = nomeUsuario;
            usuario.Cpf = cpf;
            usuario.Senha = senha;
            usuario.Cargo = cargo;
            usuario.Ativo = ativo;
            usuario.Email = email;
            usuario.Telefone = telefone;
            usuario.LocalDeTrabalho = localDeTrabalho;
            usuario.MunicipioId = municipioId;
            usuario.CnpjProponente = cnpjProponente;
            usuario.NomeProponente = nomeProponente;
            usuario.ResponsavelInstitucional = responsavelInstitucional;
            usuario.CpfInstitucional = cpfInstitucional;
            usuario.CargoResponsavelInstitucional = cargoResponsavelInstitucional;

            return usuario;
        }
    }
}
