using HostGrpc.Server.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using ProtoBuf.Grpc.Server;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
//builder.Services.AddGrpcReflection();

// ----- Register CodeFirstGrpc() and GrpcWeb() services in program.cs ----- //

builder.Services.AddCodeFirstGrpc(config => { config.ResponseCompressionLevel = System.IO.Compression.CompressionLevel.Optimal; });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    //app.MapGrpcReflectionService();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

// ---- Add GrpcWeb middleware in between UseRouting() and UseEndpoints(): ---- //

app.UseGrpcWeb(new GrpcWebOptions() { DefaultEnabled = true });

// ---- Publish the service ---- //

app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<MYService>();
});

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
