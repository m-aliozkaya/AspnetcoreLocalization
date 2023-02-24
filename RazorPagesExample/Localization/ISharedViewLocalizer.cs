using Microsoft.Extensions.Localization;

namespace RazorPagesExample.Localization;

public interface ISharedViewLocalizer
{
    public LocalizedString this[string key]
    {
        get;
    }

    LocalizedString GetLocalizedString(string key);
}