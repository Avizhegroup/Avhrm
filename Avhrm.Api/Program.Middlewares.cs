namespace Avhrm.Api;
public static partial class Program
{
    public static void Configure(this WebApplication app)
    {
#if DEBUG
        app.UseDeveloperExceptionPage();
#else
        app.UseExceptionHandler("/Home/Error");
#endif

        app.UseSwagger();

        app.UseSwaggerUI();

        app.UseRouting();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseResponseCompression();

        app.MapControllers();
    }
}
