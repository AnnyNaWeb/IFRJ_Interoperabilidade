using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Interoperabilidade.DAO.xml;

namespace Interoperabilidade
{
    public partial class TesteXML : System.Web.UI.Page
    {
        public String caminho = @"C:\Users\sousa\Faculdade\Interoperabilidade\aula.xml";
        protected void Page_Load(object sender, EventArgs e)
        {
            FabricaXML fXML = new FabricaXML();
           // fXML.escreverXML();
            String xml = fXML.lerXMLDeArquivo(caminho);

            txtXML.Text = xml;
            gdvPessoas.DataSource = fXML.converterXMLParaObjeto(xml);
            gdvPessoas.DataBind();
        }
    }
}