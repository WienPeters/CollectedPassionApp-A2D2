using Microsoft.Maui.ApplicationModel.Communication;
using CollectedPassionApp_A2D2.MVVM.Models;
namespace CollectedPassionApp_A2D2.MVVM.Views.Guest;

public partial class CreateUserPage : ContentPage
{
	public CreateUserPage()
	{
		InitializeComponent();
	}

    private async void BTNRegister_Clicked(object sender, EventArgs e)
    {
		string username = ENTUserName.Text;
        string email = ENTEmail.Text;
        string password = ENTPassword.Text;


        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            await DisplayAlert("Fout", "Alle velden moeten ingevuld worden.", "Ok");
        }
        else
        {
            User collector = new User() { username = username, email = email, password = password, role = "collector" };
            App.UserRepo.SaveEntity(collector);
            await DisplayAlert("Melding", "Account is aangemaakt.", "Ga naar login pagina");
            await Navigation.PushAsync(new LoginPage());
        }
    }
}