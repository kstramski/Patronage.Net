﻿using System;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Patronage.Application.Exceptions
{
    public class HttpStatusCodeException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ContentType { get; set; } = @"text/plain";

        public HttpStatusCodeException(HttpStatusCode code)
        {
            StatusCode = code;
        }

        public HttpStatusCodeException(HttpStatusCode code, string message) : base(message)
        {
            StatusCode = code;
        }
    }
}
