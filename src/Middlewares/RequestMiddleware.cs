using System.Security.Cryptography;

namespace AspNetMvcCSP.Middlewares;

public class RequestMiddleware
{
    private readonly RequestDelegate _requestDelegate;

    public RequestMiddleware(RequestDelegate requestDelegate)
    {
        _requestDelegate = requestDelegate;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var nonceBytes = RandomNumberGenerator.GetBytes(32);
        var nonce = Convert.ToBase64String(nonceBytes);

        context.Items["CSP-Nonce"] = nonce;

        var instanceId = Environment.GetEnvironmentVariable("INSTANCE_ID") ?? Environment.MachineName;

        context.Response.OnStarting(() =>
        {
            context.Response.Headers.TryAdd("Content-Security-Policy", $"script-src 'nonce-{nonce}';");
            context.Response.Headers.TryAdd("X-Instance-ID", instanceId);
            return Task.CompletedTask;
        });

        await _requestDelegate(context);
    }
}
