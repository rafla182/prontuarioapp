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
	public partial class Menu : ContentPage
	{
		public Menu (Paciente paciente)
		{
			InitializeComponent ();

		    var imageButton = new ImageButton
		    {
		        Source = "Paciente.png",
		        HorizontalOptions = LayoutOptions.CenterAndExpand,
		        VerticalOptions = LayoutOptions.Start,
		        HeightRequest = 150,
		        BackgroundColor = Color.Transparent,
                BorderColor = Color.Gray,
		        Padding = 10
            };

		    var imageButton2 = new ImageButton
		    {
		        Source = "Atendimentos.png",
		        HorizontalOptions = LayoutOptions.CenterAndExpand,
		        VerticalOptions = LayoutOptions.Start,
		        HeightRequest = 150,
		        BackgroundColor = Color.Transparent,
		        Padding = 10
            };

		    var imageButton3 = new ImageButton
		    {
		        Source = "Prescricoes.png",
		        HorizontalOptions = LayoutOptions.CenterAndExpand,
		        VerticalOptions = LayoutOptions.Start,
		        HeightRequest = 150,
                BackgroundColor = Color.Transparent,
                Padding = 10

            };

		    var imageButton4 = new ImageButton
		    {
		        Source = "Cirurgias.png",
		        HorizontalOptions = LayoutOptions.CenterAndExpand,
		        VerticalOptions = LayoutOptions.Start,
		        HeightRequest = 150,
		        BackgroundColor = Color.Transparent,
		        Padding = 10

		    };


            imageButton.Clicked += (e, o) => { App.NavigateMasterDetail(new DadosPaciente(paciente) { Title = "Dados Gerais"}); };
		    imageButton2.Clicked += (e, o) => { App.NavigateMasterDetail(new Atendimentos(paciente) { Title = "Atendimentos" }); };
            imageButton3.Clicked += (e, o) => { App.NavigateMasterDetail(new Prescricoes(paciente) { Title = "Prescrições" }); };
            imageButton4.Clicked += (e, o) => { App.NavigateMasterDetail(new Cirurgias(paciente) { Title = "Cirurgias" }); };

            var label = new Label()
		    {
                Text = paciente.Nome,
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
		        HorizontalOptions = LayoutOptions.CenterAndExpand,
		        VerticalOptions = LayoutOptions.CenterAndExpand,
		        TextColor = Color.Gray,
            };

		    var label2 = new Label()
		    {
		        Text = paciente.DataNascimento,
		        FontSize = 18,
                TextColor = Color.Gray,
		        FontAttributes = FontAttributes.Bold,
		        HorizontalOptions = LayoutOptions.CenterAndExpand,
		        VerticalOptions = LayoutOptions.CenterAndExpand
		    };

            var labelStack = new StackLayout() { HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.Start };
		    var labelStack2 = new StackLayout() { HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.Start };
            var imagesStack = new StackLayout() { HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.Start, Orientation = StackOrientation.Horizontal, Padding = 10 };
		    var imagesStack2 = new StackLayout() { HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.Start, Orientation = StackOrientation.Horizontal, Padding = 10 };

            labelStack.Children.Add(label);
		    labelStack2.Children.Add(label2);

		    imagesStack.Children.Add(imageButton);
		    imagesStack.Children.Add(imageButton2);
		    imagesStack2.Children.Add(imageButton3);
            imagesStack2.Children.Add((imageButton4));
            Content = new StackLayout
		    {
		        Children = { labelStack, labelStack2, imagesStack, imagesStack2 },
                Padding = 20
		    };
        }
    }
}