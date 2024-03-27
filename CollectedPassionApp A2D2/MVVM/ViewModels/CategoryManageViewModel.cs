using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using System.Windows.Input;
using System.ComponentModel;
using CollectedPassionApp_A2D2.MVVM.Models;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;

namespace CollectedPassionApp_A2D2.MVVM.ViewModels
{

    public class CategoryManageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Category> Categories { get; set; } = new ObservableCollection<Category>();
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
        private Category _selecteditem;
        public Category SelectedItem
        {
            get  { return _selecteditem; }
            set
            {
                if (_selecteditem != value)
                {
                    _selecteditem = value;
                   
                    OnPropertyChanged(nameof(SelectedItem));
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
                    _selectedCategory = SelectedCategory;

                    OnPropertyChanged(nameof(SelectedCategory));
                    // Optionally, filter collectibles by selected category
                }
            }
        }

        public ICommand AddCategoryCommand { get; set; }
        public ICommand DeleteCategory {  get; set; }
        
        public CategoryManageViewModel()
        {
            GetAllCategories();
            Category cat = SelectedItem;
            AddCategoryCommand = new Command(AddCategory);
            DeleteCategory = new Command(item => OnDelete(SelectedItem));
        }

        private void AddCategory()
        {
            if (!string.IsNullOrWhiteSpace(Catname) && !string.IsNullOrWhiteSpace(Description))
            {
                App.CategoRepo.SaveEntity(new Category { Catname = Catname, Description = Description });
                Categories.Add(new Category { Catname = Catname, Description = Description });
                OnPropertyChanged(nameof(Categories));

                // Clear input fields after adding category
                Catname = string.Empty;
                Description = string.Empty;
            }
        }
        private void OnDelete(Category cat)
        {
            App.CategoRepo.DeleteEntityWithChildren(cat);
            Categories.Remove(cat);
        }

        private void GetAllCategories()
        {
            Categories.Clear();
            var category = App.CategoRepo.GetEntities();
            foreach (Category cat in category)
            {
                Categories.Add(cat);
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}