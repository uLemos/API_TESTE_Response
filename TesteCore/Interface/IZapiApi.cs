using TesteCore.Dto;
using TesteCore.Models;

namespace TesteCore.Services
{
    public interface IZapiApi
    {
        Task<ResponseGenerico<SendTextModel>> EnviaMensagem(SendTextModel model);
        Task<ResponseGenerico<SendLinkModel>> EnviaLink(string phone, string message, Uri image, Uri linkUrl, string title, string linkDescription); 
    }
}
