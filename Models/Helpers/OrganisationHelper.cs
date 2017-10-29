using FlatPurchase_Agent.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatPurchase_Agent.Models.Helpers
{
    public class OrganisationHelper : INotifyPropertyChanged
    {
        public Organisation Organisation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool Validate()
        {
            return ValidateAddress()
            & ValidateId()
            & ValidateLicenseId()
            & ValidateTitle();
        }

        public OrganisationHelper()
            : this(new Organisation())
        {
        }

        public OrganisationHelper(Organisation o)
        {
            Organisation = o;

            AddressValidation = "";
            IdValidation = "";
            LicenseIdValidation = "";
            TitleValidation = "";
        }

        #region Validation Messages

        private string addressValidation;

        private string idValidation;

        private string licenseIdValidation;

        private string titleValidation;

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
        public string IdValidation
        {
            get
            {
                return idValidation;
            }
            set
            {
                if (idValidation != value)
                {
                    idValidation = value;
                    OnPropertyChanged("IdValidation");
                }
            }
        }
        public string TitleValidation
        {
            get
            {
                return titleValidation;
            }
            set
            {
                if(titleValidation != value)
                {
                    titleValidation = value;
                    OnPropertyChanged("TitleValidation");
                }
            }
        }
        public string LicenseIdValidation
        {
            get
            {
                return licenseIdValidation;
            }
            set
            {
                if(licenseIdValidation != value)
                {
                    licenseIdValidation = value;
                    OnPropertyChanged("LicenseIdValidation");
                }
            }
        }

        #endregion

        #region Validation Methods

        private bool ValidateAddress()
        {
            if (string.IsNullOrWhiteSpace(Organisation.Address))
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

        private bool ValidateTitle()
        {
            if (string.IsNullOrWhiteSpace(Organisation.Title))
            {
                TitleValidation = "Заповніть поле Назва";
                return false;
            }
            else
            {
                TitleValidation = "";
                return true;
            }
        }

        private bool ValidateId()
        {
            if (Organisation.Id <= 0)
            {
                IdValidation = "ID повинне бути цілим додатним числом";
                return false;
            }
            else
            {
                IdValidation = "";
                return true;
            }
        }

        private bool ValidateLicenseId()
        {
            if (Organisation.LicenseId <= 0)
            {
                LicenseIdValidation = "Номер ліцензії повинен бути цілим додатним числом";
                return false;
            }
            else
            {
                LicenseIdValidation = "";
                return true;
            }
        }

        #endregion
    }
}
