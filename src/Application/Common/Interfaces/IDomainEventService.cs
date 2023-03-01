using OnboardingServicioNotificaciones.Domain.Common;
using System.Threading.Tasks;

namespace OnboardingServicioNotificaciones.Application.Common.Interfaces;

public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}
