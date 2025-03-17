namespace examen2;

public partial class Presentacion : ContentPage
{
	public Presentacion()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
			await imgAmbulancia.FadeTo(1,1000);
			await imgAmbulancia.FadeTo(0,1000);
			await imgAmbulancia.FadeTo(1,1000);
			await imgAmbulancia.FadeTo(0,1000);
			await imgAmbulancia.FadeTo(1,1000);
			Application.Current.MainPage = new NavigationPage(new HomePage());
    }
}