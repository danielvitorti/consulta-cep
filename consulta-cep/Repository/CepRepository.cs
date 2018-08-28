using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using consulta_cep.Model;
using System.Xml;
using System.Xml.Linq;
using System.Data;
using System.IO;

namespace consulta_cep.Repository
{
    public class CepRepository
    {



        private string caminhoArquivo { get; set; }







        public bool salvar(Cep cep)
        {
            bool retorno;


            try
            {



                string folder = @"C:\banco_cep";

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }


                XmlTextWriter writer = new XmlTextWriter(@"C:\banco_cep\BaseCep.xml", System.Text.Encoding.UTF8);


                writer.WriteStartDocument(true);
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 2;
                writer.WriteStartElement("CepRegistro");


                writer.WriteStartElement("cep");
                writer.WriteString(cep.cep);
                writer.WriteEndElement();

                writer.WriteStartElement("bairro");
                writer.WriteString(cep.bairro);
                writer.WriteEndElement();

                writer.WriteStartElement("complemento");
                writer.WriteString(cep.complemento);
                writer.WriteEndElement();


                writer.WriteStartElement("gia");
                writer.WriteString(cep.gia);
                writer.WriteEndElement();

                writer.WriteStartElement("ibge");
                writer.WriteString(cep.ibge);
                writer.WriteEndElement();

                writer.WriteStartElement("logradouro");
                writer.WriteString(cep.logradouro);
                writer.WriteEndElement();


                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();


                retorno = true;
            }
            catch (Exception e)
            {
                retorno = false;
            }

            return retorno;
        }



        public void verificarPorId(Cep cep)
        {




            XDocument xmldoc = XDocument.Load(@"C:\banco_cep\BaseCep.xml");

            XElement xelement = xmldoc.Descendants("cep").FirstOrDefault(p => p.Element("cep").Value == cep.cep);


            if (xelement != null)
            {

                xelement.Element("cep").Value = cep.cep;
                xelement.Element("bairro").Value = cep.bairro;
                xelement.Element("complemento").Value = cep.complemento;
                xelement.Element("gia").Value = cep.gia;
                xelement.Element("ibge").Value = cep.ibge;
                xelement.Element("logradouro").Value = cep.logradouro;
                xelement.Element("localidade").Value = cep.localidade;
                xmldoc.Root.Add(xelement);
                xmldoc.Save(@"C:\banco_cep\BaseCep.xml");

            }


        }





    }
}
    




      
    

