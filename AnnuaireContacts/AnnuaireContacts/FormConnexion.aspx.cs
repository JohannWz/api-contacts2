﻿using api_contacts;
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
            DataBase db = new DataBase();
            User u = db.RecupererUser(tbEmail.Text, tbMdp.Text);

            // Si l'utilisateur est connecté via l'API
            if (connecte)
            {
                String json = maRequete.GetResult();
                FluxConnexion monFlux = JsonConvert.DeserializeObject<FluxConnexion>(json);

                // Si l'utilisateur n'existe pas en BDD locale
                if (u.name == null)
                {
                    u.id = monFlux.user.id;
                    u.name = monFlux.user.name;
                    u.email = monFlux.user.email;
                    u.password = tbMdp.Text;
                    db.EnregistrerUser(u);
                }
                // Si l'id user a changé (création d'un nouveau compte avec le même email et le même mot de passe)
                else if (u.id != monFlux.user.id)
                {
                    long old_id = u.id;
                    u.id = monFlux.user.id;
                    db.ModifierUser(u, old_id);
                }

                Session["FluxConnexion"] = monFlux;
                Response.Redirect("ListeContacts.aspx");
            } 
            else
            {
                // Si l'utilisateur est connecté en local              
                if (u != null)
                {
                    Session["User"] = u;
                    Response.Redirect("ListeContacts.aspx");
                }
            }
        }
    }
}