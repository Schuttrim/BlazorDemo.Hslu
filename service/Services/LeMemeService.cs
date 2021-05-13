using System.Threading.Tasks;
using contract;

namespace service.Services
{
    public class LeMemeService : ILeMemeService
    {
        public Task<OneDoesNotSimplyData> OneDoesNotSimply()
        {
            OneDoesNotSimplyData result = new () {Answer = "Touch my tralala"};
            return Task.FromResult(result); 
        }
    }
}