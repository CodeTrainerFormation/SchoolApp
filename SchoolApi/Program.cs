using Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.ComponentModel;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolDb"))
);

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo() 
    { 
        Title = "SchoolApi", 
        Version = "v1", 
        Description = "WebService de l’école",
        TermsOfService = new Uri("http://contoso.com"),
        Contact = new OpenApiContact
        { 
            Name = "Shayne Boyer", 
            Url = new Uri("https://twitter.com/spboyer") 
        },
        License = new OpenApiLicense
        { 
            Name = "Use under LICX", 
            Url = new Uri("https://example.com/license")
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddCors(setup =>
{
    setup.AddDefaultPolicy(p =>
    {
        p.AllowAnyHeader();
        p.WithMethods("GET", "POST", "PUT", "DELETE", "OPTIONS");
        p.WithOrigins("https://localhost:7127");
    });

    //setup.AddDefaultPolicy(policy =>
    //{
    //    policy.AllowAnyHeader();
    //    policy.WithMethods("GET", "POST", "PUT", "OPTIONS");
    //    policy.WithOrigins("http://mysite.lan", "https://mysite.lan", "https://mysite.com");
    //});

    //setup.AddPolicy("admin", policy =>
    //{
    //    policy.AllowAnyHeader();
    //    policy.WithMethods("GET", "POST", "PUT", "DELETE", "OPTIONS");
    //    policy.WithOrigins("https://admin.mysite.lan");
    //});
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
