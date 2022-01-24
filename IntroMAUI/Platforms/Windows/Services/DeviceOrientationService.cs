namespace IntroMAUI.Services;

public class DeviceOrientationService : IDeviceOrientationService
{
    public DeviceOrientation GetOrientation()
    {
        return DeviceOrientation.Landscape;
    }
}
