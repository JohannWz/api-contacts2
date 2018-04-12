using api_contacts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AnnuaireContacts
{
    public class DataBase
    {
        private SqlConnection con = new SqlConnection(@"Data Source=REPEDA-DCG55M2\SQLEXPRESS02;Initial Catalog=AnnuaireContact;Integrated Security=True");

        public User RecupererUser(String email, String password)
        {
            User u = new User();

            con.Open();
            SqlCommand req = new SqlCommand("SELECT * FROM User WHERE email = '" + email + "' AND password = '" + password + "'", con);
            SqlDataReader r = req.ExecuteReader();
            if (r.HasRows)
            {
                r.Read();
                u.id = (long)r.GetValue(r.GetOrdinal("id"));
                u.name = (String)r.GetValue(r.GetOrdinal("name"));
                u.email = (String)r.GetValue(r.GetOrdinal("email"));
            }
            r.Close();

            return u;
        }

        public void EnregistrerUser(User u)
        {
            SqlCommand req=new SqlCommand("INSERT INTO User (id, name, email, password) VALUES (@id, @name, @email, @password)", con);
            req.Parameters.Add("@id", SqlDbType.Int);
            req.Parameters["@id"].Value = u.id;
            req.Parameters.Add("@name", SqlDbType.VarChar);
            req.Parameters["@name"].Value = u.name;
            req.Parameters.Add("@email", SqlDbType.VarChar);
            req.Parameters["@email"].Value = u.email;
            req.Parameters.Add("@password", SqlDbType.VarChar);
            req.Parameters["@password"].Value = u.password;
            req.ExecuteNonQuery();
        }
    }
}