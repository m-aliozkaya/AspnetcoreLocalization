using System.Reflection;
using Microsoft.Extensions.Localization;

namespace RazorPagesExample.Localization;

public class SharedViewLocalizer : ISharedViewLocalizer
{
    private readonly IStringLocalizer _localizer;

    public SharedViewLocalizer(IStringLocalizerFactory factory)
    {
        var type = typeof(SharedResource);
        var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
        _localizer = factory.Create("SharedResource", assemblyName.Name);
    }

    public LocalizedString this[string key] => _localizer[key];

    public LocalizedString GetLocalizedString(string key)
    {
        return _localizer[key];
    }
}