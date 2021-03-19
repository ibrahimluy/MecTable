using Mec.Core.ActionUtils;
using Mec.Core.Attributes;
using Mec.Web.DataTable.Models.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Mec.Web.DataTable
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddMecDataTable(this IServiceCollection services)
        {
            return services.AddMecDataTable(_ => { });
        }

        public static IServiceCollection AddMecDataTable(this IServiceCollection services, [NotNull] MecDataTableOptions configure)
        {
            return services.AddMecDataTable(_ =>
            {
                _.DateTimeTimeZone = configure.DateTimeTimeZone;
                _.DateFormat = configure.DateFormat;
                _.DateTimeFormat = configure.DateTimeFormat;
                _.RequestDateTimeFormatType = configure.RequestDateTimeFormatType;
                _.DefaultDisplayText = configure.DefaultDisplayText;
                _.SharedResourceType = configure.SharedResourceType;
            });
        }

        public static IServiceCollection AddMecDataTable(this IServiceCollection services, [NotNull] Action<MecDataTableOptions> configure)
        {
            services.Configure(configure);

            if (MecDataTableOptions.Instance == null)
            {
                MecDataTableOptions.Instance = configure.GetValue();
            }

            // Add DataTable Model Binder
            services.Configure<MvcOptions>(mvcOptions =>
            {
                mvcOptions.AddDataTableModelBinder();
            });

            return services;
        }
    }
}