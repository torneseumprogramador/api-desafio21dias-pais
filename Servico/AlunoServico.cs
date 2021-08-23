
using System.Net.Http;
using System.Threading.Tasks;

namespace api_desafio21dias.Servicos
{
    public class AlunoServico
    {
        public static async Task<bool> ValidarUsuario(int id)
        {
            using (var http = new HttpClient())
            {
                using (var response = await http.GetAsync($"{Program.AlunoApi}/alunos/{id}"))
                {
                    return response.IsSuccessStatusCode;
                }
            }
        }
    }
}