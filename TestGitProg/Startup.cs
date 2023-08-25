﻿namespace TestGitProg
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    var viewPath = Path.Combine(Directory.GetCurrentDirectory(), "index.html");
                    var html = await File.ReadAllTextAsync(viewPath);
                    await context.Response.WriteAsync(html);
                });
                endpoints.MapGet("/index.css", async context =>
                {
                    // по аналогии со страницей Index настроим на нашем сервере путь до страницы со стилями, чтобы браузер знал, откуда их загружать
                    var cssPath = Path.Combine(Directory.GetCurrentDirectory(), "index.css");
                    var css = await File.ReadAllTextAsync(cssPath);
                    await context.Response.WriteAsync(css);
                });
            });
        }
    }
}
