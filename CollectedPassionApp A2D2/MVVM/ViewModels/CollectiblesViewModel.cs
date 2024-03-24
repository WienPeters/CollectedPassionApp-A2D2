using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CollectedPassionApp_A2D2.MVVM.Models;
using Microsoft.Extensions.Logging;

namespace CollectedPassionApp_A2D2.MVVM.ViewModels
{
    
    public class CollectiblesViewModel : INotifyPropertyChanged
    {
        #region variables

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
        private Category _selectedCategory;
        public Category SelectedCategory
        {
            get => _selectedCategory;
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
        private Collectable _selecteditem;
        public Collectable SelectedItem
        {
            get { return _selecteditem; }
            set
            {
                if (_selecteditem != value)
                {
                    _selecteditem = value;
                    OnPropertyChanged(nameof(SelectedItem));
                    // Optionally, filter collectibles by selected category
                }
            }
        }
        private Collectable _selecollectable;
        public Collectable SelectedCollectable
        {
            get  { return _selecollectable; }
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
        #endregion 
        public ObservableCollection<Collectable> Items { get; set; } = new ObservableCollection<Collectable>();

        public ICommand AddCollectibleCommand { get; private set; }
        public ICommand AddCategorytoCollectibleCommand { get; private set; }
        public ICommand DelSelectedCollected { get; private set; }
        public CollectiblesViewModel()
        {
            GetAllCategoriesNCollectables();
            Collectable col = SelectedCollectable;
            DelSelectedCollected = new Command(item => OnDelete(SelectedCollectable));
            AddCollectibleCommand = new Command(async () =>
            {
                Collectable collectable = new Collectable()
                {
                    Name = Name,
                    Description = Description,
                    categoryId = SelectedCategory.Id,
                    
                };
                Items.Add(collectable);
                App.CollectionRepo.SaveEntity(collectable);
                App.CollectionRepo.SaveEntityWithChildren(collectable);
                App.CategoRepo.UpdateEntityWithChildren(SelectedCategory);
            });
                        
        }
        
        private void OnDelete(Collectable col )
        {     
            App.CollectionRepo.DeleteEntityWithChildren(col);
            Items.Remove(col);
        }

        private void GetAllCategoriesNCollectables()
        {
            Categories = App.CategoRepo.GetEntities();
            List<Collectable> coleti = App.CollectionRepo.GetEntities();
            foreach (Collectable collectable in coleti)
            {
                Items.Add(collectable);
            }
        }
        
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
