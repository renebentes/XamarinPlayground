using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FlagData
{
    /// <summary>
    /// This model object represents a single flag
    /// </summary>
    public class Flag : INotifyPropertyChanged
    {
        private string _country;
        private DateTime _dateAdopted;

        private string _description;

        private string _imageUrl;

        private bool _includeShield;
        private Uri _moreInformationUrl;

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Name of the country that this flag belongs to
        /// </summary>
        public string Country
        {
            get => _country;
            set
            {
                if (_country != value)
                {
                    _country = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// The date this flag was adopted
        /// </summary>
        public DateTime DateAdopted
        {
            get => _dateAdopted;
            set
            {
                if (_dateAdopted != value)
                {
                    _dateAdopted = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Some trivia or commentary about the flag
        /// </summary>
        public string Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Image URL for the flag (from resources)
        /// </summary>
        public string ImageUrl
        {
            get => _imageUrl;
            set
            {
                if (_imageUrl != value)
                {
                    _imageUrl = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Whether the flag includes an image/shield as part of the design
        /// </summary>
        public bool IncludesShield
        {
            get => _includeShield;
            set
            {
                if (_includeShield != value)
                {
                    _includeShield = value; RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// A URL for more information
        /// </summary>
        public Uri MoreInformationUrl
        {
            get => _moreInformationUrl;
            set
            {
                if (_moreInformationUrl != value)
                {
                    _moreInformationUrl = value; RaisePropertyChanged();
                }
            }
        }

        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}