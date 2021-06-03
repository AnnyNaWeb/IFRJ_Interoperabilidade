using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using Interoperabilidade.DAO;
using Interoperabilidade.DAO.model;

namespace Interoperabilidade.DAO.xml
{
    public class FabricaXML
    {
        public void escreverXML()
        {
            XmlTextWriter writer = new XmlTextWriter(@"C:\Users\sousa\Faculdade\Interoperabilidade\aula.xml", null);
            writer.WriteStartDocument();
            writer.Formatting = Formatting.Indented;
            writer.WriteStartElement("PESSOAS");
            writer.WriteStartElement("PESSOA");
            writer.WriteElementString("ID","1");
            writer.WriteElementString("NOME", "JOÃO");
            writer.WriteElementString("IDADE", "13");
            writer.WriteElementString("CIDADE", "VOLTA REDONDA");
            writer.WriteEndElement();
            writer.WriteStartElement("PESSOA");
            writer.WriteElementString("ID", "2");
            writer.WriteElementString("NOME", "JÚLIA");
            writer.WriteElementString("IDADE", "17");
            writer.WriteElementString("CIDADE", "ENGENHEIRO PAULO DE FRONTIN");
            writer.WriteEndElement();
            writer.WriteFullEndElement();
            writer.Close();



        }

        public String lerXMLDeArquivo(String caminho)
        {
            return System.IO.File.ReadAllText(caminho);
        }

        public List<Pessoa> converterXMLParaObjeto(String xml)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(xml);
            MemoryStream stream = new MemoryStream(byteArray);

            XmlTextReader xtr = new XmlTextReader(stream);

            List<Pessoa> pessoas = new List<Pessoa>();
            Pessoa p;

            p = new Pessoa();

            while (xtr.Read())
            {
                if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "ID")
                {
                    p.id = xtr.ReadElementContentAsInt();

                }
                if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "NOME")
                {
                    p.nome = xtr.ReadElementContentAsString();

                }
                if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "IDADE")
                {
                    p.idade = xtr.ReadElementContentAsInt();

                }
                if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "CIDADE")
                {
                    p.cidade = xtr.ReadElementContentAsString();
                    pessoas.Add(p);
                    p = new Pessoa();
                }
            }
            return pessoas;
        }
    }
}