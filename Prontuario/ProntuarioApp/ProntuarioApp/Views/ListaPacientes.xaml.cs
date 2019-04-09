using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProntuarioApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProntuarioApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListaPacientes : ContentPage, INotifyPropertyChanged
    {
        private List<Paciente> result;

        public ListaPacientes(List<Paciente> result)
        {
            InitializeComponent();
            IsLoading = false;
            BindingContext = this;
            PacientesResponse.ItemsSource = result.ToList().OrderBy(p => p.Nome);
        }

	    async void VerPaciente(object sender, SelectedItemChangedEventArgs e)
	    {
	        ListView lv = (ListView)sender;
	        Paciente paciente = (Paciente)lv.SelectedItem;

	        await Navigation.PushAsync(new Menu(paciente));
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