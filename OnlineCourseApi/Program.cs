using Application.Students;
using Application.Courses;
using Domain;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Domain.ContentContext;
using Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(
   builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient(typeof(IRepository<>),typeof(MainRepository<>));
builder.Services.AddTransient(typeof(ICourseRepository),typeof(CourseRepository));

builder.Services.AddTransient<ICoursesService, CoursesService>();

builder.Services.AddTransient<IStudentsService, StudentsService>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); 
}

app.UseHttpsRedirection();


app.MapControllers();

app.Run();
