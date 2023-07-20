﻿using AutoMapper;
using TesteCore.Dto;
using TesteCore.Models;

namespace TesteCore.Services
{
    public class SendTextServices : ISendTextService
    {
        private readonly IMapper _mapper;
        private readonly IZapiApi _zapiApi;

        public SendTextServices(IMapper mapper, IZapiApi zapiApi)
        {
            _mapper = mapper;
            _zapiApi = zapiApi;
        }

        public async Task<ResponseGenerico<SendTextResponse>> EnviaMensagem(SendTextModel model)
        {
            var mensagem = await _zapiApi.EnviaMensagem(model);
            return _mapper.Map<ResponseGenerico<SendTextResponse>>(mensagem);
        }
    }
}
