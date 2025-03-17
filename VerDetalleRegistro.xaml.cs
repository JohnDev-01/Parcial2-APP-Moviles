namespace examen2;

public partial class VerDetalleRegistro : ContentPage
{
	public VerDetalleRegistro(RegistroAmbulancia registro)
	{
		InitializeComponent();
		BindingContext = registro;
		Console.WriteLine("URL ====> " + registro.UrlFoto);
		imagen.Source = ImageSource.FromFile(registro.UrlFoto);
	}
}