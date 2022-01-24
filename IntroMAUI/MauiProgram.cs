#if ANDROID
using Android.Content.Res;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
#endif
using Microsoft.Maui.Platform;

namespace IntroMAUI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddSingleton<IDeviceOrientationService, UniqueDeviceOrientationService>();
		//builder.Services.AddSingleton<IDeviceOrientationService, DeviceOrientationService>();
		builder.Services.AddTransient<MainPage>();

		CreateHandlers();

		return builder.Build();
	}

	private static void CreateHandlers()
	{
		Microsoft.Maui.Handlers.EntryHandler.EntryMapper.AppendToMapping(nameof(IView.Background), (handler, view) =>
		{
			if (view is CustomEntry)
			{
#if ANDROID
				handler.NativeView.SetBackgroundColor(Colors.Red.ToAndroid());
#elif IOS
                  handler.NativeView.BackgroundColor = Colors.Red.ToNative();
                  handler.NativeView.BorderStyle = UIKit.UITextBorderStyle.Line;
#elif WINDOWS
                  handler.NativeView.Background = Colors.Red.ToNative();
#endif
			}
		});
	}
}
