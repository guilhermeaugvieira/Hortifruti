using System.Threading.Tasks;

namespace HortifrutiBE.InfraStructure.Interfaces
{
    public interface IJwtService
    {
        Task<string> GerarJwt(string email);
    }
}
