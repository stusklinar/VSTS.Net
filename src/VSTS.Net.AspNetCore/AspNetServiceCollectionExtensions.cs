using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http.Headers;
using System.Text;
using VSTS.Net.Interfaces;
using VSTS.Net.Types;

namespace VSTS.Net.Extensions
{
    public static class AspNetServiceCollectionExtensions
    {
        public static void AddVstsNet(this IServiceCollection services, string instanceName, string accessToken)
        {
            AddVstsNet(services, instanceName, accessToken, _ => { });
        }

        public static void AddVstsNet(this IServiceCollection services, string instanceName, string accessToken, Action<VstsClientConfiguration> cfg)
        {
            var config = VstsClientConfiguration.Default;
            cfg(config);

            services.AddHttpClient<IHttpClient,DefaultHttpClient>(client =>
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.JsonMimeType));
                var parameter = Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", "", accessToken)));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Constants.AuthenticationSchemaBasic, parameter);


            });

            services.AddSingleton<IVstsClient, VstsClient>(ctx => CreateVstsClient(instanceName, ctx, config));
            services.AddSingleton<IVstsWorkItemsClient, VstsClient>(ctx => GetVstsClient(instanceName, ctx));
            services.AddSingleton<IVstsPullRequestsClient, VstsClient>(ctx => GetVstsClient(instanceName, ctx));
        }

        private static VstsClient CreateVstsClient(string instanceName, IServiceProvider ctx, VstsClientConfiguration config)
        {
            var client = ctx.GetService<IHttpClient>();
            var logger = ctx.GetService<ILogger<VstsClient>>();
            return new VstsClient(instanceName, client, config, logger);
        }

        private static VstsClient GetVstsClient(string instanceName, IServiceProvider ctx)
        {
            return ctx.GetService<IVstsClient>() as VstsClient;
        }
    }
}
