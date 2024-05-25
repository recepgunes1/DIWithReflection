using System.Reflection;
using Business.Common.LifeTimeMarkers;
using Business.Services.Abstracts;
using Business.Services.Concretes;
using Microsoft.Extensions.DependencyInjection;

namespace Business;

public static class Registration
{
    public static IServiceCollection LoadServicesManually(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<ICommentService, CommentService>();
        serviceCollection.AddScoped<IBookingService, BookingService>();
        serviceCollection.AddTransient<IUserService, UserService>();
        return serviceCollection;
    }

    public static IServiceCollection LoadServicesUsingReflection(this IServiceCollection serviceCollection)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var types = assembly.GetTypes().Where(p => p is { Namespace: not null, MemberType: MemberTypes.TypeInfo })
            .ToList();
        var abstracts = types.Where(p => p is { IsInterface: true } && p.Namespace!.Contains("Services.Abstracts"))
            .ToList();
        var concretes = types.Where(p =>
            p is { IsClass: true, IsAbstract: false } && p.Namespace!.Contains("Services.Concretes")).ToList();
        foreach (var @abstract in abstracts)
        {
            var concrete = concretes.FirstOrDefault(p => p.GetInterfaces().Contains(@abstract));
            if (concrete != null)
            {
                serviceCollection.AddScoped(@abstract, concrete);
            }
        }

        return serviceCollection;
    }

    public static IServiceCollection LoadServicesUsingReflectionWithLifeTime(this IServiceCollection serviceCollection)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var types = assembly.GetTypes().Where(p => p is { Namespace: not null, MemberType: MemberTypes.TypeInfo })
            .ToList();
        var abstracts = types.Where(p => p is { IsInterface: true } && p.Namespace!.Contains("Services.Abstracts"))
            .ToList();
        var concretes = types.Where(p =>
            p is { IsClass: true, IsAbstract: false } && p.Namespace!.Contains("Services.Concretes")).ToList();
        foreach (var @abstract in abstracts)
        {
            var concrete = concretes.FirstOrDefault(p => p.GetInterfaces().Contains(@abstract));
            if (concrete == null)
                continue;
            if (concrete.GetInterfaces().Contains(typeof(IScopedService)))
            {
                serviceCollection.AddScoped(@abstract, concrete);
            }
            else if (concrete.GetInterfaces().Contains(typeof(ITransientService)))
            {
                serviceCollection.AddTransient(@abstract, concrete);
            }
            else if (concrete.GetInterfaces().Contains(typeof(ISingletonService)))
            {
                serviceCollection.AddSingleton(@abstract, concrete);
            }
        }
        return serviceCollection;
    }

    public static IServiceCollection LoadServicesUsingReflectionWithLifeTime_Strict(
        this IServiceCollection serviceCollection)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var types = assembly.GetTypes().Where(p => p is { Namespace: not null, MemberType: MemberTypes.TypeInfo })
            .ToList();
        var abstracts = types.Where(p => p is { IsInterface: true } && p.Namespace!.Contains("Services.Abstracts"))
            .ToList();
        var concretes = types.Where(p =>
            p is { IsClass: true, IsAbstract: false } && p.Namespace!.Contains("Services.Concretes")).ToList();
        foreach (var @abstract in abstracts)
        {
            var concrete = concretes.FirstOrDefault(p => p.GetInterfaces().Contains(@abstract));
            if (concrete == null)
                throw new Exception($"There is no concrete structure for {@abstract.FullName}");
            if (concrete.GetInterfaces().Contains(typeof(IScopedService)))
            {
                serviceCollection.AddScoped(@abstract, concrete);
            }
            else if (concrete.GetInterfaces().Contains(typeof(ITransientService)))
            {
                serviceCollection.AddTransient(@abstract, concrete);
            }
            else if (concrete.GetInterfaces().Contains(typeof(ISingletonService)))
            {
                serviceCollection.AddSingleton(@abstract, concrete);
            }
            else
            {
                throw new Exception($"There is no life time marker for {concrete}");
            }
        }
        return serviceCollection;
    }
}