namespace Catalogo.Core.Service
{
    public interface IAuthService
    {
        string GenerateJwtToken(string elmail);
        string ComputeSha256Hash(string password);
    }
}
