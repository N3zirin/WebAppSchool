using Microsoft.EntityFrameworkCore;
using WebAppAdd.Abstraction.IRepositories;
using WebAppAdd.Abstraction.IUnitOfWorks;
using WebAppAdd.Data;
using WebAppAdd.Implementations.Repositories.EntitiesRepos;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

//string connection = "Server=FRIDAY\\MSSQLSERVER01;Database=PeopleCodeFirst_DB;TrustServerCertificate=True;Trusted_Connection=True;MultipleActiveResultSets=true";
var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(IRepository<>), typeof(IRepository<>));   
builder.Services.AddDbContext<WebAppAddDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("PeopleWebApiEntityCodeFirstContext")));
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ISchoolRepository, SchoolRepository>();
builder.Services.AddScoped<IUnitOfWork, IUnitOfWork>();

var app = builder.Build();
//repository ve unit of work mecbur deyil. Services, services interface, dto, entity, api root diqqet, methodda try catch, middleware, mapping
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
