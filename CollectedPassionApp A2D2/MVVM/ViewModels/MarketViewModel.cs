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
        private List<Appuser> _appusers;
        public List<Appuser> Appusers
        {
            get => _appusers = App.UserRepo.GetEntitiesWithChildren();
            set
            {
                if (_appusers != value)
                {
                    _appusers = value;
                    OnPropertyChanged(nameof(Appusers));
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
        private Appuser _selecteduser;
        public Appuser SelectedUser
        {
            get => _selecteduser;
            set
            {
                _selecteduser = value;
                OnPropertyChanged(nameof(SelectedUser));
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
                SelectedUser = Appusers.FirstOrDefault(c => c.Id == _selectedItem.userId);
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
        public ObservableCollection<Collectable4Sale> MItems { get; set; } = new ObservableCollection<Collectable4Sale>();
        public ObservableCollection<Category> categories { get; set; } = new ObservableCollection<Category> { };
        public List<Collectable> collectablesForSale {  get; set; } = new List<Collectable> { };
        
        public ICommand SearchCommand => new Command<string>(PerformSearch);

        


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
            MItems.Clear();
            Items.Clear();
            Categories = App.CategoRepo.GetEntities();
            int currentUserId = App.CurrentUserId;
            List<Collectable4Sale> noni = App.Market.GetEntitiesWithChildren();
            foreach (Collectable4Sale nollectable in noni)
            {
                Items.Add(nollectable);
                foreach(Collectable4Sale isusers in Items )
                {
                    if (nollectable.userId == currentUserId)
                    {
                        MItems.Add(nollectable);
                    }
                }
            }
            
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
