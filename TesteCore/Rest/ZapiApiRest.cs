using Newtonsoft.Json;
using RestSharp;
using TesteCore.Dto;
using TesteCore.Models;
using TesteCore.Services;

namespace TesteCore.Rest
{
    public class ZapiApiRest : IZapiApi
    {
        public async Task<ResponseGenerico<SendTextModel>> EnviaMensagem(SendTextModel model)
        {
            var client = new RestClient($"https://api.z-api.io/instances/{new Dados().InstanceId}/token/{new Dados().Token}/send-text");
            var request = new RestRequest(Method.Post.ToString());
            request.AddHeader("content-type", "application/json");
            request.AddParameter("undefined", "{\"phone\": \"5511999998888\", \"message\": \"Welcome to *Z-API*\"}", ParameterType.RequestBody);

            var response = new ResponseGenerico<SendTextModel>();

            var responseZapiApi = await client.ExecuteAsync(request);

            if (responseZapiApi.IsSuccessful)
            {
                response.CodigoHttp = responseZapiApi.StatusCode;
                response.DadosRetorno = JsonConvert.DeserializeObject<SendTextModel>(responseZapiApi.Content);
            }
            else
            {
                response.CodigoHttp = responseZapiApi.StatusCode;
                response.ErroRetorno = JsonConvert.DeserializeObject(responseZapiApi.Content);
            }

            return response;
        }

        public Task<ResponseGenerico<SendLinkModel>> EnviaLink(string phone, string message, Uri image, Uri linkUrl, string title, string linkDescription)
        {
            throw new NotImplementedException();
        }
    }
}
