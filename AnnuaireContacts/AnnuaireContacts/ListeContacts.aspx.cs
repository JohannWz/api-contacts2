using api_contacts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnnuaireContacts
{
    public partial class ListeContacts : System.Web.UI.Page
    {
        private FluxConnexion monFlux;
        Requete maRequete = new Requete();

        protected void Page_Load(object sender, EventArgs e)
        {
            monFlux = (FluxConnexion)Session["FluxConnexion"];
            RemplirGv();
        }

        public void RemplirGv()
        {
            maRequete.RecupererContacts(monFlux.token);

            String json = maRequete.GetResult();
            List<Contact> lc = JsonConvert.DeserializeObject<List<Contact>>(json);
            gvContacts.DataSource = lc;
            gvContacts.DataBind();
        }

        protected void gvContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            String a = e.ToString();
            Response.Redirect("AfficherContact.aspx?id=" + gvContacts.SelectedRow.Cells[3].ToString());
        }
    }
}