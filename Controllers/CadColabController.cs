using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Data.SqlClient;
using ProjetoTimesheet.Models;

namespace ProjetoTimesheet.Controllers
{
        
    [ApiController]
        [Route("/co")]
        public class CadColabController : ControllerBase
        {
            [HttpPost("CadColab")]

            public async Task<string> Cad()
            {
                RestClient client = new("http://projetos.gateware.com.br:8000/intranet/users");
                var request = new RestRequest();

            var Con = new Conexãobanco();
            Object[] dadosmanager = new Object[21];
            dadosmanager = (object[])Con.getData();

            var dadosjson = new NovoColaborador
            {
                email = Convert.ToString(dadosmanager[16]),
                username = Convert.ToString(dadosmanager[17]), 
                password = Convert.ToString(dadosmanager[18]),
                first_names = Convert.ToString(dadosmanager[19]),
                last_name = Convert.ToString(dadosmanager[20])
            };

            Console.WriteLine(dadosjson);

            request.AddHeader("Authorization", "Basic Z3VzdGF2by5yaWJlaXJvQGdhdGV3YXJlLmNvbS5icjpnd0BHdXN0YXZvMzA3Mw==");
            request.AddHeader("Cookie", "ad_session_id=\"833158%252c0%252c0%252c1670933700%2b%257b303%2b1670934900%2b0D1818031768B7A957A415E469A864B5276D239B%257d\"");
            request.AddJsonBody(dadosjson);

            try
                {
                    RestResponse response = await client.PostAsync(request);
                    
                    return (response.Content);
                }
                catch (Exception error)
                {
                    return error.Message;
                }
            }
        }


    //  http://projetos.gateware.com.br:8000/intranet/projects/view?project_id=231031
    //http://projetos.gateware.com.br:8000/intranet/member-add?limit_to_users_in_group_id=&also_add_to_group_id=1&return_url=%2fintranet%2fprojects%2fview%3fproject_id%3d232391&object_id=232391
    //http://projetos.gateware.com.br:8000/intranet/member-add?limit_to_users_in_group_id=&also_add_to_group_id=1&return_url=%2fintranet%2fprojects%2fview%3fproject_id%3d231031&object_id=231031
}
