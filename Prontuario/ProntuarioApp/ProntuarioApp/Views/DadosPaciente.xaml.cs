using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProntuarioApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProntuarioApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DadosPaciente : ContentPage
	{
		public DadosPaciente(Paciente paciente)
		{
		    InitializeComponent();

            BindingContext = paciente;
        }

    }
}