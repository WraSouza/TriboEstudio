using TriboEstudio.ViewModel;

namespace TriboEstudio.View;

public partial class LoginView : ContentPage
{
	public LoginView()
	{
		InitializeComponent();

        BindingContext = new LoginViewModel(Navigation);
    }
}