using CheckIn.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows;
using CheckIn.Utility;
using CheckIn.View;

namespace CheckIn.ViewModel
{
    public class welcomePageViewModel : BaseViewModel
    {
        private LangModel _language = new LangModel();

        public LangModel Language
        {
            get { return _language; }
            set 
            { 
                _language = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand setDe { get; }
        public RelayCommand setEn { get; }
        public RelayCommand setFr { get; }

        public welcomePageViewModel()
        {
            setDe = new RelayCommand(param => SetToDE(), param => CanSetToDE());
            setEn = new RelayCommand(param => SetToEN(), param => CanSetToEN());
            setFr = new RelayCommand(param => SetToFR(), param => CanSetToFR());
        }

        public void SetToDE()
        {
            langString = "de";
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("de");
            reInit();
        }
        public bool CanSetToDE()
        {
            return langString != "de";
        }
        public void SetToEN()
        {
            langString = "en";
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
            reInit();
        }
        public bool CanSetToEN()
        {
            return langString != "en";
        }
        public void SetToFR()
        {
            langString = "fr";
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr");
            reInit();
        }
        public bool CanSetToFR()
        {
            return langString != "fr";
        }

        public string langString
        {
            get
            {
                return _language.langString;
            }
            set
            {
                _language.langString = value;
                OnPropertyChanged();
            }
        }

        public void reInit()
        {
            foreach (Window item in Application.Current.Windows)
            {
                if (item.IsActive)
                {
                    welcomePage wp = new welcomePage();
                    wp.DataContext = this;
                    item.Close();
                    wp.ShowDialog();
                }
            }
        }
    }
}
