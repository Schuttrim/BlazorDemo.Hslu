using System.ServiceModel;
using System.Threading.Tasks;

namespace contract
{
    [ServiceContract]
    public interface ILeMemeService
    {
        Task<OneDoesNotSimplyData> OneDoesNotSimply();
    }
}