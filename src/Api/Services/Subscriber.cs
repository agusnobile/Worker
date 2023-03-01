using Andreani.ARQ.AMQStreams.Interface;
using System.Threading.Tasks;
using System;
using Andreani.Scheme.Onboarding;
using DnsClient.Internal;
using Microsoft.Extensions.Logging;
using MediatR;
using OnboardingServicioNotificaciones.Application.UseCase.V1.PedidoOperation.Commands;
using static Slapper.AutoMapper;
using System.Security.Policy;

namespace OnboardingServicioNotificaciones.Services
{
    public class Subscriber : ISubscriber
    {
        private ILogger<Subscriber> _logger;
        private readonly ISender _mediator;
        private readonly Andreani.ARQ.AMQStreams.Interface.IPublisher _publisher;

        public Subscriber(ILogger<Subscriber> logger, ISender mediator, Andreani.ARQ.AMQStreams.Interface.IPublisher publisher)
        {
            _logger = logger;
            _mediator = mediator;
            _publisher = publisher;
        }
        public async Task ReciveCustomEvent(Pedido @event)
        {
            await _mediator.Send(new AsignarPedidoCommand(@event));

            await _publisher.To(@event, @event.id);
        }

    }
}
