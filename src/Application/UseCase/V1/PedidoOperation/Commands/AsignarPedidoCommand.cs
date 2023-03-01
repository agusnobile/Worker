using Andreani.Scheme.Onboarding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingServicioNotificaciones.Application.UseCase.V1.PedidoOperation.Commands
{
    public class AsignarPedidoCommand
    {
        public AsignarPedidoCommand(Pedido @event)
        {
            @event.numeroDePedido = new Random().Next();
        }
    }
}
