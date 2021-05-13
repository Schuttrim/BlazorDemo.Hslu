using System.Threading.Tasks;
using contract;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Components;
using ProtoBuf.Grpc.Client;

namespace client.Pages
{
    public partial class MemePage
    {
        // [Inject]
        // public ILeMemeService Service { get; set; }
        
        [Inject]
        public GrpcChannel Channel { get; set; }
        
        private string Answer { get; set; }
        
        private async Task FetchMeme()
        {
            // var result = await this.Service.OneDoesNotSimply();
            var service = this.Channel.CreateGrpcService<ILeMemeService>();
            var result = await service.OneDoesNotSimply();
            this.Answer = result.Answer;
            
            // this.StateHasChanged();
        }

        private void Reset()
        {
            this.Answer = string.Empty;
        }
    }
}