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
		public Detail()
		{
			InitializeComponent();

		    btnGoPaciente.Clicked += async (sender, e) => { await App.NavigateMasterDetail(new Search()); };
		    btnGoPerfil.Clicked += async (sender, e) => { await App.NavigateMasterDetail(new Perfil()); };
            btnGoLogout.Clicked += async (sender, e) => { await App.NavigateMasterDetail(new Login()); };
		    btnGoMyPaciente.Clicked += async (sender, e) => { await App.NavigateMasterDetail(new MeusPacientes( new Medico() { Id = 34 })); };
        }
    }
}