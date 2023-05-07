using System.Reflection;

namespace Avhrm.UI.Source;

public static class Utilities
{
    public static string GetPackageVersion()
    {
        Version version = Assembly.GetExecutingAssembly().GetName().Version;
        return version.ToString();
    }
}
