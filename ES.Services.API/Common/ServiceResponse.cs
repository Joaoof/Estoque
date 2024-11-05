﻿using NPOI.SS.Formula.Functions;

namespace ES.Services.API.Common
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public ServiceResponse()
        {
            Errors = new List<string>();
        }
    }
}
