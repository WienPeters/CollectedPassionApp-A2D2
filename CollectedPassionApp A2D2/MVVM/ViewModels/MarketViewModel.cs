using CollectedPassionApp_A2D2.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CollectedPassionApp_A2D2.MVVM.ViewModels
{
    class MarketViewModel : INotifyPropertyChanged
    {
        private readonly LocationService _locationService = new LocationService();
        public string Address { get; private set; }
        
      

        private string _imagePath;
        public string ImagePath
        {
            get => _imagePath;
            set
            {
                _imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
            }
        }
        public ObservableCollection<Noncollectable> Items { get; set; } = new ObservableCollection<Noncollectable>();
        public ObservableCollection<Noncollectable> NonCollectibles { get; set; }
        
        private Noncollectable _selectedItem;
        public Noncollectable ItemSelected
        {
            get => _selectedItem;
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged(nameof(ItemSelected));
                    // Update the ImagePath whenever a new item is selected
                    ImagePath = _selectedItem.ImagePath;
                }
            }
        }
        public ICommand LoadAddressCommand { get; }
        public MarketViewModel()
        {

            GetNonCollectables();
            //LoadAddressCommand = new Command(async () => await LoadAddressAsync());
        }
        private void GetNonCollectables()
        {
            
            List<Noncollectable> noni = App.MarketRepo.GetEntitiesWithChildren();
            foreach (Noncollectable nollectable in noni)
            {
                Items.Add(nollectable);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
