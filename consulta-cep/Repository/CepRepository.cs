using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using consulta_cep.Model;
using System.Xml;
using System.Xml.Linq;
using System.Data;

namespace consulta_cep.Repository
{
    public class CepRepository
    {

        public bool salvar(Cep cep)
        {
            bool retorno;
            using (DataSet dsResultado = new DataSet())
            {

                try
                {
                    string caminho = "";
                    XmlTextWriter writer = new XmlTextWriter(@"BaseCep.xml", System.Text.Encoding.UTF8);

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
                    dsResultado.ReadXml(Banco.CaminhoDadosXML(caminho) + @"Data\BaseCep.xml");


                    retorno = true;
                }
                catch (Exception e)
                {
                    retorno = false;
                }

                return retorno;
            }
        }
    }
}
