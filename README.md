# ProWebAPI
ASP.NET Core API with all proper standards

### Standards Implemented
| Name | Description
| ------ | ------
| Standard Response | Implementation of a standard response pattern for DTO and internal
| Versioning | Implementation of a standard response pattern for DTO and internal

### Swagger
Install Swagger
```
Swashbuckle.AspNetCore
```
Setup DI
```
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProWebAPI", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProWebAPI v1"));
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
```

### Versioning
Install Nuget library
```nuget
    Microsoft.AspNetCore.Mvc.Versioning
```
Add to dependency container
```
   services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });
```
Decorate the controllers base on the need
```
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        [MapToApiVersion("1.0")]
        [Route("Success")]
        public Response Success()
        {
        }
        
        [HttpGet]
        [MapToApiVersion("2.0")]
        [Route("Success")]
        public Response Success20()
        {
        }

        [HttpGet]
        [Route("Failure")]
        public Response Failure()
        {
        }
    }
```

### Repository Contents
This repo maintains 2 projects. The main library and a demo project to implement it
