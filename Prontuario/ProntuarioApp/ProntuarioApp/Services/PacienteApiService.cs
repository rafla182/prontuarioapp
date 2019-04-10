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

        public async  Task<BaseApiResult<List<Paciente>>> BuscarTodosPacientes(string nome)
        {
            return await ProntuarioApiService.Current.PostAsync<List<Paciente>>("pacientes/buscar", new BuscaRequest() { Nome = nome } );
        }

        public async Task<BaseApiResult<List<Atendimento>>> ListarAtendimentos(int id)
        {
            return await ProntuarioApiService.Current.GetAsync<List<Atendimento>>("pacientes/atendimentos/" + id);
        }

        public async Task<BaseApiResult<List<Prescricao>>> ListarPrescricao(int id)
        {
            return await ProntuarioApiService.Current.GetAsync<List<Prescricao>>("pacientes/medicamentos/" + id);
        }

        public async Task<BaseApiResult<Medico>> BuscarMedico(int id)
        {
            return await ProntuarioApiService.Current.GetAsync<Medico>("medico/" + id);
        }

        public async Task<BaseApiResult<List<Paciente>>> ListaPacientesPorMedico(int id)
        {
            return await ProntuarioApiService.Current.GetAsync<List<Paciente>>("pacientes/medico/" + id);
        }

        public async Task<BaseApiResult<List<Cirurgia>>> ListarCirurgias(int id)
        {
            return await ProntuarioApiService.Current.GetAsync<List<Cirurgia>>("pacientes/cirurgia/" + id);
        }

        public async Task<BaseApiResult<Medico>> Login(string emailText, string senhaText)
        {
            return await ProntuarioApiService.Current.PostAsync<Medico>("medico/login", new LoginRequest(){ Email = emailText, Password = senhaText });
        }
    }
}
