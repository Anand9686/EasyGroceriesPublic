using Common.Logging;
using External.Authentication.Twilio;
using GroceryWebApp.MiddleWare;
using GroceryWebApp.Pages.Basket.Services;
using GroceryWebApp.Pages.Categories.Services;
using GroceryWebApp.Pages.Login.Services;
using GroceryWebApp.Pages.Products.Services;
using GroceryWebApp.Pages.Utils.Services;
using GroceryWebApp.Pages.Vendor.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Polly;
using Polly.Extensions.Http;
using Serilog;
using System;
using System.Net;
using System.Net.Http;
using System.Text;

namespace GroceryWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                //.WriteTo.MySQL("server=localhost;database=Logging;User=root;password=MySQL@0007;","Log",Serilog.Events.LogEventLevel.Verbose)
                .CreateLogger();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddTransient<LoggingDelegatingHandler>();

            services.AddSingleton<IConfiguration>(Configuration);

            services.AddHttpClient<IProductService, ProductService>(c =>
               c.BaseAddress = new Uri(Configuration["ProductApiSettings:GatewayAddress"]))
               .AddHttpMessageHandler<LoggingDelegatingHandler>()
               .AddPolicyHandler(GetRetryPolicy())
               .AddPolicyHandler(GetCircuitBreakerPolicy());

            services.AddHttpClient<ICategoryService, CategoryService>(c =>
               c.BaseAddress = new Uri(Configuration["CategoryApiSettings:GatewayAddress"]))
               .AddHttpMessageHandler<LoggingDelegatingHandler>()
               .AddPolicyHandler(GetRetryPolicy())
               .AddPolicyHandler(GetCircuitBreakerPolicy());

            services.AddHttpClient<IBasketService, BasketService>(c =>
               c.BaseAddress = new Uri(Configuration["BasketApiSettings:GatewayAddress"]))
               .AddHttpMessageHandler<LoggingDelegatingHandler>()
               .AddPolicyHandler(GetRetryPolicy())
               .AddPolicyHandler(GetCircuitBreakerPolicy());

            services.AddHttpClient<IVendorService, VendorService>(c =>
              c.BaseAddress = new Uri(Configuration["VendorApiSettings:GatewayAddress"]))
              .AddHttpMessageHandler<LoggingDelegatingHandler>()
              .AddPolicyHandler(GetRetryPolicy())
              .AddPolicyHandler(GetCircuitBreakerPolicy());

            services.AddHttpClient<IUtilsService, UtilsServices>(c =>
             c.BaseAddress = new Uri(Configuration["UtilsApiSettings:GatewayAddress"]))
             .AddHttpMessageHandler<LoggingDelegatingHandler>()
             .AddPolicyHandler(GetRetryPolicy())
             .AddPolicyHandler(GetCircuitBreakerPolicy());

            services.AddHttpClient<ILoginService, LoginService>(c =>
             c.BaseAddress = new Uri(Configuration["LoginApiSettings:GatewayAddress"]))
             .AddHttpMessageHandler<LoggingDelegatingHandler>()
             .AddPolicyHandler(GetRetryPolicy())
             .AddPolicyHandler(GetCircuitBreakerPolicy());

           

            //services.Configure<IdentityOptions>(options =>
            //{
            //    options.Lockout.MaxFailedAccessAttempts = 5;
            //    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
            //});

            // Add application services.
            // services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            services.Configure<SMSoptions>(Configuration);

            //services.AddMvc().AddRazorPagesOptions(o =>
            //{
            //    o.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute());
            //});

            services.AddRazorPages();
            services.AddMvc().AddJsonOptions(options => {
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                options.JsonSerializerOptions.DictionaryKeyPolicy = null;
            });


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true
                };
            });
             ////.AddCookie(options =>
             ////{
             ////    options.LoginPath = "/Pages/Login/UI/Login";
             ////    options.LogoutPath = "/Pages/Login/UI/LogOut";
             ////}); ;

            services.AddAuthorization();
            //SecurityProtocolType.Ssl3 | 
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            services.AddSession();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //var sms = new External.Authentication.Twilio.SMSoptions();
            //TwilioClient.Init(sms.SMSAccountIdentification, sms.SMSAccountPassword);

            //var message = MessageResource.Create(
            //    body: "SMS From Twilio - for development",
            //    from: new Twilio.Types.PhoneNumber("+919483941729"),
            //    to: new Twilio.Types.PhoneNumber("+919449058824")
            //);

            //Step 1 - Create Verification Service
            //var service = ServiceResource.Create(friendlyName: "My First Verify Service");
            //Console.WriteLine(service.Sid);

            // Console.WriteLine(message.Sid);
            //Step 2 -- Send Verification token
            //var verification = VerificationResource.Create(
            //to: "+919483941729",
            //channel: "sms",
            //pathServiceSid: "VAbc532eb7b10920d2b5249d10d3b1398b");

            //Console.WriteLine(verification.Status);

            //Step - 3
            //    var verificationCheck = VerificationCheckResource.Create(
            //    to: "+919483941729",
            //    code: "523461",
            //    pathServiceSid: "VAbc532eb7b10920d2b5249d10d3b1398b"
            //);

            //    Console.WriteLine(verificationCheck.Status);


        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GroceryWebApp v1"));
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //app.MapControllerRoute( name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
            app.UseJwtCookie();

            app.UseRouting();
            app.UseAuthentication();
            app.UseStatusCodePages(context =>
            {
                var response = context.HttpContext.Response;

                if (response.StatusCode == (int)HttpStatusCode.Unauthorized ||
                        response.StatusCode == (int)HttpStatusCode.Forbidden)
                    response.Redirect("../../Login/UI/Login");
                return System.Threading.Tasks.Task.CompletedTask;
            });
            app.UseAuthorization();
            //app.MapRazorPages();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller}/{action}/{id?}");

            });
        }
        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            // In this case will wait for
            //  2 ^ 1 = 2 seconds then
            //  2 ^ 2 = 4 seconds then
            //  2 ^ 3 = 8 seconds then
            //  2 ^ 4 = 16 seconds then
            //  2 ^ 5 = 32 seconds

            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(
                    retryCount: 5,
                    sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    onRetry: (exception, retryCount, context) =>
                    {
                        Log.Error($"Retry {retryCount} of {context.PolicyKey} at {context.OperationKey}, due to: {exception}.");
                    });
        }

        private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(
                    handledEventsAllowedBeforeBreaking: 5,
                    durationOfBreak: TimeSpan.FromSeconds(30)
                );
        }
    }
}
