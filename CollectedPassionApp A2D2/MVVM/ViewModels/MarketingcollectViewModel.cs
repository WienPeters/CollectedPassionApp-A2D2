﻿using CollectedPassionApp_A2D2.MVVM.Models;
using CollectedPassionApp_A2D2.MVVM.Views.Collector;
using CollectedPassionApp_A2D2.Abstractions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using Microsoft.Maui.Controls.PlatformConfiguration;

namespace CollectedPassionApp_A2D2.MVVM.ViewModels
{
    public class MarketingcollectViewModel : INotifyPropertyChanged
    {

        #region variables
       
        private List<Category> _categories;
        public List<Category> Categories
        {
            get { return App.CategoRepo.GetEntitiesWithChildren(); }
            set
            {
                if (_categories != value)
                {
                    _categories = value;
                    OnPropertyChanged(nameof(Categories));
                }
            }
        }
        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                if (_username != value)
                {
                    Appuser userman = App.UserRepo.GetEntity(App.CurrentUserId);
                    _username = userman.username = value;
                    ////_username = value;
                    OnPropertyChanged(nameof(Username));
                }
            }
        }
        private Collectable _selecollectable;
        public Collectable SelectedCollectable
        {
            get { return _selecollectable; }
            set
            {
                if (_selecollectable != value)
                {
                    _selecollectable = value;
                    OnPropertyChanged(nameof(SelectedCollectable));
                    // Optionally, filter collectibles by selected category
                }
            }
        }
        
        private Category _selectedCategory;
        public Category SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                if (_selectedCategory != value)
                {
                    _selectedCategory = value;
                    OnPropertyChanged(nameof(SelectedCategory));
                    // Optionally, filter collectibles by selected category
                }
            }
        }
        private List<Collectable> _collectibles;
        public List<Collectable> Collectables
        {
            get => Collectables;
            set
            {
                if (_collectibles != value)
                {
                    _collectibles = value;
                    OnPropertyChanged(nameof(Collectables));
                }
            }
        }
        private string _catname;
        public string Catname
        {
            get { return _catname; }
            set
            {
                if (_catname != value)
                {
                    Category cat = new Category();
                    _catname = cat.Catname;
                    int _catint = cat.Id;
                    OnPropertyChanged(nameof(Catname));
                }
            }
        }
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }
        private double _price;
        public double Price
        {
            get => _price;
            set
            {
                if (value != _price)
                {
                    _price = value;
                    OnPropertyChanged(nameof(Price));
                }
            }
        }
        private bool _tradable;
        public bool Tradable
        {
            get => _tradable;
            set
            {
                if (value != _tradable)
                {
                    _tradable = value;
                    OnPropertyChanged(nameof(Tradable));
                }
            }
        }
        private string _location;
        public string GPSLocation
        {
            get => _location;
            set
            {
                if (value != _location)
                {
                    //_location =  getlocation();
                    _location = value;
                    OnPropertyChanged(nameof(GPSLocation));
                }
            }
        }
        private string _imagepath;
        public string ImagePath
        {
            get => _imagepath;
            set
            {
                if (value != _imagepath)
                {
                    _imagepath = value;
                    OnPropertyChanged(nameof(ImagePath));

                }
            }
        }
        private List<Collectable4Sale> _noncollectibles;
        public List<Collectable4Sale> Noncollectables
        {
            get => Noncollectables;
            set
            {
                if (_noncollectibles != value)
                {
                    _noncollectibles = value;
                    OnPropertyChanged(nameof(Noncollectables));
                }
            }
        }
        private bool _tradeable;
        public bool Tradeable
        {

            get => _tradeable;
            set
            {
                if (_tradeable != value)
                {
                    _tradeable = value;
                    
                    OnPropertyChanged(nameof(Tradeable));
                }
            }
        }
        

        #endregion 
        public ObservableCollection<Collectable> Itemz { get; set; } = new ObservableCollection<Collectable>();
        public ObservableCollection<Collectable4Sale> Items { get; set; } = new ObservableCollection<Collectable4Sale>();
        public List<Collectable4Sale> dingen { get; set; } = new List<Collectable4Sale> { };
        

        public ICommand AddNonCollectibleCommand { get; private set; }
        public ICommand ItsTradableCommand { get; set; }
        public ICommand TakePhotoCommand { get; }
        public ICommand PickPhotoCommand { get; }



        public MarketingcollectViewModel()
        {
            //LoadCategory();
            //GetCategoryANonCollectables();
            //Getllectables();
            TakePhotoCommand = new Command(async () => await TakePhotoAsync());
            PickPhotoCommand = new Command(async () =>
            {
                var photoPath = await PickPhotoAsync();
                if (!string.IsNullOrEmpty(photoPath))
                {
                    ImagePath = photoPath;
                }
            });
            
            AddNonCollectibleCommand = new Command(async () =>
                {
                    Collectable4Sale nollectable = new Collectable4Sale()
                    {
                        Name = Name,
                        Description = Description,
                        price = Price,
                        tradeable = Tradeable , 
                        imagepath = ImagePath,
                        locatie = GPSLocation,
                        categoryId = this.SelectedCategory.Id,
                        userId = App.CurrentUserId
                    };
                    App.Market.SaveEntityWithChildren(nollectable);
                    Items.Add(nollectable);
                    dingen.Add(nollectable);
                    //Appuser user = new Appuser(); user.Collecta4bles.Add(nollectable);
                    //App.CategoRepo.UpdateEntityWithChildren(SelectedCategory);
                    //App.UserRepo.UpdateEntityWithChildren(user);




                });
        }
        public void CreateObjectWithTrueAttribute()
        {
            // Create your object here or perform any other action
            // For example:
            Collectable4Sale newObj = new Collectable4Sale();
            newObj.tradeable = true;
            // Optionally, perform additional operations with the created object
        }
        private void LoadCategory()
        {
            Categories = App.CategoRepo.GetEntitiesWithChildren();
            var dwingen = App.Market.GetEntitiesWithChildren();
            foreach(Collectable4Sale item in dwingen)
            {
                dingen.Add(item);
            }
        }
        public async Task<string> getlocation()
        {
            LocationService los = new LocationService();
            string latestAddress = await los.GetLocationAddressAsync();
            if (latestAddress != null)
            {
                string[] parts = latestAddress.Split(',');
                string hsnr = parts[0]; string strnm = parts[1]; string std = parts[4]; string prvnc = parts[5]; string lnd = parts[6]; string pstcd = parts[7];
                string adres = (strnm + " " + hsnr + " " + pstcd + " " + std);
                string stadregioland = (std + " " + prvnc + " " + lnd);
                return  ( stadregioland);
            }
            else { return null; }
        }
        private void GetCategoryANonCollectables()
        {
            
            Itemz.Clear();
            List<Collectable> coleti = App.CollectionRepo.GetEntities();
            foreach (Collectable collectable in coleti)
            {
                Itemz.Add(collectable);
            }
            
        }
        private void Getllectables()
        {
            Items.Clear();
            List<Collectable4Sale> noni = App.Market.GetEntities();
            foreach (Collectable4Sale nollectable in noni)
            {
                Items.Add(nollectable);
            }
        }

        public async Task<string> PickPhotoAsync()
        {
            try
            {
                var photo = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
                {
                    Title = "Please pick a photo"
                });

                if (photo != null)
                {
                    var photoPath = await SaveFileAsync(photo);
                    return photoPath; // SaveFileAsync is the same method used in the TakePhotoAsync
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"PickPhotoAsync error: {ex.Message}");
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
        public async Task<string> TakePhotoAsync()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.Camera>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.Camera>();
            }

            // Make sure to re-check the permission status after the request
            if (status == PermissionStatus.Granted)
            {
                // Permission has been granted, proceed with taking a picture
                var photo = await MediaPicker.CapturePhotoAsync();
                if (photo != null)
                {
                    try
                    {
                        // Save the photo to the app's local storage
                        var photoPath = await SaveFileAsync(photo);
                        ImagePath = photoPath;
                        return photoPath;
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions
                        Debug.WriteLine($"TakePhotoAsync error: {ex.Message}");
                    }

                }
                else
                {
                    // Permission was denied or not granted, handle this case appropriately
                    Debug.WriteLine("Camera permission was not granted.");
                }
                // Process the photo as needed
            }  
            return null;
        }
        public async Task<string> SaveFileAsync2(FileResult photo)
        {
            var newFilePath = Path.Combine(FileSystem.AppDataDirectory, photo.FileName);
            using (var stream = await photo.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFilePath))
            {
                await stream.CopyToAsync(newStream);
            }
            return newFilePath;
        }
        public async Task<string> SaveFileAsync(FileResult photo)
        {
            // Define the folder path where the photo will be saved
            // This uses the app's local data directory
            string folderPath = FileSystem.AppDataDirectory;

            // Create a unique file name for the photo to avoid overwriting existing files
            string fileName = $"photo_{DateTime.Now:yyyyMMdd_HHmmss}.jpg";
            string filePath = Path.Combine(folderPath, fileName);
            // Open a stream for the selected photo
            using (var stream = await photo.OpenReadAsync())
            {
                // Create a new file and write the photo stream into it
                using (var newFile = File.OpenWrite(filePath))
                {
                    await stream.CopyToAsync(newFile);
                }
            }

            // Return the file path of the saved photo
            return filePath;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
