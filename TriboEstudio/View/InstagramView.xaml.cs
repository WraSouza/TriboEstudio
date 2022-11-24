namespace TriboEstudio.View;

public partial class InstagramView : ContentPage
{
	public InstagramView()
	{
		InitializeComponent();

		navegador.Source = " https://www.instagram.com/tribopersonalestudio/";

    }

    private void carregandoPagina(object sender, WebNavigatingEventArgs e)
    {
        lblStatus.Text = "Carregando Página...";
    }

    private void paginaCarregada(object sender, WebNavigatedEventArgs e)
    {
        lblStatus.Text = "Pronto";
    }
}