using MediatR;
using Microsoft.EntityFrameworkCore;
using Udemy.Cqrs.CQRS.Handlers;
using Udemy.Cqrs.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StudentContext>(options =>
{
    options.UseSqlServer("server=DESKTOP-128VR9S; database=StudentDb;integrated security=true; TrustServerCertificate=True");
});

builder.Services.AddMediatR(typeof(Program));
//builder.Services.AddSingleton<IMediator, Mediator>();

//builder.Services.AddScoped<GetStudentByIdQueryHandler>();
//builder.Services.AddScoped<GetStudentsQueryHandler>();
//builder.Services.AddScoped<CreateStudentCommandHandler>();
//builder.Services.AddScoped<RemoveStudentCommandHandler>();
//builder.Services.AddScoped<UpdateStudentCommandHandler>();


builder.Services.AddControllers().AddNewtonsoftJson(opt =>
{
    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});


var app = builder.Build();
app.UseRouting();

app.UseEndpoints(endpoints => app.MapControllers());

app.Run();
