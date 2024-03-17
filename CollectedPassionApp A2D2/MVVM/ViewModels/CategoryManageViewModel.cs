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
        

        public ICommand AddCategoryCommand { get; set; }
        public ICommand DeleteCategory {  get; set; }

        public CategoryManageViewModel()
        {
            GetAllCategories();
            Category cat = SelectedItem;
            AddCategoryCommand = new Command<string>(AddCategory);
            DeleteCategory = new Command(item => OnDelete(SelectedItem));
        }

        private void AddCategory(string categoryName)
        {
            if (!string.IsNullOrWhiteSpace(categoryName))
            {
                AddCategoryCommand = new Command<string>(AddCategory);
                App.CategoRepo.SaveEntity(new Category { Catname = categoryName });
                Categories.Add(new Category { Catname = categoryName });
                OnPropertyChanged(nameof(Categories));
            }
        }
        private void OnDelete(Category cat)
        {
            App.CategoRepo.DeleteEntityWithChildren(cat);
            Categories.Remove(cat);
        }

        private void GetAllCategories()
        {
            // Assuming App.CategoRepo.GetEntitiesWithChildren() returns a List<Category>
            var categories = App.CategoRepo.GetEntitiesWithChildren();
            foreach (var category in categories)
            {
                Categories.Add(category);
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}