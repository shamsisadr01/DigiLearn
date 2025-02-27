using BlogModule;
using CommentModule;
using Common.L2.Application.FileUtil.Interfaces;
using Common.L2.Application.FileUtil.Services;
using CoreModule.Config;
using DigiLearn.Infrastructure;
using DigiLearn.Infrastructure.JwtUtil;
using TicketModule;
using UserModule.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

builder.Services.AddScoped<IFileService, LocalFileService>();
builder.Services.AddScoped<IFtpFileService, FtpFileService>();
builder.Services.AddTransient<TeacherActionFilter>();

builder.Services.InitUserModule(builder.Configuration)
    .InitTicketModule(builder.Configuration)
    .InitCoreModule(builder.Configuration)
    .InitBlogModule(builder.Configuration)
    .InitCommentModule(builder.Configuration)
    .RegisterDependency();

builder.Services.AddJwtAuthentication(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.Use(async (context, next) =>
{
    var token = context.Request.Cookies["digi-token"]?.ToString();
    if (string.IsNullOrWhiteSpace(token) == false)
    {
        context.Request.Headers.Append("Authorization", $"Bearer {token}");
    }
    await next();
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapDefaultControllerRoute();

app.Run();
