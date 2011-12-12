using System.ComponentModel;
using System.Device.Location;
using System.Windows;

// pretty sure this is dead code.

namespace Maps
{
    public class GeoItem : INotifyPropertyChanged
    {
        public GeoItem(bool isSelf)
        {
            PlaceVisibility = isSelf ? Visibility.Collapsed : Visibility.Visible;
            SelfVisibility = isSelf ? Visibility.Visible : Visibility.Collapsed;
        }
        public Visibility PlaceVisibility { get; set; }
        public Visibility SelfVisibility { get; set; }

        public string Title { get; set; }
        public string SecondaryText { get; set; }
        public string SmallText { get; set; }

        private GeoCoordinate _location;
        public GeoCoordinate Location 
        { get
        {
            return _location;
        }
            set
            {
                _location = value;
                OnPropertyChanged("Location");
            }
        }
        // consider images, etc. ?

        /// <summary>
        /// Event raised when a property changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The name of the property that has changed.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}