using Microsoft.EntityFrameworkCore;
using TaskApi.Data;
using TaskApi.Data.Daos;
using TaskApi.Data.Daos.Interfaces;
using TaskApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var taskDbConnection = builder.Configuration.GetConnectionString("TaskDbConnection");

builder.Services.AddDbContext<WorkTaskContext>(opts =>
    opts.UseMySql(taskDbConnection,
    ServerVersion.AutoDetect(taskDbConnection)));

builder.Services.AddScoped<WorkTaskService>();
builder.Services.AddTransient<IWorkTaskDao, WorkTaskDao>(); // Essa fun��o � respons�vel pela inje��o de depend�ncia
builder.Services.AddTransient<IWorkActivityDao, WorkActivityDao>(); // Essa fun��o � respons�vel pela inje��o de depend�ncia
builder.Services.AddTransient<ICategoryDao, CategoryDao>(); // Essa fun��o � respons�vel pela inje��o de depend�ncia
builder.Services.AddTransient<ITaskCategoryDao, TaskCategoryDao>(); // Essa fun��o � respons�vel pela inje��o de depend�ncia

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
