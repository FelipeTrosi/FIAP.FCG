using FIAP.FCG.Service.Dto.Login;
using FIAP.FCG.Service.Exceptions;
using FIAP.FCG.Service.Interfaces;
using Moq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FIAP.FCG.Tests.Unit.Service;

[TestFixture]
public class AuthenticationServiceTest
{
    private readonly Mock<IAuthService> _authServiceMock = new Mock<IAuthService>();

    [SetUp]
    public void SetUp()
    {
        _authServiceMock
            .Setup(x => x.Login(It.IsAny<LoginDto>()))
            .Returns<LoginDto>(dto =>
            {
                if (dto.Username == "Admin" && dto.Password == "4Dm1n@Fiap")
                    return TokenMock.TokenAdmin;

                if (dto.Username == "felipetrosi" && dto.Password == "@Felipe123")
                    return TokenMock.TokenUser;

                throw new UnauthorizedException("Login inválido !");
            });

    }

    [TestCase(TestName = "Autenticação com sucesso")]
    public void TestLoginSuccessful()
    {
        //Given 
        var username = "Admin";
        var password = "4Dm1n@Fiap";

        //When
        var result = _authServiceMock.Object.Login(new() { Username = username, Password = password });

        //Then
        Assert.IsNotNull(result);
        Assert.IsNotEmpty(result);
        Assert.That(result, Does.Contain("."));
    }

    [TestCase(TestName = "Autenticação com falha de usuário")]
    public void TestLoginFailed()
    {
        //Given 
        var username = "Admin";
        var password = "qualquersenha";

        //When
        var result = Assert.Throws<UnauthorizedException>(() => _authServiceMock.Object.Login(new() { Username = username, Password = password }));

        //Then
        Assert.That(result.Message, Is.EqualTo("Login inválido !"));
    }


    [TestCase(TestName = "Validação usuário com role de 'Admin' com sucesso")]
    public void TestLoginRoleAdminSuccessful()
    {
        //Given 
        var username = "Admin";
        var password = "4Dm1n@Fiap";

        //When
        var result = _authServiceMock.Object.Login(new() { Username = username, Password = password });

        var roleClaim = new JwtSecurityTokenHandler()
            .ReadJwtToken(result)
            .Claims
            .FirstOrDefault(c => c.Type == ClaimTypes.Role);

        //Then
        Assert.IsNotNull(roleClaim, "Role claim não encontrada no token");
        Assert.That(roleClaim.Value, Is.EqualTo("Admin"));
    }

    [TestCase(TestName = "Validação usuário comum role de 'Admin' com falha")]
    public void TestLoginRoleAdminFailed()
    {
        //Given 
        var username = "felipetrosi";
        var password = "@Felipe123";

        //When
        var result = _authServiceMock.Object.Login(new() { Username = username, Password = password });

        var roleClaim = new JwtSecurityTokenHandler()
             .ReadJwtToken(result)
             .Claims
             .FirstOrDefault(c => c.Type == ClaimTypes.Role);

        //Then
        Assert.IsNotNull(roleClaim, "Role claim não encontrada no token");
        Assert.That(roleClaim.Value, Is.Not.EqualTo("Admin"));
    }


    [TestCase(TestName = "Validação usuáio comum role de 'User' com sucesso")]
    public void TestLoginRoleUserSuccessful()
    {
        //Given 
        var username = "felipetrosi";
        var password = "@Felipe123";

        //When
        var result = _authServiceMock.Object.Login(new() { Username = username, Password = password });

        var roleClaim = new JwtSecurityTokenHandler()
             .ReadJwtToken(result)
             .Claims
             .FirstOrDefault(c => c.Type == ClaimTypes.Role);

        //Then
        Assert.IsNotNull(roleClaim, "Role claim não encontrada no token");
        Assert.That(roleClaim.Value, Is.EqualTo("User"));
    }
}
