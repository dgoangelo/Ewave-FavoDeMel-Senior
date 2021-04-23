using System;
using System.Threading;
using System.Threading.Tasks;
using FavoDeMel.Domain.Services;
using MassTransit;
using Newtonsoft.Json;

namespace FavoDeMel.Infra.Application.Services
{
    public class RabbiqMqService : IRabbiqMqService
    {
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public RabbiqMqService(ISendEndpointProvider sendEndpointProvider)
        {
            _sendEndpointProvider = sendEndpointProvider;
        }

        public async Task Send<T>(T obj, Uri queue, CancellationToken cancellationToken)
        {
            var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(queue);
            await sendEndpoint.Send(obj, cancellationToken);
        }
    }
}