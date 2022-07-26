
using MyBlogApi.Services;
using MyBlogApi.Dto;
using MyBlogApi.Domain;
using MyBlogApi.Infrastructure.Data.CategoryModel;
using MyBlogApi.Infrastructure.Data.PostModel;
using MyBlogApi.Infrastructure.Data.TagModel;
using Microsoft.EntityFrameworkCore;
using MyBlogApi.Infrastructure;
using Microsoft.EntityFrameworkCore.Design;
using MyBlogApi.Infrastructure.Data.UoW;
using static MyBlogApi.Infrastructure.Data.IRepository;
using MyBlogApi.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<Context>(c =>
{
    try
    {
        string connectionString = builder.Configuration.GetValue<string>("DefaultConnection");
        c.UseSqlServer(connectionString);
    }
    catch (Exception)
    {
        //var message = ex.Message;
    }
});


/*builder.Services.AddScoped<IRepository<Post>>(s =>
    new PostRepository(builder.Configuration.GetValue<string>("DefaultConnection")));
builder.Services.AddScoped<IService<Post, PostDto>, PostService>();


builder.Services.AddScoped<IRepository<Tag>>(s =>
    new TagRepository(builder.Configuration.GetValue<string>("DefaultConnection")));
builder.Services.AddScoped<IService<Tag, TagDto>, TagService>();

builder.Services.AddScoped<IRepository<Category>>(s =>
    new CategoryRepository(builder.Configuration.GetValue<string>("DefaultConnection")));
builder.Services.AddScoped<IService<Category, CategoryDto>, CategoryService>();*/



builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddScoped<IRepository<Post>, PostRepository>();
builder.Services.AddScoped<IService<Post, PostDto>, PostService>();


builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddScoped<IRepository<Tag>, TagRepository>();
builder.Services.AddScoped<IService<Tag, TagDto>, TagService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IRepository<Category>, CategoryRepository>();
builder.Services.AddScoped<IService<Category, CategoryDto>, CategoryService>();
/*builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<CategoryService>();*/

var app = builder.Build();
app.MapControllers();
app.Run();
