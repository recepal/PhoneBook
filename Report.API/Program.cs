

using MediatR;
using Microsoft.EntityFrameworkCore;
using Report.API.Context;

var builder = WebApplication.CreateBuilder(args);
ConfigureServices(builder);
var app = builder.Build();
Configure(app, builder.Environment);

static void ConfigureServices(WebApplicationBuilder builder)
{
    IServiceCollection services = builder.Services;

    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(c => c.SwaggerDoc("v1",
        new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Report.Api", Version = "v1" }));
    services.AddControllers();



    services.AddMediatR(typeof(Program));

    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    services.AddDbContext<PostgreDbContext>(options =>
        options.UseNpgsql(connectionString));

    services.AddMvc();
    //services.AddScoped<IContactService, ContactService>();

    //var mapperConfig = new MapperConfiguration(mc =>
    //{
    //    mc.AddProfile(new MappingProfile());
    //});

    //IMapper mapper = mapperConfig.CreateMapper();
    //services.AddSingleton(mapper);
}

static void Configure(WebApplication app, IWebHostEnvironment env)
{
    app.Services.CreateScope().ServiceProvider.GetRequiredService<PostgreDbContext>().Database.Migrate();

    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Report.Service v1");
            c.RoutePrefix = string.Empty;
        });
    }

    app.UseRouting();
    app.UseAuthorization();
    app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

    app.Run();
}