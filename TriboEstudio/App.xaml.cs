namespace TriboEstudio;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage ( new View.LoginView() );
	}
}
