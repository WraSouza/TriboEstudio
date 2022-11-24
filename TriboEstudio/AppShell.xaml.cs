using TriboEstudio.View;

namespace TriboEstudio;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(InstagramView), typeof(InstagramView));
    }
}
