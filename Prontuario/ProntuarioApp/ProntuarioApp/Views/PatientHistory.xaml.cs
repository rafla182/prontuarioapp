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
	public partial class PatientHistory : ContentPage
	{
	    private readonly PacienteApiService _pacienteApiService;


        public PatientHistory(Paciente paciente)
	    {
	        InitializeComponent();
	        _pacienteApiService = new PacienteApiService(); // You can use Dependency Injection

	        NomePaciente.Text = paciente.Nome;
	        ListarAtendimentos(paciente.Id);
	    }

        private async void ListarAtendimentos(int id)
        {
            var result = await _pacienteApiService.ListarAtendimentos(id);
            if (result.Success)
            {
                PatientHistorys.ItemsSource = result.Result.ToList();
            }
        }
    }
}