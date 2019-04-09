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
	public partial class MeusPacientes : ContentPage
	{
	    private readonly PacienteApiService _pacienteApiService;

	    public MeusPacientes(Medico medico)
	    {
	        InitializeComponent();

	        _pacienteApiService = new PacienteApiService(); // You can use Dependency Injection
	        ListarMeusPacientes(medico.Id);

        }

	    private async void ListarMeusPacientes(int id)
	    {
	        var result = await _pacienteApiService.ListaPacientesPorMedico(id);
	        if (result.Success)
	        {
	            MeusPacientesResponse.ItemsSource = result.Result.ToList();
	        }
	    }

    }
}