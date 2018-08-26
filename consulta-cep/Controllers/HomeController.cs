/*
 * Created by SharpDevelop.
 * User: dv-me
 * Date: 25/08/2018
 * Time: 13:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Web.Mvc;
using Microsoft.CSharp.RuntimeBinder;
using System.Net;
using Microsoft.CSharp;
using Newtonsoft.Json;
using System.IO;
using consulta_cep.Model;
using System.Collections.Generic;

namespace consulta_cep.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{

            /*
            string json = @"{
                          'Name': 'Bad Boys',
                          'ReleaseDate': '1995-4-7T00:00:00'
                        }";


            Dados m = JsonConvert.DeserializeObject<Dados>(json);

            Response.Write(m.Name); */

            if (Request.RequestType == "POST")

            {

                string cepParametro = Request.Form["cep"];
                if (!String.IsNullOrEmpty(cepParametro)){
                    string ApiBaseUrl = "https://viacep.com.br/ws/"; // endereço da sua api
                    string MetodoPath = cepParametro + "/json/"; //caminho do método a ser chamado

                    var model = new Cep();
                    try
                    {
                        var httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiBaseUrl + MetodoPath);
                        httpWebRequest.ContentType = "application/json";
                        httpWebRequest.Method = "GET";

                        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            Cep retorno = JsonConvert.DeserializeObject<Cep>(streamReader.ReadToEnd());


                            ViewBag.cep = retorno.cep;
                            ViewBag.logradouro = retorno.logradouro;
                            ViewBag.complemento = retorno.complemento;
                            ViewBag.bairro = retorno.bairro;
                            ViewBag.localidade = retorno.localidade;
                            ViewBag.uf = retorno.uf;
                            ViewBag.gia = retorno.gia;
                            ViewBag.unidade = retorno.unidade;
                            ViewBag.ibge = retorno.ibge;
                            
                        }
                    }
                    catch (Exception e)
                    {

                        ViewBag.erro = "Ocorreu um erro ao buscar os dados do cep informado. Por favor, tente novamente.";
                    }
                }

            }
            return View();
		}


        
		
		public ActionResult Contact()
		{
			return View();
		}






	}
}
