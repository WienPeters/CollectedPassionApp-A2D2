using CollectedPassionApp_A2D2.MVVM.Models;
using CollectedPassionApp_A2D2.MVVM.ViewModels;
using CollectedPassionApp_A2D2.MVVM.Views.Manager;
namespace CollectedPassionApp_A2D2.MVVM.Views.Collector;

public partial class MARKETPLACE2 : ContentPage
{
	private readonly MARKETPLACE2VIEWMODEL _viewModel;
    public MARKETPLACE2()
	{
		InitializeComponent();
        _viewModel = new MARKETPLACE2VIEWMODEL();
        BindingContext = _viewModel;
    }

    private async void SRCHMarketplaceExternal_SearchButtonPressed(object sender, EventArgs e)
    {
        var query = Uri.EscapeDataString(SRCHMarketplaceExternal.Text);
        var urlString = $"https://www.lastdodo.nl/nl/marketplace/search?q={query}";
        await Browser.OpenAsync(urlString, BrowserLaunchMode.SystemPreferred);
    }
}