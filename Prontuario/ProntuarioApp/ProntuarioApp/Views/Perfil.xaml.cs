using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProntuarioApp.Models;
using ProntuarioApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProntuarioApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Perfil : ContentPage
	{
	    private readonly PacienteApiService _pacienteApiService;

        public Perfil ()
		{
			InitializeComponent ();

		    _pacienteApiService = new PacienteApiService();

		    BuscarMedico(34);
        }

	    private async void BuscarMedico(int id)
	    {
	        var result = await _pacienteApiService.BuscarMedico(id);
	        if (result.Success)
	        {
	            BindingContext = result.Result;
	        }
	    }
    }


    

}