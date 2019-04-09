using System;
using System.Collections.Generic;
using System.ComponentModel;
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
	public partial class Prescricoes : ContentPage, INotifyPropertyChanged
    { 
        private readonly PacienteApiService _pacienteApiService;

        public Prescricoes(Paciente paciente)
        {
            InitializeComponent();
            IsLoading = false;
            BindingContext = this;

            _pacienteApiService = new PacienteApiService(); // You can use Dependency Injection

            NomePaciente.Text = paciente.Nome;
            ListarPrescricoes(paciente.Id);
        }

        private async void ListarPrescricoes(int id)
        {
            try
            {
                aparece();

                var result = await _pacienteApiService.ListarPrescricao(id);
                if (result.Success)
                {
                    some();
                    PrescricoesResponse.ItemsSource = result.Result.ToList();

                }

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