using api_contacts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnnuaireContacts
{
    public partial class FormConnexion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void tbEnvoyer_Click(object sender, EventArgs e)
        {
            Connexion connexion = new Connexion(tbEmail.Text, tbMdp.Text);
            Requete maRequete = new Requete();
            Boolean connecte = maRequete.SeConnecter(connexion);

            if (connecte)
            {
                String json = maRequete.GetResult();
                FluxConnexion monFlux = JsonConvert.DeserializeObject<FluxConnexion>(json);

                Session["FluxConnexion"] = monFlux;
                Response.Redirect("ListeContacts.aspx");
            } 
            else
            {
                DataBase db = new DataBase();
                User u = db.RecupererUser(tbEmail.Text, tbMdp.Text);
                //if (u != null)

            }
        }
    }
}