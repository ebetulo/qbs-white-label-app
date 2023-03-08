﻿using Microsoft.Azure.Functions.Worker.Http;
using System.Net;
using System.Threading.Tasks;

namespace SigningService.API.Extensions
{
    public static class HttpRequestExtensions
    {
        public static async Task<HttpResponseData> BadRequestAsync(this HttpRequestData request, string error)
        {
            var response = request.CreateResponse(HttpStatusCode.BadRequest);
            await response.WriteAsJsonAsync(error, HttpStatusCode.BadRequest);
            return response;
        }

        public static async Task<HttpResponseData> Ok<TResult>(this HttpRequestData request, TResult result)
        {
            var response = request.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(result);
            return response;
        }

        public static HttpResponseData Ok(this HttpRequestData request)
        {
            var response = request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
    }
}
