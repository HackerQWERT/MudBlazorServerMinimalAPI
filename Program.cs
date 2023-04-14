global using Microsoft.AspNetCore.SignalR;

global using System.Net.Http;
global using System.Text.Json;
global using System.Text;
global using System.Text.Json.Serialization;


global using MudBlazorServer.Services;
global using MudBlazorServer.Models;
global using MudBlazorServer.Hubs;

global using Dapper;
global using MySql.Data;
global using MySql.Data.MySqlClient;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();

builder.Services.AddSignalR().AddHubOptions<AIGalaxyHub>(options =>
{
    options.MaximumReceiveMessageSize = 5 * 1024 * 1024; // 5MB
});

var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.MapHub<AIGalaxyHub>("/AIGalaxyHub");

app.Run();
