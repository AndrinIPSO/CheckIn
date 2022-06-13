using CheckIn.Model;
using CheckIn.Utility;
using CheckIn.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows;

namespace CheckIn.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private LangModel _language = new LangModel();
        public RelayCommand setDe { get; }
        public RelayCommand setEn { get; }
        public RelayCommand setFr { get; }

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

        public LangModel Language
        {
            get { return _language; }
            set
            {
                _language = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            setDe = new RelayCommand(param => SetToDE(), param => CanSetToDE());
            setEn = new RelayCommand(param => SetToEN(), param => CanSetToEN());
            setFr = new RelayCommand(param => SetToFR(), param => CanSetToFR());
        }

        public void SetToDE()
        {
            langString = "de";
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("de");
            OpenWelcome();
        }
        public bool CanSetToDE()
        {
            return langString != "de";
        }
        public void SetToEN()
        {
            langString = "en";
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
            OpenWelcome();
        }
        public bool CanSetToEN()
        {
            return langString != "en";
        }
        public void SetToFR()
        {
            langString = "fr";
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr");

            OpenWelcome();
        }
        public bool CanSetToFR()
        {
            return langString != "fr";
        }

        public void OpenWelcome()
        {
            welcomePage np = new welcomePage();
            welcomePageViewModel wpvm = new welcomePageViewModel() { Language = this.Language };
            np.DataContext = wpvm;
            np.Show();
            Application.Current.MainWindow.Close();
        }
    }
}
