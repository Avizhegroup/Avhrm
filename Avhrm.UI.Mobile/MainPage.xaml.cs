using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.Maui.Controls.PlatformConfiguration;

namespace Avhrm.UI.Mobile;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        BlazorWebViewHandler.BlazorWebViewMapper.AppendToMapping("CustomBlazorWebViewMapper", (handler, view) =>
        {
#if IOS
            handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
            handler.PlatformView.Opaque = false;
#endif

#if ANDROID
        Android.Webkit.WebSettings settings = handler.PlatformView.Settings;

        settings.AllowFileAccessFromFileURLs =
            settings.AllowUniversalAccessFromFileURLs =
            settings.AllowContentAccess =
            settings.AllowFileAccess =
            settings.DatabaseEnabled =
            settings.JavaScriptCanOpenWindowsAutomatically =
            settings.DomStorageEnabled = true;

#if DEBUG
        settings.MixedContentMode = Android.Webkit.MixedContentHandling.AlwaysAllow;
#endif

        settings.BlockNetworkLoads =
            settings.BlockNetworkImage = false;
#endif
        });
    }
}