
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using api_desafio21dias.Models;
using Newtonsoft.Json;

namespace api_desafio21dias.Servicos
{
    public class AlunoServico
    {
        public static async Task<bool> ValidarUsuario(int id, string token)
        {

            using (var http = new HttpClient())
            {
                http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                using (var response = await http.GetAsync($"{Program.AlunoApi}/alunos/{id}"))
                {
                    return response.IsSuccessStatusCode;
                }
            }
        }

        public static async Task<Aluno> BuscaPorId(int id, string token)
        {
            using (var http = new HttpClient())
            {
                http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                using (var response = await http.GetAsync($"{Program.AlunoApi}/alunos/{id}"))
                {
                    if(response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<Aluno>(responseBody);
                    }
                    return new Aluno();
                }
            }
        }
    }
}