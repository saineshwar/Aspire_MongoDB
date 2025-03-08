var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var mongo = builder.AddMongoDB("mongo")
    .WithMongoExpress().WithDataVolume();

var mongodb = mongo.AddDatabase("mongodb","ProductDatabase");

var apiService = 
     builder.AddProject<Projects.AspireApp6_ApiService>("apiservice")
    .WithReference(mongodb)
    .WaitFor(mongodb);

builder.AddProject<Projects.AspireApp6_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
