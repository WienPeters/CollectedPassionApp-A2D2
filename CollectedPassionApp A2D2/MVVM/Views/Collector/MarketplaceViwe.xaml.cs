using CollectedPassionApp_A2D2.MVVM.Models;
using CollectedPassionApp_A2D2.MVVM.ViewModels;

namespace CollectedPassionApp_A2D2.MVVM.Views.Collector;

public partial class MarketplaceViwe : ContentPage
{
    private readonly MarketViewModel _viewModel;
    public MarketplaceViwe()
	{
		InitializeComponent();
        _viewModel = new MarketViewModel();
        BindingContext = _viewModel;
    }

    private void BTNAddMarketitem_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AddMarketObject());
    }

   
    private async void OnSearchButtonPressed(object sender, EventArgs e)
    {
        var query = Uri.EscapeDataString(SRCHMarketplaceExternal.Text);
        var urlString = $"https://www.lastdodo.nl/nl/marketplace/search?q={query}";
        await Browser.OpenAsync(urlString, BrowserLaunchMode.SystemPreferred);
    }

    private void SWIpedetails_Clicked(object sender, EventArgs e)
    {

    }

    private void DetailsSwipeItem_Clicked(object sender, EventArgs e)
    {

    }

    private void LISTVCollection_ItemAppearing(object sender, ItemVisibilityEventArgs e)
    {

    }

    private void Label_BindingContextChanged(object sender, EventArgs e)
    {
        
    }

    private void Label_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {

    }
}