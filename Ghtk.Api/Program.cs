using ClientAuthentication;
using Ghtk.Api.AuthenticationHandler;
using Ghtk.Authorization;
using Microsoft.AspNetCore.Authentication;

namespace Ghtk.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            IClientSourceAuthenticationHandler clientSourceAuthenticationHandler = new RemoteClientSourceAuthenticationHandler(builder.Configuration["AuthenticationService"] ?? throw new Exception("AuthenticationService string not found"));
            
            builder.Services.AddControllers();
          
            builder.Services.AddAuthentication("X-Client-Source").AddXClientSource(options =>
            {
                options.ClientValidator = (clientSource, token, principal) => clientSourceAuthenticationHandler.Validate(clientSource);
                options.IssuerSignInKey = builder.Configuration["IssuerSignInKey"] ?? "";

            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
