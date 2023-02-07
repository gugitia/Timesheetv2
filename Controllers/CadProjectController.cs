using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;
using RestSharp;
using System.Threading;
using System.Data.SqlClient;
using System.Text.Json;
using System.Text.Json.Nodes;
using ProjetoTimesheet;
using ProjetoTimesheet.Models;

namespace CadTimesheetProject.Controllers
{
    [ApiController]
    [Route("/pr")]
    public class CadProjectController : ControllerBase
    {
        [HttpPost("CadProject")]

        public async Task<string> CadProject()
        {
            var Con = new Conexãobanco();
            Object[] dadosmanager = new Object[21];
            dadosmanager = (object[])Con.getData();

            RestClient client = new("http://projetos.gateware.com.br:8000/intranet-rest/im_project?format=json");
            var request = new RestRequest();

            var dadosjson = new NovoProjeto
            {
              project_name = Convert.ToString(dadosmanager[5]),
              project_nr = Convert.ToInt32(dadosmanager[8]),
              company_name = Convert.ToInt32(dadosmanager[21]),
              project_type = Convert.ToString(dadosmanager[9]),
              project_status = Convert.ToString(dadosmanager[10]),
              start_date_formatted = Convert.ToDateTime(dadosmanager[6]),
              end_date_formatted = Convert.ToDateTime(dadosmanager[7])
            };

            Console.WriteLine(dadosjson);

            request.AddHeader("Authorization", "Basic Z3VzdGF2by5yaWJlaXJvQGdhdGV3YXJlLmNvbS5icjpnd0BHdXN0YXZvMzA3Mw==");
            request.AddHeader("Cookie", "ad_session_id=\"833158%252c0%252c0%252c1670933700%2b%257b303%2b1670934900%2b0D1818031768B7A957A415E469A864B5276D239B%257d\"");
            request.AddJsonBody(dadosjson);

            try
            {
                RestResponse response = await client.PostAsync(request);
                return(response.Content);
            }
            catch (Exception error)
            {
                return error.Message;
            }

        }

    }

}

