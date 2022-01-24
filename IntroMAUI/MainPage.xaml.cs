namespace IntroMAUI;

public partial class MainPage : ContentPage
{
    private readonly IDeviceOrientationService deviceOrientationService;
	private int windowNumber;

    public MainPage(IDeviceOrientationService deviceOrientationService)
	{
		InitializeComponent();
        this.deviceOrientationService = deviceOrientationService;
		RefreshTitle();
    }

	public int WindowNumber 
	{ 
		get => windowNumber;
		set
		{ 
			windowNumber = value;
			RefreshTitle();
		} 
	}

	private void RefreshTitle()
	{
		lbTitle.Text = $"This is window {WindowNumber}";
	}

	private void OnShowOrientationClicked(object sender, EventArgs e)
	{
		lbOrientation.Text = deviceOrientationService.GetOrientation().ToString();
	}

	private void OnOpenWindowClicked(object sender, EventArgs e)
	{
		Application.Current.OpenWindow(new Window(new MainPage(deviceOrientationService) { WindowNumber = WindowNumber + 1 }));
	}

	private void OnCloseWindowClicked(object sender, EventArgs e)
	{
		var window = this.GetParentWindow();
		if (window is not null)
			Application.Current.CloseWindow(window);
	}
}

