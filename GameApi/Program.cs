using gameapi.GameContext;
using Microsoft.EntityFrameworkCore;
using gameapi.repository;
using gameapi.Services.GrpcGameService;
using gameapi.EventProcceser;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<gamecontext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr")));
builder.Services.AddScoped<IgameRepository,gameRepsitory>();
builder.Services.AddSingleton<IEventProcceser,EventProcceser>();
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{   
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseHttpsRedirection();
app.UseEndpoints(endpoint =>
{
    endpoint.MapControllers();
    endpoint.MapGrpcService<GrpcGameService>();
                    


    endpoint.MapGet("/protos/UserRatedGames.proto",async context =>
            {
                await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client.");
            });
});

app.Run();
