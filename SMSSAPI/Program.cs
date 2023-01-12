using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SMSSAPI.Data;
using SMSSAPI.Models.Interface;
using SMSSAPI.Models.Repository;
using System;
using System.Text.Json.Serialization;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddControllersWithViews()
        .AddJsonOptions(options =>
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

        //connectionstring
        builder.Services.AddDbContext<SMSSContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("SMSSConnection")));

        //repositories
        builder.Services.AddScoped<IStaffDetailsService, StaffDetailsRepository>();
        builder.Services.AddScoped<IClassDetailsService, ClassDetailsRepository>();
        builder.Services.AddScoped<ICommonService, CommonRepository>();
        builder.Services.AddScoped<ISectionDetailsService, SectionDetailsRepository>();
        builder.Services.AddScoped<ISubjectService, SubjectRepository>();
        builder.Services.AddScoped<IStudentDetailsService, StudentDetailsRepository>();

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
    }
}