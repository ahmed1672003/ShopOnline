using ShopOnline.API.Specifications.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region Register Services
builder.Services.AddDbContext<ShopOnlineDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("ShopOnlineConnection")));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ISpecification<>), typeof(Specification<>));
builder.Services.AddScoped<IShopOnlineDbContext, ShopOnlineDbContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IResponseHandler, ResponseHandler>();
builder.Services.AddScoped<IResponseHandler, PaginationResponseHandler>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
#endregion

//builder.Services.AddMemoryCache();
builder.Services
           .AddControllers()
           .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddCors(options => options.AddPolicy("ShopOnline", builder =>
{
    builder.AllowAnyHeader();
    builder.AllowAnyMethod();
    builder.AllowAnyMethod();
    builder.AllowAnyOrigin();
}));


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

app.UseHttpsRedirection();

//app.UseCors(policy =>
//{
//    //policy.WithOrigins("https://localhost:7145", "http://localhost:7145");
//    policy.AllowAnyOrigin();
//    policy.AllowAnyMethod();
//    policy.AllowAnyHeader();
//});

app.UseCors("ShopOnline");
app.UseMiddleware<ErrorHandlerMiddleWare>();

app.UseAuthorization();

app.MapControllers();

app.Run();
