using FlatPurchase_Agent.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatPurchase_Agent.Models.Helpers
{
    public class FlatHelper : INotifyPropertyChanged
    {
        public Flat Flat { get; set; }

        public bool Validate()
        {
            return ValidateAddress()
                & ValidateArea()
                & ValidateFloor()
                & ValidatePrice();
        }
        
        public FlatHelper()
            : this(new Flat())
        {
        }

        public FlatHelper(Flat f)
        {
            Flat = f;

            AddressValidation = "";
            AreaValidation = "";
            FloorValidation = "";
            PriceValidation = "";
        }

        #region Validation Messages

        private string addressValidation;

        private string floorValidation;

        private string areaValidation;

        private string priceValidation;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public string AddressValidation
        {
            get
            {
                return addressValidation;
            }
            set
            {
                if(addressValidation != value)
                {
                    addressValidation = value;
                    OnPropertyChanged("AddressValidation");
                }
            }
        }
        public string FloorValidation
        {
            get
            {
                return floorValidation;
            }
            set
            {
                if(floorValidation != value)
                {
                    floorValidation = value;
                    OnPropertyChanged("FloorValidation");
                }
            }
        }
        public string AreaValidation
        {
            get
            {
                return areaValidation;
            }
            set
            {
                if(areaValidation != value)
                {
                    areaValidation = value;
                    OnPropertyChanged("AreaValidation");
                }
            }
        }
        public string PriceValidation
        {
            get
            {
                return priceValidation;
            }
            set
            {
                if(priceValidation != value)
                {
                    priceValidation = value;
                    OnPropertyChanged("PriceValidation");
                }
            }
        }

        #endregion

        #region Validation Methods

        private bool ValidateAddress()
        {
            if (string.IsNullOrWhiteSpace(Flat.Address))
            {
                AddressValidation = "Заповніть поле Адреса";
                return false;
            }
            else
            {
                AddressValidation = "";
                return true;
            }

        }

        private bool ValidateFloor()
        {
            if(Flat.Floor <= 0)
            {
                FloorValidation = "Поверх повинен бути додатним числом";
                return false;
            }
            else
            {
                FloorValidation = "";
                return true;
            }
        }

        private bool ValidateArea()
        {
            if (Flat.Area <= 0)
            {
                AreaValidation = "Площа повинна бути додатним числом";
                return false;
            }
            else
            {
                AreaValidation = "";
                return true;
            }
        }

        private bool ValidatePrice()
        {
            if (Flat.Price <= 0)
            {
                PriceValidation = "Ціна повинна бути додатним числом";
                return false;
            }
            else
            {
                PriceValidation = "";
                return true;
            }
        }

        #endregion
    }
}
