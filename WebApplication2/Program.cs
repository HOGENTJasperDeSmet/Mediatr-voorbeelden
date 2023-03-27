using MediatR;
using WebApplication2;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly); //Auto add handlers
});
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(Pipeline<,>));

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/RequestTest/{id}", async (int id, IMediator mediator) =>
{
    return await mediator.Send(new RequestTest { id = id });
});

app.MapGet("/NotificationTest", async (IMediator mediator) =>
{
    await mediator.Publish(new Notification());
    return Results.Ok();
});

app.MapGet("/NotificationTestFireAndForget", async (IMediator mediator) =>
{
    mediator.Publish(new Notification());

    return Results.Ok();
});


app.MapGet("/streamTest", async (IMediator mediator,CancellationToken cancellationtoken) =>
{
    var streamTest = new StreamTest();
    return mediator.CreateStream(streamTest, cancellationtoken);
});

app.Run();



