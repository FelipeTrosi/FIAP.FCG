using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace FIAP.FCG.Tests.BDD.StepDefinitions;

[Binding]
public class CadastroUsuarioSteps
{
    private string _nome = string.Empty;
    private string _email = string.Empty;
    private string _senha = string.Empty;
    private string _resultado = string.Empty;

    [Given(@"que informei o nome ""(.*)""")]
    public void GivenQueInformeiONome(string nome)
    {
        _nome = nome;
    }

    [Given(@"informei o email ""(.*)""")]
    public void GivenInformeiOEmail(string email)
    {
        _email = email;
    }

    [Given(@"informei a senha ""(.*)""")]
    public void GivenInformeiASenha(string senha)
    {
        _senha = senha;
    }

    [When(@"eu tento me cadastrar")]
    public void WhenEuTentoMeCadastrar()
    {
        var emailValido = new EmailAddressAttribute().IsValid(_email);

        if (!emailValido)
        {
            _resultado = "Email inválido";
            return;
        }

        var senhaValida = _senha.Length >= 8 &&
                          Regex.IsMatch(_senha, @"[A-Z]") &&
                          Regex.IsMatch(_senha, @"[a-z]") &&
                          Regex.IsMatch(_senha, @"[0-9]") &&
                          Regex.IsMatch(_senha, @"[\W_]");

        if (!senhaValida)
        {
            _resultado = "Senha inválida";
            return;
        }

        _resultado = "sucesso";
    }

    [Then(@"o sistema deve retornar sucesso")]
    public void ThenOUsuarioEhCadastrado()
    {
        Assert.That(_resultado, Is.EqualTo("sucesso"));
    }

    [Then(@"o sistema deve retornar erro ""(.*)""")]
    public void ThenOSistemaDeveRetornarErro(string erroEsperado)
    {
        Assert.That(_resultado, Is.EqualTo(erroEsperado));
    }
}
