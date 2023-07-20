﻿using System.Dynamic;
using System.Net;

namespace TesteCore.Dto
{
    public class ResponseGenerico<T> where T : class
    {
        public HttpStatusCode CodigoHttp { get; set; }
        public T? DadosRetorno { get; set; }
        public Object? ErroRetorno { get; set; }
    }
}
