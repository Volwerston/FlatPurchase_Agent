using FlatPurchase_Agent.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatPurchase_Agent.Models.Helpers
{
    public class AgentHelper : INotifyPropertyChanged
    {
        public Agent Agent { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool Validate()
        {
            return ValidateName() 
                & ValidateSurname()
                & ValidateLastName() 
                & ValidateId();
        }

        public AgentHelper()
            : this(new Agent())
        {
        }

        public AgentHelper(Agent a)
        {
            Agent = a;

            NameValidation = "";
            SurnameValidation = "";
            LastNameValidation = "";
            IdValidation = "";
        }

        #region Validation Messages

        private string nameValidation;

        private string surnameValidation;

        private string lastNameValidation;

        private string idValidation;
  
        public string NameValidation
        {
            get
            {
                return nameValidation;
            }
            set
            {
                if(nameValidation != value)
                {
                    nameValidation = value;
                    OnPropertyChanged("NameValidation");
                }
            }
        }
        public string SurnameValidation
        {
            get
            {
                return surnameValidation;
            }
            set
            {
                if(surnameValidation != value)
                {
                    surnameValidation = value;
                    OnPropertyChanged("SurnameValidation");
                }
            }
        }
        public string LastNameValidation
        {
            get
            {
                return lastNameValidation;
            }
            set
            {
                if(lastNameValidation != value)
                {
                    lastNameValidation = value;
                    OnPropertyChanged("LastNameValidation");
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
                if(idValidation != value)
                {
                    idValidation = value;
                    OnPropertyChanged("IdValidation");
                }
            }
        }

        #endregion

        #region Validation Methods

        private bool ValidateName()
        {
            if (string.IsNullOrWhiteSpace(Agent.Name))
            {
                NameValidation = "Заповніть поле Ім'я";
                return false;
            }
            else
            {
                NameValidation = "";
                return true;
            }
        }

        private bool ValidateSurname()
        {
            if (string.IsNullOrWhiteSpace(Agent.Surname))
            {
                SurnameValidation = "Заповніть поле Прізвище";
                return false;
            }
            else
            {
                SurnameValidation = "";
                return true;
            }
        }

        private bool ValidateLastName()
        {
            if (string.IsNullOrWhiteSpace(Agent.LastName))
            {
                LastNameValidation = "Заповніть поле По-батькові";
                return false;
            }
            else
            {
                LastNameValidation = "";
                return true;
            }
        }

        private bool ValidateId()
        {
            if (Agent.Id <= 0)
            {
                IdValidation = "Ідентифікаційний код повинен бути цілим додатним числом";
                return false;
            }
            else
            {
                IdValidation = "";
                return true;
            }
        }


        #endregion
    }
}
