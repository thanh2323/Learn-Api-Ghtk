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

            builder.Services.AddControllers();
          
            builder.Services.AddAuthentication("X-Client-Source").AddXClientSource(options =>
            {
                options.ClientValidator = (clientSource, token, principal) => true;
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
