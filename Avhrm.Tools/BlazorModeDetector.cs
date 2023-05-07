
namespace Avhrm.Tools;

public class BlazorModeDetector
{
    public static BlazorModeDetector Current { get; set; } = new BlazorModeDetector();

    public virtual bool IsBlazorServer()
    {
        return Mode == BlazorMode.BlazorServer;
    }

    public virtual bool IsBlazorHybrid()
    {
        return Mode == BlazorMode.BlazorHybrid;
    }

    public virtual BlazorMode Mode
    {
        get
        {
#if BlazorServer
            return BlazorMode.BlazorServer;
#elif BlazorHybrid
            return BlazorMode.BlazorServer;
#endif
        }
    }
}

public enum BlazorMode
{
    BlazorServer = 0,
    BlazorHybrid = 1,
}
