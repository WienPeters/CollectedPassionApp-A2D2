using CollectedPassionApp_A2D2.MVVM.Models;
using CollectedPassionApp_A2D2.MVVM.ViewModels;
using CollectedPassionApp_A2D2.MVVM.Views.Manager;
using CollectedPassionApp_A2D2.Abstractions;
namespace CollectedPassionApp_A2D2.MVVM.Views.Collector;


public partial class AddMarketObject : ContentPage
{
    private readonly MarketingcollectViewModel _viewModel;
    public AddMarketObject()
	{
		InitializeComponent();
        _viewModel = new MarketingcollectViewModel();
        BindingContext = _viewModel;
        
    }
    
    private void BTNAddCat_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CategoryManagepage());
    }

    private void BTNGoToMarket_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MarketplaceViwe());
    }

    private async void BTNLocation_Clicked(object sender, EventArgs e)
    {
        LocationService los = new LocationService();
        string latestAddress = await los.GetLocationAddressAsync();
        if (latestAddress != null)
        {
            //LBLocatie.Text = latestAddress;
            string[] parts = latestAddress.Split(',');
            string hsnr = parts[0]; string strnm = parts[1]; string std = parts[4]; string prvnc = parts[5]; string lnd = parts[6]; string pstcd = parts[7];
            string adres = (strnm + " " + hsnr + " " + pstcd + " " + std);
            string stadregioland = (std + " " + prvnc + " " + lnd);
            //ENTAdres.Text = adres;
            ENTLocation.Text = stadregioland;
        }
        //string loca = _viewModel.getlocation();
        // = loca.ToString();
    }
}