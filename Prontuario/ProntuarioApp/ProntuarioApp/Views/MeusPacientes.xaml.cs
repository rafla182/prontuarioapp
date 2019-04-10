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
	public partial class MeusPacientes : ContentPage
	{
	    private readonly PacienteApiService _pacienteApiService;

	    public MeusPacientes(Medico medico)
	    {
	        InitializeComponent();

	        _pacienteApiService = new PacienteApiService();

	        IsLoading = false;
	        BindingContext = this;

            ListarMeusPacientes(medico.Id);

        }

	    async void VerPaciente(object sender, SelectedItemChangedEventArgs e)
	    {
	        ListView lv = (ListView)sender;
	        Paciente paciente = (Paciente)lv.SelectedItem;

	        await Navigation.PushAsync(new Menu(paciente));
	    }

        private async void ListarMeusPacientes(int id)
	    {
	        try
	        {
	            aparece();

	            var result = await _pacienteApiService.ListaPacientesPorMedico(id);
                if (result.Success)
	            {
	                some();
	                MeusPacientesResponse.ItemsSource = result.Result.ToList();

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