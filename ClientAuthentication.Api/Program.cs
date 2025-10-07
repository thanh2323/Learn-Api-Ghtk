namespace ClientAuthentication.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddSingleton<IClientSourceAuthenticationHandler>(
                ServiceProvider =>
                {
                    var connectionString = builder.Configuration.GetConnectionString("ClientAuthentication") ?? throw new Exception("ClientAuthentication string not found");
                    return new SqlServerClientSourceAuthenticationHandler(connectionString);
                }
                );
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
