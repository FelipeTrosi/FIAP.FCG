namespace FIAP.FCG.Domain.Services.Interfaces
{
    public interface IAuthService
    {
        string GenerateJwtToken(string userId, string role);
    }
}
