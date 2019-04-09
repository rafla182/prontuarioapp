using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProntuarioApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProntuarioApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage, INotifyPropertyChanged
    {

	    private readonly PacienteApiService _pacienteApiService;

        public Login()
		{
			InitializeComponent();
		    _pacienteApiService = new PacienteApiService();

		    IsLoading = false;
            BindingContext = this;

            btnLogin.Clicked += UserLogin;
        }


	    public async void UserLogin(object sender, EventArgs args)
	    {
	        Show(sender, args);
	    }

	    public async void Show(object sender, EventArgs e)
	    {
	        try
	        {
	            aparece();
	            App.Current.MainPage = new MainPage();
             //   var result = await _pacienteApiService.Login(Email.Text, Senha.Text);
	            //if (result.Success)
	            //{
	            //    some();
             //       App.Current.MainPage = new MainPage();
	            //}

                await Task.Delay(4000);
	            some();
	        }
	        catch (Exception ex)
	        {
	            some();
	            if (ex != null)
	            {
	                //Trate seu erro aqui
	            }
	        }
	    }

	    public async void aparece()
	    {
	        IsLoading = true;
	    }

	    public async void some()
	    {
	        IsLoading = false;
	    }
        
        private bool isLoading;
	    public bool IsLoading
	    {
	        get
	        {
	            return this.isLoading;
	        }
	        set
	        {
	            this.isLoading = value;
	            RaisePropertyChanged("IsLoading");
	        }
	    }

	    public event PropertyChangedEventHandler PropertyChanged;
	    public void RaisePropertyChanged(string name)
	    {
	        if (PropertyChanged != null)
	        {
	            PropertyChanged(this, new PropertyChangedEventArgs(name));
	        }
	    }
	}
}