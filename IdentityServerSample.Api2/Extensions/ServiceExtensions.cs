using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace IdentityServerSample.Api2.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureAuthentication(this IServiceCollection Services)
    {
        Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                ///Token'ı yayınlayan Auth Server adresi bildiriliyor.
                /// Yani yetkiyi dağıtan mekanizmanın adresi bildirilerek ilgili API ile ilişkilendiriliyor.
                options.Authority = "https://localhost:7054";//Auth Server Url
                //Auth Server uygulamasındaki 'Api1' isimli resource ile bu API ilişkilendiriliyor.
                options.Audience = "Api2";//Resource
            });


    }
    public static void ConfigureAuthorization(this IServiceCollection Services)
    {
        Services.AddAuthorization(_ =>
        {
            _.AddPolicy("Write", policy => { policy.RequireClaim("scope","Api2.Write"); });
            _.AddPolicy("Read", policy => { policy.RequireClaim("scope","Api2.Read"); });

        });

    }
}