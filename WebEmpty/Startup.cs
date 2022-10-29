namespace WebEmpty
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsDevelopment())
            {
                app.UseHsts();
                // app.UseExceptionHandler("/Error");
            }
            //else
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            app.UseRouting(); // start endpoint routing

            app.UseHttpsRedirection();

            // use static files middleware and default files middleware

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapGet("/hello", () => "Hello Coding Factory");
                
            });
        }
    }
}
