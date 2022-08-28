using CompanyEmployees.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using NLog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
LogManager.LoadConfiguration(Path.Join(Directory.GetCurrentDirectory(), "nlog.config"));

builder.Services.AddControllers();
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.ConfiureRepositoryManager();

//
//
// builder.Services.AddDbContext<RepositoryContext>(optionsBuilder =>
// {
//     optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"));
// });
//     

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
}



// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All,
});

app.UseCors("CorsPolicy");

app.UseAuthorization();

// app.Use(async (context, next) =>
// {
//     Console.WriteLine("[foo]logic before invoke next delegate in the use method.");
//  
//     await next.Invoke();
//     Console.WriteLine("[foo]logic after invoke next delegate in the use method.");
// });
//
// app.Map("/usingMapBranch", builder =>
// {
//     builder.Use(async (context, next) =>
//     {
//         Console.WriteLine("[bar] logic before invoke the next middleware.");
//         await next.Invoke();
//         Console.WriteLine("[bar] logic after invoke the next middleware.");
//     });
//     
//     builder.Run(async context =>
//     {
//         Console.WriteLine("[baz]map branch response to client.");
//         await context.Response.WriteAsync("[baz]Hello from the map branch");
//     });
//
//
// });
//
// app.MapWhen(context => context.Request.Query.ContainsKey("testQueryString"), builder =>
// {
//     builder.Run(context => context.Response.WriteAsync("Hello from the MapWhen branch."));
// });

// app.Run(async context =>
// {
//     await context.Response.WriteAsync("Hello from the middleware component.");
//     Console.WriteLine("Writing the response to the client in the Run method.");
//     
// });

app.MapControllers();

app.Run();