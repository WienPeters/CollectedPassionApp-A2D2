using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectedPassionApp_A2D2.MVVM.Models;
using Microsoft.Maui.Media;

namespace CollectedPassionApp_A2D2.MVVM.ViewModels
{
    public class MarketingcollectViewModel
    {
        public async Task<Stream> PickOrTakePhotoAsync()
        {


            // Request camera and storage permissions
            var cameraStatus = await Permissions.RequestAsync<Permissions.Camera>();
            var storageStatus = await Permissions.RequestAsync<Permissions.StorageRead>();

            if (cameraStatus != PermissionStatus.Granted || storageStatus != PermissionStatus.Granted)
            {
                // Permissions not granted
                return null;
            }

            // Take a photo or pick from gallery
            FileResult photo = await MediaPicker.PickPhotoAsync() ?? await MediaPicker.CapturePhotoAsync();

            if (photo != null)
            {
                // Open a stream for the selected image
                var stream = await photo.OpenReadAsync();
                return stream;
            }
            return null;
        }
        public async Task<bool> UploadPhotoAsync(Stream photoStream)
        {
            var httpClient = new HttpClient();
            var content = new StreamContent(photoStream);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");

            var response = await httpClient.PostAsync("YourApiUrl/upload", content);
            return response.IsSuccessStatusCode;
        }
        public async Task AddImageToCollectible(Noncollectable collectible, Stream imageStream)
        {
            // Upload the photo or save locally
            var imagePath = await UploadPhotoAsync(imageStream); // Or local saving method

            // Update collectible with the image path
            collectible.ImagePath = imagePath;

            // Update the collectible in your data store
        }




    }
}
