



var builder = WebApplication.CreateBuilder(args);

//Add ConnectionString
var connection = builder.Configuration.GetConnectionString("DefualtConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connection);
}
);
//add Student services
builder.Services.AddScoped<IStudentServices, StudentServices>();
//add Subject services
builder.Services.AddScoped<ISubjectServices, SubjectServices>();
//add Teacher services
builder.Services.AddScoped<ITeacherServices, TeacherServices>();
//add Feedback services
builder.Services.AddScoped<IFeedbackServices, FeedbackService>();


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
