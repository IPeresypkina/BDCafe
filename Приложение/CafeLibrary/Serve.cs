using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace CafeLibrary
{
    public class Serve
    {
        //static private string connString = "Data Source=DESKTOP-5E5L14V;Initial Catalog=cafe;Integrated Security=True";
        public int idserve { get; set; }
        public string name { get; set; }
        public int passport { get; set; }
        public string education { get; set; }
        public int experience { get; set; }
        public Cafe cafe { get; set; }

        private static Serve Read(SqlDataReader serReader)
        {
            Serve newOne = new Serve();
            newOne.idserve = serReader.GetInt32(0);
            newOne.name = serReader.GetString(1);
            newOne.passport = serReader.GetInt32(2);
            try
            {
                newOne.education = serReader.GetString(3);
            }
            catch (System.Data.SqlTypes.SqlNullValueException)
            {
                newOne.education = null;
            }
            newOne.experience = serReader.GetInt32(4);
            newOne.cafe = Cafe.Get(serReader.GetInt32(5));
            //newOne.cafe_idcafe = serReader.GetInt32(5);

            return newOne;
        }
        public static List<Serve> Get()
        {
            ConnectionString str = new ConnectionString();
            SqlConnection conn = new SqlConnection();
            str.Open(conn);
            SqlCommand cmd = new SqlCommand("SELECT * FROM serve", conn);

            //conn.Open();
            SqlDataReader serReader = cmd.ExecuteReader();
            List<Serve> serves = new List<Serve>();
            while (serReader.Read())
            {
                serves.Add(Read(serReader));
            }
            serReader.Close();
            conn.Close();

            return serves;
        }
        public static Serve Get(int serveId)
        {
            ConnectionString str = new ConnectionString();
            SqlConnection conn = new SqlConnection();
            str.Open(conn);
            SqlCommand cmd = new SqlCommand("SELECT * FROM serve", conn);
            Serve serve;

            //conn.Open();
            SqlDataReader serveReader = cmd.ExecuteReader();

            while (serveReader.Read())
            {
                int currID = serveReader.GetInt32(0);
                if (currID != serveId)
                    continue;
                serve = Read(serveReader);
                serveReader.Close();
                conn.Close();
                return serve;
            }
            serveReader.Close();
            conn.Close();
            throw new System.MissingMemberException();
        }
        public static void Insert(Serve serve)
        {
            ConnectionString str = new ConnectionString();
            SqlConnection conn = new SqlConnection();
            str.Open(conn);
            SqlCommand cmd = new SqlCommand("", conn);

            cmd.CommandText = "INSERT INTO serve(name, passport, experience, cafe_idcafe";
            string values = "VALUES( @_name, @_passport, @_experience, @_cafe_idcafe";
            cmd.Parameters.AddWithValue("_name", serve.name);
            cmd.Parameters.AddWithValue("_passport", serve.passport);
            cmd.Parameters.AddWithValue("_experience", serve.experience);
            cmd.Parameters.AddWithValue("_cafe_idcafe", serve.cafe.idcafe);
            if (serve.education != null)
            {
                cmd.CommandText += ", education";
                values += ", @_education";
                cmd.Parameters.AddWithValue("_education", serve.education);
            }
            cmd.CommandText += ") " + values + ");";

            //conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void Delete(int id)
        {
            ConnectionString str = new ConnectionString();
            SqlConnection conn = new SqlConnection();
            str.Open(conn);
            SqlCommand cmd = new SqlCommand("", conn);

            cmd.CommandText = @"DELETE FROM serve
                                WHERE idserve = @id";
            cmd.Parameters.AddWithValue("id", id);

            //conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void Update(int id, Serve newServe)
        {
            ConnectionString str = new ConnectionString();
            SqlConnection conn = new SqlConnection();
            str.Open(conn);
            SqlCommand cmd = new SqlCommand("", conn);

            cmd.CommandText = "Update serve SET name = @_name, passport = @_passport, experience = @_experience, cafe_idcafe = @_cafe_idcafe";
            cmd.Parameters.AddWithValue("_name", newServe.name);
            cmd.Parameters.AddWithValue("_passport", newServe.passport);
            cmd.Parameters.AddWithValue("_experience", newServe.experience);
            cmd.Parameters.AddWithValue("_cafe_idcafe", newServe.cafe.idcafe);
            if (newServe.education != null)
            {
                cmd.CommandText += ", education = @_education";
                cmd.Parameters.AddWithValue("_education", newServe.education);
            }
            else
            {
                cmd.CommandText += ", education = NULL";
            }
            cmd.CommandText += " WHERE idserve = @id";
            cmd.Parameters.AddWithValue("id", id);

            //conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
