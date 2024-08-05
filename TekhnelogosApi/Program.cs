using Business.Abstract;
using Business.Concrete;
using Business.Extensions;
using Business.MappingProfiles;
using Business.Validators;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using System.Text.Json.Serialization;

// Early init of NLog to allow startup and exception logging, before host is built
var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddBusinessServices(builder.Configuration);

    // Add services to the container.
    builder.Services.AddControllers()
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<PersonelViewModelValidator>())
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<DepartmentViewModelValidator>())
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<TitleViewModelValidator>());
    //.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProjectViewModelValidator>());

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();


    builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

    builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    });


    builder.Services.AddDbContext<ApplicationContext>(options =>
           options.UseSqlServer(builder.Configuration.GetConnectionString("MsSQLConnection")));

    builder.Services.AddScoped<IPersonelDal, EFPersonelDal>();
    builder.Services.AddScoped<IPersonelService, PersonelManager>();
    builder.Services.AddScoped<IDepartmentDal, EfDepartmentDal>();
    builder.Services.AddScoped<IDepartmentService, DepartmentManager>();
    builder.Services.AddScoped<ITitleDal, EfTitleDal>();
    builder.Services.AddScoped<ITitleService, TitleManager>();
    builder.Services.AddScoped<IProjectDal, EfProjectDal>();
    builder.Services.AddScoped<IProjectService, ProjectManager>();
    builder.Services.AddScoped<IUserDal, EfUserDal>();
    builder.Services.AddScoped<IUserService, UserManager>();
    builder.Services.AddScoped<ITokenService, JwtHelper>();
    builder.Services.AddScoped<IAuthenticationService, AuthenticationManager>();




    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        });
    }

    app.UseMiddleware<ExceptionHandlingMiddleware>();
    app.UseMiddleware<LoggingMiddleware>();

    app.UseHttpsRedirection();


    app.UseAuthentication();
    app.UseAuthorization();


    app.MapControllers();

    await app.RunAsync();
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}