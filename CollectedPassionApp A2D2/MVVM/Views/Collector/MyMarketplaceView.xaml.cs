using CollectedPassionApp_A2D2.MVVM.Models;
using CollectedPassionApp_A2D2.MVVM.ViewModels;

namespace CollectedPassionApp_A2D2.MVVM.Views.Collector;

public partial class MyMarketplaceView : ContentPage
{
    private readonly MarketViewModel _viewModel;
    public MyMarketplaceView()
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
        
    }
}