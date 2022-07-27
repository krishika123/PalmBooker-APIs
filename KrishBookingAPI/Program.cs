using KrishBookingAPI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", policy =>
    {
    policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()
            //.AllowCredentials()
            ;
    });
});



// Add services to the container.
builder.Services.AddDbContext<KRISHBOOKINGDBContext>(options =>
    options.UseSqlServer(builder.Configuration["ConnectionStrings:PalmBookingDb"]));

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
builder.Services.AddAuthentication("Bearer")
   .AddJwtBearer("Bearer", opt =>
   {
       opt.RequireHttpsMetadata = true;
       opt.Authority = builder.Configuration["AuthSettings:Authority"];
       opt.Audience = builder.Configuration["AuthSettings:Audience"];
   });
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "PalmBooking API", Version = "v1" });
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows
        {
            Implicit = new OpenApiOAuthFlow
            {
                AuthorizationUrl = new Uri(builder.Configuration["AuthSettings:AuthorizationUrl"]),
                TokenUrl = new Uri(builder.Configuration["AuthSettings:TokenUrl"]),
                Scopes = new Dictionary<string, string>
            {
                {builder.Configuration["AuthSettings:Audience"], "PalmBooking API - full access"}
            }
            }
        }
    }); 
    options.OperationFilter<AuthorizeCheckOperationFilter>();

});


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI(options =>
//    {
//        options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

//        options.OAuthClientId("api-swagger");
//        options.OAuthClientSecret("secret");
//        options.OAuthAppName("PalmBooking API - Swagger");
//        //options.OAuthUsePkce();
//    });
//}
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

    options.OAuthClientId(builder.Configuration["AuthSettings:ClientId"]);
    options.OAuthClientSecret(builder.Configuration["AuthSettings:ClientSecret"]);
    options.OAuthAppName("PalmBooking API - Swagger");
    //options.OAuthUsePkce();
});
app.UseHttpsRedirection();
//app.UseCors("CorsPolicy");
app.UseCors("AllowOrigin");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


public class AuthorizeCheckOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var hasAuthorize =
          context.MethodInfo.DeclaringType.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any()
          || context.MethodInfo.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any();

        if (hasAuthorize)
        {
            operation.Responses.Add("401", new OpenApiResponse { Description = "Unauthorized" });
            operation.Responses.Add("403", new OpenApiResponse { Description = "Forbidden" });

            operation.Security = new List<OpenApiSecurityRequirement>
            {
                new OpenApiSecurityRequirement
                {
                    [
                        new OpenApiSecurityScheme {Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "oauth2"}
                        }
                    ] = new[] { "ebookkeeping-api" }
                }
            };

        }
    }
}
