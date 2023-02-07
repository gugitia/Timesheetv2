using RestSharp;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;
using System.Threading;
using System.Data.SqlClient;
using System.Text.Json;
using System.Text.Json.Nodes;
using ProjetoTimesheet;

namespace ProjetoTimesheet.Models
{
    public class Conexãobanco
    {
        public object getData()
        {
            try
            {
                string connectionString;
                SqlConnection cnn;
                connectionString = @"Data Source=10.41.102.8,49907;Initial Catalog=ORQUESTRA_381_FLUXOS_RAFA;User ID=sa;pwd=@d!ls0n";
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                Console.WriteLine("conexão sucedida");
                SqlCommand objVerif = new SqlCommand("select * from [ORQUESTRA_381_DEV].[dbo].[wVFlow_Form_Execute_TimeSheet] where CodFlowExecute = 2558", cnn);
                SqlDataReader reader = objVerif.ExecuteReader();
                reader.Read();
                Object[] dados = new Object[reader.FieldCount];

                reader.GetValues(dados);
                reader.Close();
                cnn.Close();
                return dados;
            }

            catch (Exception erro)
            {
                Console.WriteLine("erro de codigo " + erro);
                string error = erro.Message;
                
                return error;
            }

        }

        public int ConversaoTipoEmpresas()
        {

            Object[] dadosmanager = new Object[21];
            dadosmanager = (object[])getData();
            var tipo = Convert.ToString(dadosmanager[15]);
            int tipoC = 0;


            //Conversões de tipos de empresa em IDs
            if (tipo == "Other")
            {
                tipoC = 52;
            }
            if (tipo == "Interno")
            {
                tipoC = 53;
            }
            if (tipo == "MVL Translation Agency")
            {
                tipoC = 54;
            }
            if (tipo == "Software Company")
            {
                tipoC = 55;
            }
            if (tipo == "Provider")
            {
                tipoC = 56;
            }
            if (tipo == "Cliente")
            {
                 tipoC = 57;
            }
            if (tipo == "Fornecedor Frelance")
            {
                tipoC = 58;
            }
            if (tipo == "Office Equipment Provider")
            {
                tipoC = 59;
            }
            if (tipo == "Juridico Da Empresa")
            {
                tipoC = 10244;
            }
            if (tipo == "Consultoria TI")
            {
                tipoC = 10245;
            }

            
            return tipoC;
            //Fim das conversõoes de tipo em id
        }
        //Inicio das conversoes de status em id
        public int conversaoStatusEmpresa()
        {
            Object[] dadosmanager = new Object[21];
            dadosmanager = (object[])getData();
            string status = Convert.ToString(dadosmanager[14]);
            int statusC = 0;

            if (status == "Ativo ou Potencial")
            {
                statusC = 40;
            }
            if (status == "Potencial")
            {
                statusC = 41;
            }
            if (status == "Consultas")
            {
                statusC = 42;
            }
            if (status == "Em Analise")
            {
                statusC = 43;
            }
            if (status == "Cotando")
            {
                statusC = 44;
            }
            if (status == "Quote out")
            {
                statusC = 45;
            }
            if (status == "Ativo")
            {
                statusC = 46;
            }
            if (status == "Recusado")
            {
                statusC = 47;
            }
            if (status == "Inativo")
            {
                statusC = 48;
            }
            if (status == "Apagado")
            {
                statusC = 49;
            }

            return statusC;

            //Fim da Conversão de status em IDs
        }
        }

    }

