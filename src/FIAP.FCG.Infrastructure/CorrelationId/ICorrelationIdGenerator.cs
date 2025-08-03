namespace FIAP.FCG.Infrastructure.CorrelationId;

public interface ICorrelationIdGenerator
{
    string Get();
    void Set(string correlationId);
}
