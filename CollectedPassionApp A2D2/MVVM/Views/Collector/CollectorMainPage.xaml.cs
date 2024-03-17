namespace CollectedPassionApp_A2D2.MVVM.Views.Collector;

public partial class CollectorMainPage : ContentPage
{
	public CollectorMainPage()
	{
		InitializeComponent();
	}

    private void BTNManagecollectibles_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CollectiblesPage());
    }
}