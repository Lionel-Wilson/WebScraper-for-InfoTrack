using SearchHistoryService.Interfaces;
using SearchService.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<ISearchService, SearchService.Implementations.SearchService>();
builder.Services.AddTransient<ISearchHistoryService, SearchHistoryService.Implementations.SearchHistoryService>();
builder.Services.AddTransient<SearchHistoryService.Implementations.SearchHistoryService>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
