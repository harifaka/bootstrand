using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity_generator
{
    internal class CsvRow : INotifyPropertyChanged
    {
        private string _token;
        private string _description;
        private string _defaultValue;

        public string Token
        {
            get => _token;
            set
            {
                if (_token != value)
                {
                    _token = value;
                    OnPropertyChanged(nameof(Token));
                }
            }
        }

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

        public string DefaultValue
        {
            get => _defaultValue;
            set
            {
                if (_defaultValue != value)
                {
                    _defaultValue = value;
                    OnPropertyChanged(nameof(DefaultValue));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
