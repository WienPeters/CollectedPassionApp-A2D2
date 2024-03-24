using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;


namespace CollectedPassionApp_A2D2.MVVM.Models
{
    public static class SessionManager
    {

        private const string UserIdKey = "UserID";

        public static async Task SetLoggedInUserIdAsync(string userId)
        {
            await SecureStorage.SetAsync(UserIdKey, userId);
        }

        public static async Task<string> GetLoggedInUserIdAsync()
        {
            var userId = await SecureStorage.GetAsync(UserIdKey);
            return userId;
        }
    }
}
