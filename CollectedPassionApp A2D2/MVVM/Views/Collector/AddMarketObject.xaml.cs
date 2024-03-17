using CollectedPassionApp_A2D2.MVVM.ViewModels;
using CollectedPassionApp_A2D2.MVVM.Views.Manager;
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

}