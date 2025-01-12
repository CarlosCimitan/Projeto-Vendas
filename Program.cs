using Microsoft.EntityFrameworkCore;
using ProjetoVendas.Data;
using ProjetoVendas.Services.Cliente;
using ProjetoVendas.Services.Email;
using ProjetoVendas.Services.Vendas;
using ProjetoVendas.Services.Vendedor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));

builder.Services.AddTransient<EmailService>();

builder.Services.AddScoped<IVendedorInterface,VendedorService>();
builder.Services.AddScoped<IClienteInterface,ClienteService>();
builder.Services.AddScoped<IVendasInterface,VendasService>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

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
