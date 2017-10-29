using FlatPurchase_Agent.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FlatPurchase_Agent.Models.DTO;
using System.IO;
using Newtonsoft.Json;
using System.ComponentModel;

namespace FlatPurchase_Agent.ViewModels
{
    class FlatPurchaseViewModel : DependencyObject, INotifyPropertyChanged
    {
        public AgentHelper AgentHelper
        {
            get { return (AgentHelper)GetValue(AgentHelperProperty); }
            set { SetValue(AgentHelperProperty, value); }
        }

        public static readonly DependencyProperty AgentHelperProperty =
            DependencyProperty.Register("AgentHelper", typeof(AgentHelper), typeof(FlatPurchaseViewModel), new PropertyMetadata(new AgentHelper()));


        public FlatHelper FlatHelper
        {
            get { return (FlatHelper)GetValue(FlatHelperProperty); }
            set { SetValue(FlatHelperProperty, value); }
        }

        public static readonly DependencyProperty FlatHelperProperty =
            DependencyProperty.Register("FlatHelper", typeof(FlatHelper), typeof(FlatPurchaseViewModel), new PropertyMetadata(new FlatHelper()));


        public OrganisationHelper OrganisationHelper
        {
            get { return (OrganisationHelper)GetValue(OrganisationHelperProperty); }
            set { SetValue(OrganisationHelperProperty, value); }
        }

        public static readonly DependencyProperty OrganisationHelperProperty =
            DependencyProperty.Register("OrganisationHelper", typeof(OrganisationHelper), typeof(FlatPurchaseViewModel), new PropertyMetadata(new OrganisationHelper()));


        public FlatPurchaseViewModel()
        {
            OrganisationHelper.PropertyChanged += OrganisationHelper_PropertyChanged;
            AgentHelper.PropertyChanged += AgentHelper_PropertyChanged;
            FlatHelper.PropertyChanged += FlatHelper_PropertyChanged;
        }

        private void FlatHelper_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e.PropertyName);
        }

        private void AgentHelper_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e.PropertyName);
        }

        private void OrganisationHelper_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e.PropertyName);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }


        public bool Register()
        {
            if (Validate())
            {
                SaveData(OrganisationHelper.Organisation, AgentHelper.Agent, FlatHelper.Flat);
                return true;
            }

            return false;
        }


        #region Helper Methods

        private bool Validate()
        {
            return AgentHelper.Validate()
                & FlatHelper.Validate()
                & OrganisationHelper.Validate();
        }

        private void SaveData(Organisation organisation, Agent agent, Flat flat)
        {
            List<Tuple<Organisation, Agent, Flat>> data = ExtractData();
            data.Add(new Tuple<Organisation, Agent, Flat>(organisation, agent, flat));
            SaveToFile(data);
        }

        private List<Tuple<Organisation, Agent, Flat>> ExtractData()
        {
            using (FileStream fs = new FileStream(("../../Data/data.txt"), FileMode.Open, FileAccess.Read))
            {
                using (StreamReader rdr = new StreamReader(fs))
                {
                    string data = rdr.ReadToEnd();

                    if (!string.IsNullOrWhiteSpace(data))
                    {
                        return JsonConvert.DeserializeObject<List<Tuple<Organisation, Agent, Flat>>>(data);
                    }
                    else
                    {
                        return new List<Tuple<Organisation, Agent, Flat>>();
                    }
                }
            }
        }

        private void SaveToFile(List<Tuple<Organisation, Agent, Flat>> data)
        {
            using (FileStream fs = new FileStream("../../Data/data.txt", FileMode.Truncate, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(JsonConvert.SerializeObject(data));
                }
            }
        }

        #endregion
    }
}
