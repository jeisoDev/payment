using paymentAPI.Interface;
using paymentAPI.Interfaces;
using paymentAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
//Servicos da API
builder.Services.AddScoped<IMercadoPagoRefundService, MercadoPagoRefundService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<IBoletoService, BoletoService>();
builder.Services.AddScoped<IPaymentRequestService, PaymentRequestService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); // Mapeia os controladores

app.Run();
