using System.Threading.Tasks;

namespace examen2;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}
	protected override async void OnAppearing()
	{
		base.OnAppearing();
		var database = new DatabaseService();
		var registros = await database.GetRegistrosAsync();
		lstRegistros.ItemsSource = registros;
	}
	private async void btnAgregar_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new AgregarRegistro());
	}
	private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
	{
		var stack = (StackLayout)sender;
		var registro = (RegistroAmbulancia)stack.BindingContext;
		await Navigation.PushAsync(new VerDetalleRegistro(registro));
	}
}