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
        private SqlConnection con = new SqlConnection(@"Data Source=REPEDA-DCG55M2\SQLEXPRESS02;Initial Catalog=AnnuaireContacts;Integrated Security=True");
        String requete;

        public User RecupererUser(String email, String password)
        {
            User u = new User();

            con.Open();
            requete = "SELECT * FROM Users WHERE email = '" + email + "' AND password = '" + password + "'";
            SqlCommand req = new SqlCommand(requete, con);
            SqlDataReader r = req.ExecuteReader();
            if (r.HasRows)
            {
                r.Read();
                u.id = (int)r.GetValue(r.GetOrdinal("id"));
                u.name = (String)r.GetValue(r.GetOrdinal("name"));
                u.email = (String)r.GetValue(r.GetOrdinal("email"));
                u.password = (String)r.GetValue(r.GetOrdinal("password"));
            }
            r.Close();
            con.Close();

            return u;
        }

        public void EnregistrerUser(User u)
        {
            con.Open();
            SqlCommand req=new SqlCommand("INSERT INTO Users (id, name, email, password) VALUES (@id, @name, @email, @password)", con);
            req.Parameters.Add("@id", SqlDbType.Int);
            req.Parameters["@id"].Value = u.id;
            req.Parameters.Add("@name", SqlDbType.VarChar);
            req.Parameters["@name"].Value = u.name;
            req.Parameters.Add("@email", SqlDbType.VarChar);
            req.Parameters["@email"].Value = u.email;
            req.Parameters.Add("@password", SqlDbType.VarChar);
            req.Parameters["@password"].Value = u.password;
            req.ExecuteNonQuery();
            con.Close();
        }

        public void ModifierUser(User u, long id)
        {
            con.Open();
            SqlCommand req = new SqlCommand("Update Users SET id = @id, name = @name, email = @email, password = @password WHERE id = @id2", con);
            req.Parameters.Add("@id", SqlDbType.Int);
            req.Parameters["@id"].Value = u.id;
            req.Parameters.Add("@name", SqlDbType.VarChar);
            req.Parameters["@name"].Value = u.name;
            req.Parameters.Add("@email", SqlDbType.VarChar);
            req.Parameters["@email"].Value = u.email;
            req.Parameters.Add("@password", SqlDbType.VarChar);
            req.Parameters["@password"].Value = u.password;
            req.Parameters.Add("@id2", SqlDbType.Int);
            req.Parameters["@id2"].Value = id;
            req.ExecuteNonQuery();
            con.Close();
        }

        public void EnregistrerContact(Contact c)
        {
            con.Open();
            SqlCommand req = new SqlCommand("INSERT INTO Contacts (id, first_name, last_name, favorite, email, phone, user_id) VALUES (@id, @first_name, @last_name, @favorite, @email, @phone, @user_id)", con);
            req.Parameters.Add("@id", SqlDbType.Int);
            req.Parameters["@id"].Value = c.id;
            req.Parameters.Add("@first_name", SqlDbType.VarChar);
            req.Parameters["@first_name"].Value = c.first_name;
            req.Parameters.Add("@last_name", SqlDbType.VarChar);
            req.Parameters["@last_name"].Value = c.last_name;
            req.Parameters.Add("@favorite", SqlDbType.TinyInt);
            req.Parameters["@favorite"].Value = c.favorite;
            req.Parameters.Add("@email", SqlDbType.VarChar);
            if (c.email != null)
            {
                req.Parameters["@email"].Value = c.email;
            }
            else
            {
                req.Parameters["@email"].Value = DBNull.Value;
            }
            req.Parameters.Add("@phone", SqlDbType.VarChar);
            if (c.phone != null)
            {
                req.Parameters["@phone"].Value = c.phone;
            }
            else
            {
                req.Parameters["@phone"].Value = DBNull.Value;
            }
            req.Parameters.Add("@user_id", SqlDbType.Int);
            req.Parameters["@user_id"].Value = c.user_id;
            req.ExecuteNonQuery();
            con.Close();
        }

        public void SupprimerContactsUser(long user_id)
        {
            con.Open();
            SqlCommand req = new SqlCommand("DELETE FROM Contacts WHERE user_id = @id", con);
            req.Parameters.Add("@id", SqlDbType.Int);
            req.Parameters["@id"].Value = user_id;
            req.ExecuteNonQuery();
            con.Close();
        }
    }
}