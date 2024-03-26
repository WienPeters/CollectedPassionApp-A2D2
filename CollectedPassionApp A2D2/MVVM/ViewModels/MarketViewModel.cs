using CollectedPassionApp_A2D2.Abstractions;
using CollectedPassionApp_A2D2.MVVM.Models;
using CollectedPassionApp_A2D2.Repositories;
using CollectedPassionApp_A2D2.MVVM.Views.Manager;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;


namespace CollectedPassionApp_A2D2.MVVM.ViewModels
{
    class MarketViewModel : INotifyPropertyChanged
    {

        
        #region Dingens

        private List<Category> _categories;
        public List<Category> Categories
        {
            get => _categories = App.CategoRepo.GetEntitiesWithChildren(); 
            set
            {
                if (_categories != value)
                {
                    
                    _categories = value;
                    OnPropertyChanged(nameof(Categories));
                }
            }
        }
        private Category _selectedCategory;
        public Category SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
            }
        }
        private string _username;
        public string Username
        {
            get => _username;
            private set
            {
                if (_username != value)
                {

                    //Appuser uzer = App.UserRepo.GetEntity(ItemSelected.userId);
                    //_username = uzer.name;
                    //Username = uzer.username;
                    OnPropertyChanged(Username);
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
                    //Name = uzer.name = value;
                    _name = value;
                    //Name = ItemSelected.Name;
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
                    //Description = ItemSelected.Description;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        private string _imagepath;
        public string ImagePath
        {
            get => _imagepath;
            set
            {
                if (_imagepath != value)
                {
                    _imagepath = value;
                    //ImagePath = ItemSelected.imagepath;
                    OnPropertyChanged(nameof(ImagePath));
                }
            }
        }
        private double _price;
        public double price
        {
            get => _price;
            set
            {
                if (_price != value)
                {
                    _price = value;
                    //price = ItemSelected.price.Value;
                    OnPropertyChanged(nameof(price));
                }
            }
        }
        private Collectable4Sale _selectedItem;
        public Collectable4Sale ItemSelected
        {
            get => _selectedItem ;
            set
            {
                if (_selectedItem != value)
                {

                _selectedItem = value;
                ImagePath = ItemSelected.imagepath;
                SelectedCategory = Categories.FirstOrDefault(c => c.Id == _selectedItem.categoryId);
                    //Description = _selectedItem.Description;
                    //price = _selectedItem.price.Value;

                    //Category categ = App.CategoRepo.GetEntityByName(_selectedCategoryid.Catname);
                    //int catid = categ.Id;
                    OnPropertyChanged(nameof(ItemSelected));
                }
                else { _selectedItem = null; }
            }
        }
        
        #endregion
        public ObservableCollection<Collectable4Sale> Items { get; set; } = new ObservableCollection<Collectable4Sale>();
        public ObservableCollection<Collectable4Sale> FilteredItems { get; set; } = new ObservableCollection<Collectable4Sale>();
        public ObservableCollection<Category> categories { get; set; } = new ObservableCollection<Category> { };
        public List<Collectable> collectablesForSale {  get; set; } = new List<Collectable> { };
        
        public ICommand SearchCommand => new Command<string>(PerformSearch);

        private void ItemSelectedHandler(Collectable4Sale selectedItem)
        {
            // Retrieve the category object based on selectedItem's categoryId
            SelectedCategory = Categories.FirstOrDefault(c => c.Id == selectedItem.categoryId);
            // Update other properties as needed
        }


        private void PerformSearch(string query)
        {
            // Implement your search logic here
        }
        public ICommand LoadAddressCommand { get; }
        public MarketViewModel()
        {
            GetNonCollectables();
            


        }
        private void GetAnyverzamelItem()
        {

            Appuser user = new Appuser();
            user.Collecta4bles = App.Market.GetEntitiesWithChildren();
            var allCollectables = user.Collecta4bles;
            List<Collectable4Sale> collectablesForSale =  allCollectables.OfType<Collectable4Sale>().ToList();
            var regularCollectables = allCollectables.Except(collectablesForSale).ToList();
        }
        private void GetNonCollectables()
        {


            Items.Clear();
            Categories = App.CategoRepo.GetEntities();
            List<Collectable4Sale> noni = App.Market.GetEntitiesWithChildren();
            foreach (Collectable4Sale nollectable in noni)
            {
                Items.Add(nollectable);
               // foreach(Category nolt in  Collectable4Sale in Items) { nolt.Marketables.Equals(nollectable.categoryId.Equals(App.Market.GetEntitiesWithChildren())); }
            }
            //ListView listView = new ListView();
            //listView.SetBinding(ItemsView.ItemsSourceProperty, "Items");
        }
        public void FillItems()
        {
            var categoriesWithCollectables = App.CategoRepo.GetAllWithKinders(recursive: true);
        }
        

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
