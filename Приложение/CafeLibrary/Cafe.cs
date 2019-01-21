using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CafeLibrary
{
    public class Cafe
    {
        //static private string connString = "Data Source=DESKTOP-5E5L14V;Initial Catalog=cafe;Integrated Security=True";
        public int idcafe { get; set; }
        public string owner { get; set; }
        public string title { get; set; }
        public string address { get; set; }
        public int? phone { get; set; }
        public int? rating { get; set; }

        private static Cafe Read(SqlDataReader cafeReader)
        {
            Cafe newOne = new Cafe();
            newOne.idcafe = cafeReader.GetInt32(0);
            newOne.owner = cafeReader.GetString(1);
            newOne.title = cafeReader.GetString(2);
            newOne.address = cafeReader.GetString(3);
            try
            {
                newOne.phone = cafeReader.GetInt32(4);
            }
            catch (System.Data.SqlTypes.SqlNullValueException)
            {
                newOne.phone = null;
            }
            try
            {
                newOne.rating = cafeReader.GetInt32(5);
            }
            catch (System.Data.SqlTypes.SqlNullValueException)
            {
                newOne.rating = null;
            }
            return newOne;
        }
        public static List<Cafe> Get()//считываем с БД
        {
            ConnectionString str = new ConnectionString();
            SqlConnection conn = new SqlConnection();
            str.Open(conn);
            SqlCommand cmd = new SqlCommand("SELECT idcafe, owner, title, address, phone, rating FROM cafe", conn);

            //conn.Open();
            SqlDataReader cafeReader = cmd.ExecuteReader();
            List<Cafe> cafes = new List<Cafe>();
            while (cafeReader.Read())
            {
                cafes.Add(Read(cafeReader));
            }
            cafeReader.Close();
            conn.Close();

            return cafes;
        }
        public static Cafe Get(int cafeId)
        {
            ConnectionString str = new ConnectionString();
            SqlConnection conn = new SqlConnection();
            str.Open(conn);
            SqlCommand cmd = new SqlCommand("SELECT idcafe, owner, title, address, phone, rating FROM cafe", conn);
            Cafe cafe;

            //conn.Open();
            SqlDataReader cafeReader = cmd.ExecuteReader();

            while (cafeReader.Read())
            {
                int currID = cafeReader.GetInt32(0);
                if (currID != cafeId)
                    continue;
                cafe = Read(cafeReader);
                cafeReader.Close();
                conn.Close();
                return cafe;
            }
            cafeReader.Close();
            conn.Close();
            throw new System.MissingMemberException();
        }
        public static void Insert(Cafe cafe)//добавить
        {
            ConnectionString str = new ConnectionString();
            SqlConnection conn = new SqlConnection();
            str.Open(conn);
            SqlCommand cmd = new SqlCommand("", conn);

            cmd.CommandText = "INSERT INTO cafe(owner, title, address";
            string values = "VALUES( @_owner, @_title, @_address";

            cmd.Parameters.AddWithValue("_owner", cafe.owner);
            cmd.Parameters.AddWithValue("_title", cafe.title);
            cmd.Parameters.AddWithValue("_address", cafe.address);
            if (cafe.phone != null)
            {
                cmd.CommandText += ", phone";
                values += ", @_phone";
                cmd.Parameters.AddWithValue("_phone", cafe.phone);
            }
            if (cafe.rating != null)
            {
                cmd.CommandText += ", rating";
                values += ", @_rating";
                cmd.Parameters.AddWithValue("_rating", cafe.rating);
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

            cmd.CommandText = @"DELETE FROM cafe WHERE idcafe = @id
                                DELETE FROM supplier WHERE supplier.cafe_idcafe = @id
                                DELETE FROM dish WHERE dish.cafe_idcafe = @id
                                DELETE FROM serve WHERE serve.cafe_idcafe = @id";
            cmd.Parameters.AddWithValue("id", id);

            //conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void Update(int id, Cafe newCafe)
        {

            ConnectionString str = new ConnectionString();
            SqlConnection conn = new SqlConnection();
            str.Open(conn);
            SqlCommand cmd = new SqlCommand("", conn);

            cmd.CommandText = "Update cafe SET owner = @_owner, title = @_title, address = @_address";
            cmd.Parameters.AddWithValue("_owner", newCafe.owner);
            cmd.Parameters.AddWithValue("_title", newCafe.title);
            cmd.Parameters.AddWithValue("_address", newCafe.address);
            if (newCafe.phone != null)
            {
                cmd.CommandText += ", phone = @_phone";
                cmd.Parameters.AddWithValue("_phone", newCafe.phone);
            }
            else
            {
                cmd.CommandText += ", phone = NULL";
            }
            if (newCafe.rating != null)
            {
                cmd.CommandText += ", rating = @_rating";
                cmd.Parameters.AddWithValue("_rating", newCafe.rating);
            }
            else
            {
                cmd.CommandText += ", rating = NULL";
            }

            cmd.CommandText += " WHERE idcafe = @id";
            cmd.Parameters.AddWithValue("id", id);

            //conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static int GetPostCafe(int cafeID)
        {
            ConnectionString str = new ConnectionString();
            SqlConnection conn = new SqlConnection();
            str.Open(conn);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandText = "select s.[средняя зп] from salarylist as s where s.idcafe = @cafeID";
            cmd.Parameters.AddWithValue("cafeID", cafeID);
            //conn.Open();
            int result = (int)cmd.ExecuteScalar();
            conn.Close();
            return result;
        }

        public static int GetCountServe(int cafeID)
        {
            ConnectionString str = new ConnectionString();
            SqlConnection conn = new SqlConnection();
            str.Open(conn);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandText = "EXEC CountServe @cafeID";
            cmd.Parameters.AddWithValue("cafeID", cafeID);
            //conn.Open();
            int result = (int)cmd.ExecuteScalar();
            conn.Close();
            return result;
        }

        //--------------------ФУНКЦИИ ДЛЯ ИМПОРТА--------------------------------------
        public void change(int id, Cafe newCafe)
        {
            ConnectionString str = new ConnectionString();
            SqlConnection conn = new SqlConnection();
            str.Open(conn);
            SqlCommand cmd = new SqlCommand("", conn);

            cmd.CommandText = "Update cafe SET owner = @_owner, title = @_title, address = @_address";
            cmd.Parameters.AddWithValue("_owner", newCafe.owner);
            cmd.Parameters.AddWithValue("_title", newCafe.title);
            cmd.Parameters.AddWithValue("_address", newCafe.address);
            if (newCafe.phone != null)
            {
                cmd.CommandText += ", phone = @_phone";
                cmd.Parameters.AddWithValue("_phone", newCafe.phone);
            }
            else
            {
                cmd.CommandText += ", phone = NULL";
            }
            if (newCafe.rating != null)
            {
                cmd.CommandText += ", rating = @_rating";
                cmd.Parameters.AddWithValue("_rating", newCafe.rating);
            }
            else
            {
                cmd.CommandText += ", rating = NULL";
            }

            cmd.CommandText += " WHERE idcafe = @id";
            cmd.Parameters.AddWithValue("id", id);

            //conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void add( Cafe cafe)
        {
            ConnectionString str = new ConnectionString();
            SqlConnection conn = new SqlConnection();
            str.Open(conn);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandText = "INSERT INTO cafe(owner, title, address";
            string values = "VALUES( @_owner, @_title, @_address";

            cmd.Parameters.AddWithValue("_owner", cafe.owner);
            cmd.Parameters.AddWithValue("_title", cafe.title);
            cmd.Parameters.AddWithValue("_address", cafe.address);
            if (cafe.phone != null)
            {
                cmd.CommandText += ", phone";
                values += ", @_phone";
                cmd.Parameters.AddWithValue("_phone", cafe.phone);
            }
            if (cafe.rating != null)
            {
                cmd.CommandText += ", rating";
                values += ", @_rating";
                cmd.Parameters.AddWithValue("_rating", cafe.rating);
            }
            cmd.CommandText += ") " + values + ");";
            //conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public Cafe search(string address)
        {
            ConnectionString str = new ConnectionString();
            SqlConnection conn = new SqlConnection();
            str.Open(conn);
            SqlCommand cmd = new SqlCommand("SELECT * FROM cafe WHERE cafe.address = @address ", conn);
            cmd.Parameters.AddWithValue("address", address);

            //conn.Open();
            SqlDataReader cafeReader = cmd.ExecuteReader();
            if (cafeReader.Read())
            {
                return Read(cafeReader);
            }
            else
                return null;
        }
    }
}







