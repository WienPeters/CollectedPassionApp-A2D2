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
}