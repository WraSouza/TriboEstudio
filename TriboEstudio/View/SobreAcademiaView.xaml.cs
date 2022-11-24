using TriboEstudio.ViewModel;

namespace TriboEstudio.View;

public partial class SobreAcademiaView : ContentPage
{
	public SobreAcademiaView()
	{
		InitializeComponent();

        BindingContext = new SobreAcademiaViewModel(Navigation);
    }
}