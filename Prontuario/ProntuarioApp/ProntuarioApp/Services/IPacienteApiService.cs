using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProntuarioApp.Client;
using ProntuarioApp.Client.Models;
using ProntuarioApp.Models;
using ProntuarioApp.Views;

namespace ProntuarioApp.Services
{
    public interface IPacienteApiService : IApiClient
    {
        Task<BaseApiResult<List<Paciente>>> BuscarTodosPacientes(string nome);
        Task<BaseApiResult<List<Atendimento>>> ListarAtendimentos(int id);
        Task<BaseApiResult<List<Prescricao>>> ListarPrescricao(int id);
        Task<BaseApiResult<List<Cirurgia>>> ListarCirurgias(int id);
        Task<BaseApiResult<Medico>> Login(string emailText, string senhaText);
        Task<BaseApiResult<List<Paciente>>> ListaPacientesPorMedico(int id);
        Task<BaseApiResult<Medico>> BuscarMedico(int id);
    }
}
