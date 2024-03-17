using CollectedPassionApp_A2D2.MVVM.Views.Guest;
using CollectedPassionApp_A2D2.MVVM.Views.Manager;
using CollectedPassionApp_A2D2.MVVM.Views.Collector;
using CollectedPassionApp_A2D2.MVVM.Models;
using Microsoft.Maui.ApplicationModel.Communication;
using System.Collections.Generic;
using Microsoft.Maui.Storage;
using CollectedPassionApp_A2D2.MVVM.ViewModels;

namespace CollectedPassionApp_A2D2;

    public partial class LoginPage : ContentPage
    {


    public LoginPage()
    {
        InitializeComponent();

    }
    public void StoreCurrentUserId(int userId)
    {
        Preferences.Set("CurrentUserId", userId);
    }

    private void BTNForgorPassword_Clicked(object sender, EventArgs e)
    {
       
    }

    private void BTNLogin_Clicked(object sender, EventArgs e)
    {
        string usrname = ENTusername.Text;
        string pswrd = ENTPassword.Text;
        
        User user = App.UserRepo.GetEntities().FirstOrDefault(u => u.username == usrname && u.password == pswrd);
        if (user != null)
        {
            App.CurrentUserId = user.Id;
            User currentUser = App.UserRepo.GetEntity(user.Id);
            if (user.role == "manager")
            {
                StoreCurrentUserId(currentUser.Id);
                Navigation.PushAsync(new ManagerMainPage());
            }
            
            else if (user.role == "collector")
            {
                StoreCurrentUserId(currentUser.Id);
                Navigation.PushAsync(new MainPage( ));
            }
        }
        else
        {
            DisplayAlert("Error", "Onjuist E-mailadres of Wachtwoord.", "Ok");
        }
    }

    private void BTNRegister_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ManagerMainPage());
    }


    private void showPasswordSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        ENTPassword.IsPassword = !e.Value;
    }

    private void BTNContinue_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MarketplaceViwe());
    }
}
