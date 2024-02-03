using OpenAIApp.Configurations;
using OpenAIApp.Services.Abstract;
using OpenAIApp.Services.Concrete;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<OpenAiAppConfig>(builder.Configuration.GetSection("OpenAI"));
builder.Services.AddScoped<IOpenAiService, OpenAiService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();