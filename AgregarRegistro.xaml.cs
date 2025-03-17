using System.Threading.Tasks;

namespace examen2;

public partial class AgregarRegistro : ContentPage
{
	public AgregarRegistro()
	{
		InitializeComponent();
	}
	string filePath;
	private async void btnAgregarImagen_Clicked(object sender, EventArgs e)
	{
		try
		{
			var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
			{
				Title = "Por favor selecciona una foto"
			});
			var stream = await result.OpenReadAsync();
			string fileName = result.FileName;
			var newFilePath = Path.Combine(FileSystem.AppDataDirectory, fileName);
			using (var newFile = File.OpenWrite(newFilePath))
			{
				await stream.CopyToAsync(newFile);
			}
			filePath = newFilePath;
			imagen.Source = ImageSource.FromFile(filePath);
		}
		catch (Exception ex)
		{
			await DisplayAlert("Error", ex.Message, "OK");
		}
	}
	private async void btnAgregarRegistro_Clicked(object sender, EventArgs e)
	{
		var registro = new RegistroAmbulancia
		{
			Titulo = txtTitulo.Text,
			Descripcion = txtDescripcion.Text,
			Fecha = DateTime.Now,
			UrlFoto = filePath
		};
		var database = new DatabaseService();
		await database.SaveRegistroAsync(registro);
		await Navigation.PopAsync();
	}
}