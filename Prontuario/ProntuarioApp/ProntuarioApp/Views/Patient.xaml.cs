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
	public partial class Patient : TabbedPage
	{
		public Patient (Paciente paciente)
		{
			InitializeComponent();

            var navigationPage = new NavigationPage(new PatientDetail(paciente));
            navigationPage.Title = "Dados";
            navigationPage.Icon = "home.png";
            Children.Add(navigationPage);

            var navigationPageHistory = new NavigationPage(new PatientHistory(paciente));
            navigationPageHistory.Title = "Atendimentos";
            navigationPageHistory.Icon = "doctor.png";
            Children.Add(navigationPageHistory);

            var navigationPageMedical = new NavigationPage(new PatientMedical(paciente));
            navigationPageMedical.Title = "Medicação";
            navigationPageMedical.Icon = "medicine.png";

            Children.Add(navigationPageMedical);

        }
	}
}