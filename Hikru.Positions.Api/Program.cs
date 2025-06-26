using Hikru.Positions.Application.Departments.Queries.GetAllFromApex;
using Hikru.Positions.Application.Positions.Commands.Update;
using Hikru.Positions.Application.Recruiters.Queries.GetAllFromApex;
using Hikru.Positions.Infrastructure.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontEnd", policy =>
    {
        policy.WithOrigins(
                "http://localhost:5173",
                "https://postionsfront.netlify.app" 
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(GetAllDepartmentsHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(GetAllRecruitersHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(UpdatePositionHandler).Assembly);
});

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.Configure<ApexApiOptions>(builder.Configuration.GetSection("ApexApi"));

var app = builder.Build();

if (app.Environment.IsDevelopment() || true) // para que también funcione en producción
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowFrontEnd");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
