using Microsoft.Maui.ApplicationModel.Communication;
using System.Collections.Generic;
using Microsoft.Maui.Storage;
using CollectedPassionApp_A2D2.MVVM.ViewModels;
using CollectedPassionApp_A2D2.MVVM.Views.Guest;
using CollectedPassionApp_A2D2.MVVM.Views.Manager;
using CollectedPassionApp_A2D2.MVVM.Views.Collector;
using CollectedPassionApp_A2D2.MVVM.Models;

namespace CollectedPassionApp_A2D2;

    public partial class LoginPage : ContentPage
    {


    public LoginPage()
    {
        InitializeComponent();

    }
   

    private void BTNForgorPassword_Clicked(object sender, EventArgs e)
    {
       
    }

    private void BTNLogin_Clicked(object sender, EventArgs e)
    {
        string username = ENTusername.Text;
        string password = ENTPassword.Text;
        
        Appuser user = App.UserRepo.GetEntities().FirstOrDefault(u => u.username == username && u.password == password);
        if (user != null)
        {
            
            App.CurrentUserId = user.Id;
            if (user.role == "manager")
            {
            
                Navigation.PushAsync(new ManagerMainPage());
            }
            
            else if (user.role == "collector")
            {
              
                Navigation.PushAsync(new CollectorMainPage( ));
            }
        }
        else
        {
            DisplayAlert("Error", "Onjuist E-mailadres of Wachtwoord.", "Ok");
        }
    }

    private void BTNRegister_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CreateUserPage());
    }


    private void showPasswordSwitch_Toggled(object sender, ToggledEventArgs e)
    {
       
        ENTPassword.IsPassword = !e.Value;
    }

    private void BTNContinue_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CollectorMainPage());
    }

    
}
