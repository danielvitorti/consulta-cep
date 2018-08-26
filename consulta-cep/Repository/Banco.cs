using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace consulta_cep.Repository
{
    public class Banco
    {


        public static string CaminhoDadosXML(string caminho)
        {
            if (caminho.IndexOf("\\bin\\Debug") != 0)
            {
                caminho = caminho.Replace("\\bin\\Debug", "");
            }
            return caminho;
        }

    }
}