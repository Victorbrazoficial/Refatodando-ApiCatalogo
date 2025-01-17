﻿using Newtonsoft.Json;

namespace Catalogo.Core.Entities
{
    public class DetalhesErro
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Trace { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
