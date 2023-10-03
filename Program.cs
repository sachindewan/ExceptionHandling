using ExceptionHandling.Exception.MiddleWare;
using ExceptionHandling.Services;
using PS.Vault.AwsIam;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IRegistrationService, RegistrationService>();
builder.Services.AddTransient<GlobalExceptionMiddleWare>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
                builder => builder.WithOrigins("www.tinder.com")
                .AllowAnyMethod()
                .AllowAnyHeader());
});
var builderConfig = builder.Configuration;
var myval = builder.Configuration.GetSection("secrets").GetValue<string>("data");
builderConfig.AddVaultAwsIamAuthSecrets(
    builderConfig.GetValue<string>("VaultAddress"),
    builderConfig.GetValue<string>("VaultMountPath"),
    builderConfig.GetValue<string>("VaultRole"),
    builderConfig.GetValue<string>("VAULT_LOCAL_DEV_TOKEN"),
    secretEngines => secretEngines
        .IncludeSecret(
            // You can include 1 or more paths here
            "path/to/secret/group1",
            "path/to/secret/group2",
            "path/to/secret/groupN"
        )
        .IncludeSecretv2(
            // You can include 1 or more paths here
            "path/to/secret/group1",
            "path/to/secret/group2",
            "path/to/secret/groupN"
        )
);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseExceptionHandler("/api/error");
app.UseHttpsRedirection();
app.UseMiddleware<GlobalExceptionMiddleWare>();
app.UseAuthorization();

app.MapControllers();

app.Run();
