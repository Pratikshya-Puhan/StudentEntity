using StudentEntity.Repository;
using StudentEntity.Services;
{
   
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();

    // Add Services
    builder.Services.AddTransient<IFileUploadService, FileUploadService>();

    // Add Repository
    builder.Services.AddScoped<ICourseRepository, CourseRepository>();

    // Add Services
    builder.Services.AddTransient<IFileUploadService, FileUploadService>();

    // Add Repository
    builder.Services.AddScoped<IStudentRepository, StudentRepository>();





    var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }


    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
