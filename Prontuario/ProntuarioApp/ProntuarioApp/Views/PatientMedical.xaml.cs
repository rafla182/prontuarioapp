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
	public partial class PatientMedical : ContentPage
    { 
        private readonly PacienteApiService _pacienteApiService;

        public PatientMedical(Paciente paciente)
        {
            InitializeComponent();
            _pacienteApiService = new PacienteApiService(); // You can use Dependency Injection

            NomePaciente.Text = paciente.Nome;
           ListarPrescricoes(paciente.Id);
        }

        private async void ListarPrescricoes(int id)
        {
            var result = await _pacienteApiService.ListarPrescricao(id);
            if (result.Success)
            {
                PacienteMedicamentos.ItemsSource = result.Result.ToList();
            }
        }
    }
}