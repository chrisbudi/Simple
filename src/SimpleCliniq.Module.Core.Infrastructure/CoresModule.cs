using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Simple.Common.Infrastructure.Outbox;
using SimpleCliniq.Module.Core.Domain.Interfaces;
using SimpleCliniq.Module.Core.Infrastructure.Database;
using SimpleCliniq.Module.Core.Infrastructure.Inbox;
using SimpleCliniq.Module.Core.Infrastructure.Outbox;
using SimpleCliniq.Module.Core.Infrastructure.Repositories;

namespace SimpleCliniq.Module.Core.Infrastructure;

public static class CoresModule
{
    public static IServiceCollection AddCoresModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDomainEventHandlers();

        services.AddIntegrationEventHandlers();

        services.AddInfrastructure(configuration);

        //services.AddEndpoints(Presentation.AssemblyReference.Assembly);

        return services;
    }

    //public static Action<IRegistrationConfigurator> ConfigureConsumers(string redisConnectionString)
    //{
    //    return registration => registration
    //        .AddSagaStateMachine<CancelEventSaga, CancelEventState>()
    //        .RedisRepository(redisConnectionString);
    //}

    private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CoreDbContext>((sp, options) =>
            options
                .UseNpgsql(
                    configuration.GetConnectionString("Database"),
                    npgsqlOptions => npgsqlOptions
                        .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Cores))
                //.UseSnakeCaseNamingConvention()
                .AddInterceptors(sp.GetRequiredService<InsertOutboxMessagesInterceptor>()));

        //services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<EventsDbContext>());


        // add scope dbcontext
        services.AddScoped<IDiagnosaMatrixRepository, DiagnosaMatrixRepository>();
        services.AddScoped<IDiagnosaRepository, DiagnosaRepository>();
        services.AddScoped<IDokterRepository, DokterRepository>();
        services.AddScoped<IDtdRepository, DtdRepository>();
        services.AddScoped<IHargaRekananRepository, HargaRekananRepository>();
        services.AddScoped<IJadwalDokterRepository, JadwalDokterRepository>();
        services.AddScoped<ILaboratoriumHargaRepository, LaboratoriumHargaRepository>();
        services.AddScoped<ILaboratoriumRekananRepository, LaboratoriumRekananRepository>();
        services.AddScoped<IMorfologiRepository, MorfologiRepository>();
        services.AddScoped<IPasienRepository, PasienRepository>();
        services.AddScoped<IRadiologiHargaRepository, RadiologiHargaRepository>();
        services.AddScoped<IRadiologiRekananRepository, RadiologiRekananRepository>();
        services.AddScoped<IRekananRepository, RekananRepository>();
        services.AddScoped<IRuangRepository, RuangRepository>();
        services.AddScoped<ISmfRepository, SmfRepository>();
        services.AddScoped<ITindakanRepository, TindakanRepository>();

        services.Configure<OutboxOptions>(configuration.GetSection("Cores:Outbox"));

        services.ConfigureOptions<ConfigureProcessOutboxJob>();

        services.Configure<InboxOptions>(configuration.GetSection("Cores:Inbox"));

        services.ConfigureOptions<ConfigureProcessInboxJob>();
    }

    private static void AddDomainEventHandlers(this IServiceCollection services)
    {
        //Type[] domainEventHandlers = Application.AssemblyReference.Assembly
        //    .GetTypes()
        //    .Where(t => t.IsAssignableTo(typeof(IDomainEventHandler)))
        //    .ToArray();

        //foreach (Type domainEventHandler in domainEventHandlers)
        //{
        //    services.TryAddScoped(domainEventHandler);

        //    Type domainEvent = domainEventHandler
        //        .GetInterfaces()
        //        .Single(i => i.IsGenericType)
        //        .GetGenericArguments()
        //        .Single();

        //    Type closedIdempotentHandler = typeof(IdempotentDomainEventHandler<>).MakeGenericType(domainEvent);

        //    services.Decorate(domainEventHandler, closedIdempotentHandler);
        //}
    }

    private static void AddIntegrationEventHandlers(this IServiceCollection services)
    {
        //Type[] integrationEventHandlers = Presentation.AssemblyReference.Assembly
        //    .GetTypes()
        //    .Where(t => t.IsAssignableTo(typeof(IIntegrationEventHandler)))
        //    .ToArray();

        //foreach (Type integrationEventHandler in integrationEventHandlers)
        //{
        //    services.TryAddScoped(integrationEventHandler);

        //    Type integrationEvent = integrationEventHandler
        //        .GetInterfaces()
        //        .Single(i => i.IsGenericType)
        //        .GetGenericArguments()
        //        .Single();

        //    Type closedIdempotentHandler =
        //        typeof(IdempotentIntegrationEventHandler<>).MakeGenericType(integrationEvent);

        //    services.Decorate(integrationEventHandler, closedIdempotentHandler);
        //}
    }
}
