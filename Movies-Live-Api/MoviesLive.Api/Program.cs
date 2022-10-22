using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MoviesLive.Api.Factory;
using MoviesLive.Api.Services.EmailService;
using MoviesLive.Infrasturcture;
using TanvirArjel.EFCore.GenericRepository;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<EFContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
x => x.MigrationsAssembly("MoviesLive.Infrasturcture")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(opt =>
{
    opt.Password.RequiredLength = 7;
    opt.Password.RequireDigit = false;
    opt.Password.RequireUppercase = true;
    opt.User.RequireUniqueEmail = true;
    opt.SignIn.RequireConfirmedEmail = false;

}).AddEntityFrameworkStores<EFContext>();
builder.Services.AddScoped<IUserClaimsPrincipalFactory<IdentityUser>, CustomClaimsFactory>();


builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
});

builder.Services.AddGenericRepository<EFContext>();
var emailConfig = builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
builder.Services.AddSingleton(emailConfig);
builder.Services.AddScoped<IEmailSender, EmailSender>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var allowedCors = "allowedSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowedCors,
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.UseCors(allowedCors);
app.MapControllers();

app.Run();
