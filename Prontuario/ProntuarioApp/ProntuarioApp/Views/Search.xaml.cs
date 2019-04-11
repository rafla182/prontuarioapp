using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProntuarioApp.Models;
using ProntuarioApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProntuarioApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Search : ContentPage, INotifyPropertyChanged
    {
        private readonly PacienteApiService _pacienteApiService;

        public Search()
        {
            InitializeComponent();
            IsLoading = false;
            BindingContext = this;

            IsErro = false;
            _pacienteApiService = new PacienteApiService(); // You can use Dependency Injection
        }

        public async void SearchPaciente(object sender, EventArgs args)
        {
            if (string.IsNullOrEmpty(Nome.Text))
                Erro.Text = "Favor preencher os dados.";
            else if (Nome.Text.Length < 3)
                Erro.Text = "Digite pelo menos 3 caracteres.";
            else
                Show(sender, args);
        }

        public async void Show(object sender, EventArgs e)
        {
            try
            {
                aparece();

                var result = await _pacienteApiService.BuscarTodosPacientes(Nome.Text);
                await Task.Delay(4000);

                if (result.Success)
                {
                    IsErro = false;

                    some();

                    if (result.Result.Any())
                    {
                        if(result.Result.Count() == 1)
                            await App.NavigateMasterDetail(new Menu(result.Result.FirstOrDefault()) {Title = "Menu"});
                        else
                        {
                            await App.NavigateMasterDetail(
                                new ListaPacientes(result.Result) {Title = "Resultado - Pacientes"});
                        }
                    }
                    else
                    {
                        Erro.Text = "Nenhum paciente encontrado.";
                    }
                }
                else
                {
                    some();
                    Erro.Text = "Nenhum paciente encontrado.";
                }

            }
            catch (Exception ex)
            {
                some();
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

        private bool IsErro { get; set; }
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