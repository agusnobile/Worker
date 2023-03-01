using Andreani.ARQ.AMQStreams.Extensions;
using Andreani.ARQ.WebHost.Extension;
using Andreani.Scheme.Onboarding;
using Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using OnboardingServicioNotificaciones.Application;
using OnboardingServicioNotificaciones.Infrastructure;
using OnboardingServicioNotificaciones.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAndreaniWebHost(args);
builder.Services.ConfigureAndreaniServices();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);


builder.Services
    .AddKafka(builder.Configuration)
    .ToConsumer<Subscriber, Pedido>("PedidoCreado")
    .CreateOrUpdateTopic(6, "PedidoAsignado")
    .ToProducer<Pedido>("PedidoAsignado")
    .Build();

var app = builder.Build();

app.ConfigureAndreani(app.Environment, app.Services.GetRequiredService<IApiVersionDescriptionProvider>());

app.Run();

