using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using TaskManager.Domain.Contracts;
using TaskManager.Domain.Enitities;
using TaskManager.Domain.Exceptions;
using TaskManager.Shared.OptionsObject;

namespace TaskManager.Infrastructure.ExternalServices
{
    internal sealed class ExternalMockService : IExternalMockService
    {
        private readonly MockApiConfig _mockApiConfig;

        public ExternalMockService(IOptionsSnapshot<MockApiConfig> mockApiConfig)
        {
            _mockApiConfig = mockApiConfig.Value;
        }
        public async Task DeleteAsync(string url, CancellationToken cancellationToken)
        {
            var request = new RestRequest(url, Method.Delete);

            var response = await ExecuteRequestAsync(request, cancellationToken);

            if (!response.IsSuccessStatusCode)
                throw new OperationFailedException("Failed to delete todo");
        }

        public async Task<TResponseObj> GetAsync<TResponseObj>(string url, CancellationToken cancellationToken)
        {
            var request = new RestRequest(url, Method.Get);

            var response = await ExecuteRequestAsync(request, cancellationToken);

            if (!response.IsSuccessStatusCode)
                throw new OperationFailedException("Failed to get todo");

            return JsonConvert.DeserializeObject<TResponseObj>(response.Content);
        }

        public async Task<TRequestObj> PostAsync<TRequestObj>(TRequestObj body, string url, CancellationToken cancellationToken)
            where TRequestObj : class
        {
            var request = new RestRequest(url, Method.Post);

            request.AddJsonBody(JsonConvert.SerializeObject(body));
           
            var response = await ExecuteRequestAsync(request, cancellationToken);
            
            if(!response.IsSuccessStatusCode)
                throw new OperationFailedException("Failed to create todo");

            return JsonConvert.DeserializeObject<TRequestObj>(response.Content);
        }

        private async Task<RestResponse> ExecuteRequestAsync(RestRequest request, CancellationToken cancellationToken)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            using (var client = new RestClient(_mockApiConfig.BaseUrl))
            {
                return await client.ExecuteAsync(request, cancellationToken);
            }
        }
    }
}
