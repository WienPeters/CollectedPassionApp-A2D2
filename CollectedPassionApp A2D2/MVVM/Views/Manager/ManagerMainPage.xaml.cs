using CollectedPassionApp_A2D2.MVVM.ViewModels;
using CollectedPassionApp_A2D2.MVVM.Views.Manager;
namespace CollectedPassionApp_A2D2.MVVM.Views.Manager;

public partial class ManagerMainPage : ContentPage
{
	public ManagerMainPage()
	{
		InitializeComponent();
	}

    private void BTNManagecategories_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CategoryManagepage());
    }

    private void BTNManagecollectibles_Clicked(object sender, EventArgs e)
    {

    }
}