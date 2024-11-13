using LibApi.Entities;
using LibApi.Seeder;
using LibApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LibDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("LibDbContext")));
builder.Services.AddTransient<AuthorSeeder>();
builder.Services.AddTransient<MemberSeeder>();
builder.Services.AddTransient<PublisherSeeder>();
builder.Services.AddTransient<GenreSeeder>();
builder.Services.AddTransient<BookGenresSeeder>();
builder.Services.AddTransient<BookPublishersSeeder>();
builder.Services.AddTransient<BookSeeder>();
builder.Services.AddTransient<BorrowRecordsSeeder>();
builder.Services.AddTransient<ReservationSeeder>();
builder.Services.AddTransient<MainDbSeeder>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<MainDbSeeder>();
    seeder.Seed();
}

app.Run();