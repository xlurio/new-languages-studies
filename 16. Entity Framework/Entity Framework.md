# Entity Framework

## Introduction

This is where are the Entity Framework studies. EF is the most popular ORM in .NET and works with a lot of databases.


## Models

Models are concrete classes or structs that represents the tables that will be created and manipulated in the database. Each property in the model represents a column in the table. For many-to-many relation, create collection type Property that holds instances of other model classes. To set the name of the table which the model represents, you can use the `Table` attribute.

```
[Table("Blog")]
public class Blog
{
    public int BlogId { get; set; }
    public string Url { get; set; }

    public List<Post> Posts { get; } = new();
}

[Table("Post")]
public class Post
{
    public int PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    public int BlogId { get; set; }
    public Blog Blog { get; set; }
}
```


## DbContext

The `DbContext` is a context manager that holds the database configuration, the table models and allows you to execute the CRUD operations. For each model, a DbSet property must be implemented.

```
public class BloggingContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

    public string DbPath { get; }

    public BloggingContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "blogging.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}
```


## Migration

To run the migrations, you need the following commands:

```
dotnet ef migrations add InitialCreate
dotnet ef database update
```

The first one scaffolds the migrations, and the second one execute them.


## Create, Read, Update and Delete

To run CRUD operations, all you need to do is to invoke the DbSet methods: `Add` to create data, `Remove` to delete data, query methods like `OrderBy`, `First` and `Find` to read and modify the properties from DbSet instances to update.

```
using System;
using System.Linq;

using var db = new BloggingContext();

// Note: This sample requires the database to be created before running.
Console.WriteLine($"Database path: {db.DbPath}.");

// Create
Console.WriteLine("Inserting a new blog");
db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
db.SaveChanges();

// Read
Console.WriteLine("Querying for a blog");
var blog = db.Blogs
    .OrderBy(b => b.BlogId)
    .First();

// Update
Console.WriteLine("Updating the blog and adding a post");
blog.Url = "https://devblogs.microsoft.com/dotnet";
blog.Posts.Add(
    new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
db.SaveChanges();

// Delete
Console.WriteLine("Delete the blog");
db.Remove(blog);
db.SaveChanges();
```


## Connection String

To configure a connection string, you can set on appsettings.json as follow:

```
{
  "ConnectionStrings": {
    "SampleDatabase": "Server=(localdb); Database=myDatabase; TrustedConnection=True;Ks"
  }
}
```


Then, at `Program.cs` file in the project root and type the following between the `var builder = WebApplication.CreateBuilder(args);` and `var app = builder.Build();` lines:

```
build.Services.AddDbContext<BloggingContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SampleDatabase")));
```

Resulting at:

```
namespace HelloWorldAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Configure database
        builder.Services.AddDbContext<BloggingContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("SampleDatabase")));

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
```