using CollectedPassionApp_A2D2.Abstractions;
using CollectedPassionApp_A2D2.MVVM.Models;
namespace CollectedPassionApp_A2D2.MVVM.Views.Collector;

public partial class ProfileSetupage : ContentPage
{
	public ProfileSetupage()
	{
		InitializeComponent();
        
    }

    private async void BTNGetLocation_Clicked(object sender, EventArgs e)
    {
        LocationService los = new LocationService();

        string latestAddress = await los.GetLocationAddressAsync();
        if (latestAddress != null)
        {
            LBLocatie.Text = latestAddress;
            string[] parts = latestAddress.Split(',');
            string hsnr = parts[0]; string strnm = parts[1]; string std = parts[4]; string prvnc = parts[5]; string lnd = parts[6]; string pstcd = parts[7];
            string adres = (strnm + " " + hsnr + " " + pstcd + " " + std);
            string stadregioland = (std + " " + prvnc + " " + lnd);
            ENTAdres.Text = adres;
            ENTNaamstad.Text = stadregioland;
        }
    }

    private void BTNSaveprofilechange_Clicked(object sender, EventArgs e)
    {
        Appuser aos = new Appuser()
        {
            Id = App.CurrentUserId,
            username = ENTUserName.Text,
            email = ENTEmail.Text,
            password = ENTPassword.Text,
            adres = ENTAdres.Text,
            city = ENTNaamstad.Text
        };
        App.UserRepo.UpdateEntityWithChildren(aos);
        DisplayAlert("Succes", "You have edited your profile", "well done");
        App.UserRepo.GetEntitiesWithChildren();
        
    }
}