var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add API Documentation
builder.Services.AddSwaggerGen();

// Add controllers services
builder.Services.AddControllers();

// Add MongoDB client
builder.AddMongoDBClient(connectionName: "mongodb");

// Add services to the container.
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

// map controllers to endpoints
app.MapControllers();
// Add API Documentation
app.UseSwagger();
// Add API Documentation
app.UseSwaggerUI();

app.MapDefaultEndpoints();

app.Run();

