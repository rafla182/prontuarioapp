using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProntuarioApp.Client;
using ProntuarioApp.Client.Models;
using ProntuarioApp.Models;
using ProntuarioApp.Views;

namespace ProntuarioApp.Services
{
    public sealed class PacienteApiService : ApiClient, IPacienteApiService
    {

        public PacienteApiService() : base("https://prontuarioapp.azurewebsites.net/api")
        {
        }

        public async  Task<BaseApiResult<List<Paciente>>> BuscarTodosPacientes()
        {
            return await ProntuarioApiService.Current.PostAsync<List<Paciente>>("pacientes/buscar", new BuscaRequest() { Nome = "Fabiana"} );
        }

        public async Task<BaseApiResult<List<Atendimento>>> ListarAtendimentos(int id)
        {
            return await ProntuarioApiService.Current.GetAsync<List<Atendimento>>("pacientes/atendimentos/" + id);
        }

        public async Task<BaseApiResult<List<Prescricao>>> ListarPrescricao(int id)
        {
            return await ProntuarioApiService.Current.GetAsync<List<Prescricao>>("pacientes/medicamentos/" + id);
        }
    }
}
