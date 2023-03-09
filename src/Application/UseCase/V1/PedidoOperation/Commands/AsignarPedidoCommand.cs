using Andreani.ARQ.Core.Interface;
using Andreani.Scheme.Onboarding;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnboardingServicioNotificaciones.Application.UseCase.V1.PedidoOperation.Commands
{
    public class AsignarPedidoCommand : IRequest<Pedido>
    {
        public AsignarPedidoCommand(Pedido pedidon)
        {
            this.pedido = pedidon;
        }

        public Pedido pedido { get; set; }
    }
    public class UpdatePedidoCommandHandler : IRequestHandler<AsignarPedidoCommand, Pedido>
    {

        private readonly ILogger<UpdatePedidoCommandHandler> _logger;

        public UpdatePedidoCommandHandler(ILogger<UpdatePedidoCommandHandler> logger)
        {
            _logger = logger;
        }

        public async Task<Pedido> Handle(AsignarPedidoCommand request, CancellationToken cancellationToken)
        {
            request.pedido.numeroDePedido = new Random().Next();
            _logger.LogInformation("el numero de pedido asignado fue" + request.pedido.numeroDePedido);
            return request.pedido;
        }
    }
}
