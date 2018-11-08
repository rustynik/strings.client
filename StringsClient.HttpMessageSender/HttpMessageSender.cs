using Newtonsoft.Json;
using StringsClient.Contracts;
using StringsClient.Contracts.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace StringsClient.Message.Http
{
    public class HttpMessageSender<T> : IMessageQueue<T>
    {
        readonly string _requestUri;
        public HttpMessageSender(string requestUri)
        {
            _requestUri = requestUri ?? throw new ArgumentNullException(nameof(requestUri));
        }
        
        public async Task<IMessageAcknowledgement> Enqueue(T message)
        {
            using (var client = new HttpClient())
            {
                var content = new  StringContent(JsonConvert.SerializeObject(message), System.Text.Encoding.Default, "application/json");

                try
                {
                    var sendResult = await client.PostAsync(_requestUri, content);

                    return sendResult.IsSuccessStatusCode ? MessageAcknowledgement.Ok : MessageAcknowledgement.Error;
                } catch
                {
                    return MessageAcknowledgement.Error;
                }
            } 
        }
    }
}