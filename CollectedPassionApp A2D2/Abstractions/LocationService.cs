using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Maui.Devices.Sensors;
using System.Globalization;
using CollectedPassionApp_A2D2.MVVM.Views.Guest;

namespace CollectedPassionApp_A2D2.Abstractions
{
    // Locatie met d.m.v. LocationIQAPI aldaniet APIKEY van coordinaten naar locatie omzetten.
    public class LocationService 
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private const string LocationIQToken = "pk.e0f983ed8e2d0ee34f8d6ee6d434a96e";
        private int _latestRequestID = 0;
        public async Task<string> GetLocationAddressAsync()
        {
            int thisRequestID = ++_latestRequestID;
            var location = await GetCurrentLocationAsync();
            if (location != null && thisRequestID == _latestRequestID)
            {
                var address = await GetAddressFromCoordinatesAsync(location.Latitude, location.Longitude);
                if (thisRequestID == _latestRequestID)
                {
                    return address;
                }
            }

            return null;
        }
        public async Task<string> GetAddressFromCoordinatesAsync(double latitude, double longitude)
        {
            string requestUrl = $"https://us1.locationiq.com/v1/reverse.php?key={LocationIQToken}&lat={latitude.ToString(CultureInfo.InvariantCulture)}&lon={longitude.ToString(CultureInfo.InvariantCulture)}&format=json";

            try
            {
                var response = await _httpClient.GetAsync(requestUrl);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var locationIQResponse = JsonConvert.DeserializeObject<LocationIQResponse>(json);
                    return locationIQResponse?.display_name;
                }
                else
                {
                    return "Unable to fetch address";
                }
            }
            catch (Exception ex)
            {

                return $"Error fetching address: {ex.Message}";
            }
        }

        private class LocationIQResponse
        {
            public string display_name { get; set; }
        }
        public async Task<Location> GetCurrentLocationAsync()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);
                return location;
            }
            catch (Exception ex)
            {

                string ca = $"Error obtaining location: {ex}";
                return null;
            }
        }
        public async Task<string> GetFormattedLocationAsync()
        {
            var location = await GetCurrentLocationAsync();
            if (location != null)
            {
                string latitude = location.Latitude.ToString(CultureInfo.InvariantCulture);
                string longitude = location.Longitude.ToString(CultureInfo.InvariantCulture);
                return latitude + longitude;
            }
            else
            {
                return "Location unavailable.";
            }
        }
    }

}

