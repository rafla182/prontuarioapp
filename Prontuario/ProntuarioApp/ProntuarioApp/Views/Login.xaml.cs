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
        private bool IsErro { get; set; }

        public Login()
		{
			InitializeComponent();
		    _pacienteApiService = new PacienteApiService();

		    IsLoading = false;
            BindingContext = this;
		    IsErro = false;
            btnLogin.Clicked += UserLogin;
        }


	    public async void UserLogin(object sender, EventArgs args)
	    {
            if(string.IsNullOrEmpty(Email.Text) || string.IsNullOrEmpty(Senha.Text))
                Erro.Text = "Favor preencher os dados.";
            else
                Show(sender, args);
	    }

	    public async void Show(object sender, EventArgs e)
	    {
	        try
	        {
                aparece();
	            await Task.Delay(4000);

                var result = await _pacienteApiService.Login(Email.Text, Senha.Text);
                if (result.Success)
                {
                    if (result.Result != null)
                    {
                        some();
                        App.Current.MainPage = new MainPage(result.Result);
                    }

                    Erro.Text = "Usuário ou senha incorreto. Tente novamente.";
                }

                Erro.Text = "Usuário ou senha incorreto. Tente novamente.";
	            some();
	        }
	        catch (Exception ex)
	        {
	            some();
	            if (ex != null)
	            {
	                Erro.Text = "Usuário ou senha incorreto. Tente novamente.";
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