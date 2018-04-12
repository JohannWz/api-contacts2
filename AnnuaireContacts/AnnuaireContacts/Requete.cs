using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace api_contacts 
{
    public class Requete
    {
        private String uri = "https://api.nebulon.fr/api/v1/";
        private String json;
        private HttpWebRequest httpWebRequest;
        private String result;

        public Requete() {}

        public Boolean SeConnecter(Connexion c)
        {
            json = JsonConvert.SerializeObject(c);
            httpWebRequest = (HttpWebRequest)WebRequest.Create(uri + "authenticate");
            httpWebRequest.Method = "POST";
            return EnvoyerJson();
        }

        public Boolean RecupererContacts(String token)
        {
            httpWebRequest = (HttpWebRequest)WebRequest.Create(uri + "users/contacts");
            httpWebRequest.Method = "GET";
            httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            return Envoyer();
        }

        public Boolean RecupererContact(String token, long id)
        {
            httpWebRequest = (HttpWebRequest)WebRequest.Create(uri + "users/contacts/" + id);
            httpWebRequest.Method = "GET";
            httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            return Envoyer();
        }

        public Boolean AjouterContact(String token, Contact c)
        {
            json = JsonConvert.SerializeObject(c);
            // Suppression de l'id dans le json
            var o = (Newtonsoft.Json.Linq.JObject)JsonConvert.DeserializeObject(json);
            json = o.ToString();

            httpWebRequest = (HttpWebRequest)WebRequest.Create(uri + "users/contacts");
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            return EnvoyerJson();
        }

        public Boolean ModifierContact(String token, Contact c)
        {
            json = JsonConvert.SerializeObject(c);
            httpWebRequest = (HttpWebRequest)WebRequest.Create(uri + "users/contacts/" + c.id);
            httpWebRequest.Method = "PUT";
            httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            return EnvoyerJson();
        }

        public Boolean SupprimerContact(String token, double id)
        {
            httpWebRequest = (HttpWebRequest)WebRequest.Create(uri + "users/contacts/" + id);
            httpWebRequest.Method = "DELETE";
            httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            return Envoyer();
        }

        public Boolean EnvoyerJson()
        {
            StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream());
            streamWriter.Write(json);
            streamWriter.Flush();
            streamWriter.Close();

            return Envoyer();
        }

        public Boolean Envoyer()
        {
            try
            {
                httpWebRequest.ContentType = "application/json";
                HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream());
                result = streamReader.ReadToEnd();
                return true;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return false;
            }
        }

        public String GetResult()
        {
            return result;
        }
    }
}
