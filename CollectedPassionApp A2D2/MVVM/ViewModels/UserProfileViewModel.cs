using CollectedPassionApp_A2D2.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectedPassionApp_A2D2.MVVM.ViewModels
{
    public class UserProfileViewModel : BaseViewModel
    {
        public async Task LoadUserProfile()
        {
            var userId = await SessionManager.GetLoggedInUserIdAsync();
            if (!string.IsNullOrEmpty(userId))
            {
                await SessionManager.SetLoggedInUserIdAsync(userId);
            }
        }
    }
}
