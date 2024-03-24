using CollectedPassionApp_A2D2.Abstractions;
using CollectedPassionApp_A2D2.MVVM.Models;
using CollectedPassionApp_A2D2.Repositories;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;


namespace CollectedPassionApp_A2D2.MVVM.ViewModels
{
    class MarketViewModel : INotifyPropertyChanged
    {
        private readonly LocationService _locationService = new LocationService();
        public string Address { get; private set; }
        private List<Category> _categories;
        public List<Category> Categories
        {
            get { return _categories; }
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
                    //_username = value;
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
        private string _catname;
        public string Catname
        {
            get => _catname;
            set
            {
                if (_catname != value)
                {
                    _catname = value;
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
        private Collectable4Sale _category;
        public Collectable4Sale Category
        {
            get => _category;
            set
            {
                if ( Category != value)
                {
                     Category = value;
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
        public ObservableCollection<Collectable4Sale> Items { get; set; } = new ObservableCollection<Collectable4Sale>();
        public ObservableCollection<Collectable4Sale> FilteredItems { get; set; } = new ObservableCollection<Collectable4Sale>();
        private string selectedCategory;
        public string SelectedCategory
        {
            get => selectedCategory;
            set
            {
                if (selectedCategory != value)
                {
                    selectedCategory = value;
                    OnPropertyChanged(nameof(SelectedCategory));
                    FilterItems();
                }
            }
        }
        private int? _selectedCategoryId;
        public int? SelectedCategoryId
        {
            get => _selectedCategoryId;
            set
            {
                if (_selectedCategoryId != value)
                {
                    _selectedCategoryId = value;
                    OnPropertyChanged(nameof(SelectedCategoryId));
                    FilterItems();
                }
            }
        }
        
      
        private Collectable4Sale _selectedItem;
        public Collectable4Sale ItemSelected
        {
            get => _selectedItem;
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    ImagePath = _selectedItem.ImagePath;
                    Appuser Usern = App.UserRepo.GetEntity(_selectedItem.userId);
                    Username = Usern.username;
                    OnPropertyChanged(nameof(ItemSelected));
                }
            }
        }
        public ICommand LoadAddressCommand { get; }
        public MarketViewModel()
        {
            GetNonCollectables();
            FilterItems();
            //LoadAddressCommand = new Command(async () => await LoadAddressAsync());
        }

        private void GetNonCollectables()
        {
            Categories = App.CategoRepo.GetEntitiesWithChildren();
            List<Collectable4Sale> noni = App.Market.GetEntitiesWithChildren();
            foreach (Collectable4Sale nollectable in noni)
            {
                FilteredItems.Add(nollectable);
            }
        }
        public void FilterItems()
        {
            //FilteredItems.Clear();
            var filtered = Items.Where(item =>
                !SelectedCategoryId.HasValue || // No category selected
                item.categoryId == SelectedCategoryId.Value); // Match found

            foreach (var item in filtered)
            {
                FilteredItems.Add(item);
            }

        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
