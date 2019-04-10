using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProntuarioApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProntuarioApp.Views.MasterPage
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Detail : ContentPage
	{
		public Detail(Medico result)
		{
			InitializeComponent();

		    btnGoPaciente.Clicked += async (sender, e) => { await App.NavigateMasterDetail(new Search() { Title = "Buscar Paciente" }); };
		    btnGoPerfil.Clicked += async (sender, e) => { await App.NavigateMasterDetail(new Perfil() { Title = "Perfil "}); };
            btnGoLogout.Clicked += async (sender, e) =>
            {
                var pageLogin = new Login() { Title = "Login " };
                Application.Current.MainPage = new NavigationPage(pageLogin);
            };
		    btnGoMyPaciente.Clicked += async (sender, e) => { await App.NavigateMasterDetail(new MeusPacientes( new Medico() { Id = result.Id }) { Title = "Meus Pacientes" }); };
        }
    }
}