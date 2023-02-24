using Microsoft.AspNetCore.Localization;

namespace RazorPagesExample;

public class MyCustomRequestCultureProvider : RequestCultureProvider
{
    public override async Task<ProviderCultureResult?> DetermineProviderCultureResult (HttpContext httpContext)
    {
        await Task.Yield();
        return new ProviderCultureResult("tr");
    }
}