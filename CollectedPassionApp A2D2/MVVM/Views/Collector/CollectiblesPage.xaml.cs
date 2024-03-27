using CollectedPassionApp_A2D2.MVVM.Models;
using CollectedPassionApp_A2D2.MVVM.ViewModels;
using CollectedPassionApp_A2D2.Repositories;
using System.Linq;

namespace CollectedPassionApp_A2D2.MVVM.Views.Collector;

public partial class CollectiblesPage : ContentPage
{
    private readonly CollectiblesViewModel _viewModel;

    public CollectiblesPage()
	{
		InitializeComponent();
        _viewModel = new CollectiblesViewModel();
        BindingContext = _viewModel;
    }

    private void BTNSellOnMarketplace_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AddMarketObject());
    }

    private void BTNCategorypage_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CategoryManagepage());
    }
}