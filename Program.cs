using Microsoft.EntityFrameworkCore;
using WebApplication1;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TestDataDb>(opt => opt.UseInMemoryDatabase("TestDataDb"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();


// Init db
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var testDataDb = services.GetService<TestDataDb>();
    testDataDb.TestDatas.Add(new TestData { Id = 1, Name = "abc", IsComplete = false });
    testDataDb.TestDatas.Add(new TestData { Id = 2, Name = "abc", IsComplete = false });
    testDataDb.TestDatas.Add(new TestData { Id = 3, Name = "abc", IsComplete = false });
    testDataDb.SaveChanges();
}

app.MapPost("/getApi", async (TestData data, TestDataDb db) =>
{
    var dbGetData = await db.TestDatas.FindAsync(data.Id);
    if (dbGetData == null)
    {
        return Results.NoContent();
    }
    return Results.Ok(dbGetData);
});

app.MapPost("/addApi", async (TestData data, TestDataDb db) =>
{
    db.TestDatas.Add(data);
    await db.SaveChangesAsync();
    return Results.Created($"/addApi/{data.Id}", data);
});

app.Run();
