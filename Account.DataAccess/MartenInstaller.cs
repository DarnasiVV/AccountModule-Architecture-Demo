using Marten.Services;
using Marten;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TMS.DataAcess;
using Marten.Events.Daemon.Resiliency;
using Marten.Events.Projections;
using Account.Service.Entities.Projections;

namespace Account.DataAccess
{
    public static class MartenInstaller
    {
        public static void AddMarten(this IServiceCollection services, string connectionstring)
        {
            services.AddMarten(options => {
                options.Connection(connectionstring);
                options.Projections.Add<AccountProjection>(ProjectionLifecycle.Async);
                options.Projections.Add<AccountHolderDetailsProjection>(ProjectionLifecycle.Async);
            }).AddAsyncDaemon(DaemonMode.HotCold);

            // services.AddMarten(options => { }).AddAsyncDaemon(DaemonMode.HotCold);
            // services.AddSingleton(CreateDocumentStore(connectionstring));

            services.AddScoped<IDataStore, MartenDataStore>();
        }
        private static IDocumentStore CreateDocumentStore(string cn)
        {
            var store = DocumentStore.For(_ =>
            {
                _.Connection(cn);
                _.AutoCreateSchemaObjects = Weasel.Core.AutoCreate.All;
              //  _.Projections.Add<AccountProjection>(ProjectionLifecycle.Inline);
                _.Serializer(CustomizeJsonSerializer());
            });
            return store;
        }
        private static JsonNetSerializer CustomizeJsonSerializer()
        {
            var serializer = new JsonNetSerializer();
            serializer.Customize(_ =>
            {
                _.ContractResolver = new ProtectedSettersContractResolver();
                _.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
            });
            return serializer;
        }
    }
}
