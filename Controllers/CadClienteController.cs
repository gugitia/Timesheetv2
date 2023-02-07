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

namespace CadTimesheetCliente.Controllers
{
    [ApiController]
    [Route("/cl")]
    public class CadClienteController : ControllerBase
    {
        [HttpPost("CadCliente")]

        public async Task<string> CadCliente()
        {
            var Con = new Conexãobanco();
            Object[] dadosmanager = new Object[21];
            dadosmanager = (object[])Con.getData();
           int tipoC = Con.ConversaoTipoEmpresas();
           int statusC = Con.conversaoStatusEmpresa();

            RestClient client = new("http://projetos.gateware.com.br:8000/intranet-rest/im_company?format=json");
            var request = new RestRequest();

            var dadosjson = new NovoCliente
            {
                company_name = Convert.ToString(dadosmanager[12]),
                company_path = Convert.ToString(dadosmanager[13]),
                company_status_id = statusC,
                company_type_id = tipoC
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

}


       

    

    


            