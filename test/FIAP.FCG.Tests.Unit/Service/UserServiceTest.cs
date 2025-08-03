using FIAP.FCG.Domain.Enums.User;
using FIAP.FCG.Service.Dto.Login;
using FIAP.FCG.Service.Dto.User;
using FIAP.FCG.Service.Exceptions;
using FIAP.FCG.Service.Interfaces;
using FIAP.FCG.Service.Util;
using Moq;
using System.Xml.Linq;

namespace FIAP.FCG.Tests.Unit.Service;

[TestFixture]
public class UserServiceTest
{
    private readonly Mock<IUserService> _userServiceMock = new Mock<IUserService>();

    [SetUp]
    public void SetUp()
    {

        var allUsers = new List<UserOutputDto> {
            new UserOutputDto
            {
                Id = 1,
                Name = "Admin",
                Email = "admin@fiap.com",
                AccessLevel = AccessLevelEnum.ADMIN
            },
            new UserOutputDto
            {
                Id = 2,
                Name = "felipetrosi",
                Email = "felipetrosi@fiap.com",
                AccessLevel = AccessLevelEnum.USER
            } };

        var errors = new Dictionary<string, string[]>();

        _userServiceMock.Setup(x => x.Create(It.IsAny<UserCreateDto>()))
           .Callback<UserCreateDto>(dto =>
           {
               if (!ValidatorService.IsValidEmail(dto.Email))
               {
                   errors["Email"] = ["Email inválido"];
               }

               if (!ValidatorService.IsValidPassword(dto.Password))
               {
                   errors["Senha"] = ["Senha deve conter letras, números e caracteres especiais, com pelo menos 8 caracteres."];
               }

               if (errors.Any())
                   throw new BadRequestException("Erro de validação", errors);
           });

        _userServiceMock.Setup(s => s.GetAll())
           .Returns(allUsers);

        _userServiceMock.Setup(s => s.GetById(It.IsAny<long>()))
            .Returns<long>(id =>
                allUsers.FirstOrDefault(u => u.Id == id)
            );

        _userServiceMock.Setup(s => s.Update(It.IsAny<UserUpdateDto>()))
            .Callback<UserUpdateDto>(dto =>
            {
                var user = allUsers.FirstOrDefault(u => u.Id == dto.Id);
                if (user is not null)
                {
                    user.Name = dto.Name;
                    user.Email = dto.Email;
                    user.AccessLevel = dto.AccessLevel;
                }
            });


        _userServiceMock.Setup(s => s.DeleteById(It.IsAny<long>()))
            .Verifiable();

    }

    [TestCase(TestName = "Cadastro de usuário com sucesso")]
    public void CreateUserSuccessful()
    {
        //Given
        bool result = false;
        var dto = new UserCreateDto
        {
            Name = "Felipe",
            Email = "felipe@fiap.com",
            Password = "@Felipe123",
            AccessLevel = AccessLevelEnum.USER
        };

        //When
        try
        {
            _userServiceMock.Object.Create(dto);
        }
        catch
        {
            result = true;
        }

        //Then
        Assert.IsFalse(result);
    }

    [TestCase(TestName = "Cadastro de usuário com falha no 'Email'")]
    public void CreateUserEmailFailed()
    {
        //Given
        bool result = false;
        var dto = new UserCreateDto
        {
            Name = "Felipe",
            Email = "felipe.email_invalido.com.br",
            Password = "F3lipe@2025",
            AccessLevel = AccessLevelEnum.USER
        };

        //When
        try
        {
            _userServiceMock.Object.Create(dto);
        }
        catch (BadRequestException e)
        {
            result = (e.Errors.Count() == 1 && e.Errors.First()!.Key == "Email");
        }

        //Then
        Assert.IsTrue(result);
    }

    [TestCase(TestName = "Cadastro de usuário com falha na 'Senha'")]
    public void CreateUserPasswordFailed()
    {
        //Given
        bool result = false;
        var dto = new UserCreateDto
        {
            Name = "Felipe",
            Email = "felipe@fiap.com",
            Password = "123456",
            AccessLevel = AccessLevelEnum.USER
        };

        //When
        try
        {
            _userServiceMock.Object.Create(dto);
        }
        catch (BadRequestException e)
        {
            result = (e.Errors.Count() == 1 && e.Errors.First()!.Key == "Senha");
        }

        //Then
        Assert.IsTrue(result);
    }

    [TestCase(TestName = "Obter todos usuários")]
    public void GetAllUsersSuccessful()
    {
        //Given
        ICollection<UserOutputDto> result;


        //When
        result = _userServiceMock.Object.GetAll();

        //Then
        Assert.IsNotEmpty(result);
    }

    [TestCase(TestName = "Obter usuário por Id")]
    public void GetUserByIdSuccessful()
    {
        //Given
        UserOutputDto result;

        //When
        result = _userServiceMock.Object.GetById(1)!;

        //Then
        Assert.IsNotNull(result);
        Assert.That(result.Id, Is.EqualTo(1));
    }

    [TestCase(TestName = "Atualizar usuário")]
    public void UpdateUserSuccessful()
    {
        //Given
        UserUpdateDto input = new UserUpdateDto
        {
            Id = 2,
            Name = "felipetrosi123",
            Email = "felipetrosi@fiap.com",
            AccessLevel = AccessLevelEnum.USER
        };

        //When
        _userServiceMock.Object.Update(input);
        var result = _userServiceMock.Object.GetById(2)!;

        //Then
        Assert.That(result.Name, Is.EqualTo("felipetrosi123"));
    }

    [TestCase(TestName = "Deletar usuário por Id")]
    public void DeleteUserSuccessful()
    {
        //Given
        var input = 1;
        var error = false;

        //When
        try
        {
            _userServiceMock.Object.DeleteById(input);
        }
        catch 
        {
            error = true;
        }

        //Then
        Assert.IsFalse(error);
    }

}
