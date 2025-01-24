using EcommerceAPI.Application.Bases;
using EcommerceAPI.Application.Beheviors;
using EcommerceAPI.Application.Exceptions;
using EcommerceAPI.Application.Features.Products.Rules;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddTransient<ExceptionMiddleware>();
            //services.AddTransient<ProductRules>();
            services.AddRulesFromAssambylContaining(assembly, typeof(BaseRules));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));

            services.AddValidatorsFromAssembly(assembly);
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("az");
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehevior<,>));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RedisCacheBehevior<,>));

        }

        private static IServiceCollection AddRulesFromAssambylContaining(
            this IServiceCollection services,
            Assembly assembly,
            Type type)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (var item in types) services.AddTransient(item);

            return services;
        }
    }
}
