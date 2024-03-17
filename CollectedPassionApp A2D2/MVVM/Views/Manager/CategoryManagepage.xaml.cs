using CollectedPassionApp_A2D2.MVVM.Models;
using CollectedPassionApp_A2D2.MVVM.ViewModels;
using CollectedPassionApp_A2D2.Repositories;

namespace CollectedPassionApp_A2D2.MVVM.Views.Manager;

public partial class CategoryManagepage : ContentPage
{
	private readonly CategoryManageViewModel _viewModel;
	public CategoryManagepage()
	{
		InitializeComponent();

		_viewModel = new CategoryManageViewModel();
		BindingContext = _viewModel;
        
        
    }

    
}