using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CafeLibrary
{
    public class Dish
    {
        //static private string connString = "Data Source=DESKTOP-5E5L14V;Initial Catalog=cafe;Integrated Security=True";
        public int iddish { get; set; }
        public string title { get; set; }
        public int quantily { get; set; }
        public Cafe cafe { get; set; }

        private static Dish Read(SqlDataReader dishReader)
        {
            Dish newOne = new Dish();
            newOne.iddish = dishReader.GetInt32(0);
            newOne.title = dishReader.GetString(1);
            newOne.quantily = dishReader.GetInt32(2);
            newOne.cafe = Cafe.Get(dishReader.GetInt32(3));
            return newOne;
        }
        public static List<Dish> Get()
        {
            ConnectionString str = new ConnectionString();
            SqlConnection conn = new SqlConnection();
            str.Open(conn);
            SqlCommand cmd = new SqlCommand("SELECT * FROM dish", conn);

            //conn.Open();
            SqlDataReader dishReader = cmd.ExecuteReader();
            List<Dish> dishs = new List<Dish>();
            while (dishReader.Read())
            {
                dishs.Add(Read(dishReader));
            }
            dishReader.Close();
            conn.Close();

            return dishs;
        }

        public static Dish Get(int dishId)
        {
            ConnectionString str = new ConnectionString();
            SqlConnection conn = new SqlConnection();
            str.Open(conn);
            SqlCommand cmd = new SqlCommand("SELECT * FROM dish", conn);
            Dish dish;

            //conn.Open();
            SqlDataReader dishReader = cmd.ExecuteReader();

            while (dishReader.Read())
            {
                int currID = dishReader.GetInt32(0);
                if (currID != dishId)
                    continue;
                dish = Read(dishReader);
                dishReader.Close();
                conn.Close();
                return dish;
            }
            dishReader.Close();
            conn.Close();
            throw new System.MissingMemberException();
        }

        public static void Insert(Dish dish)
        {
            ConnectionString str = new ConnectionString();
            SqlConnection conn = new SqlConnection();
            str.Open(conn);
            SqlCommand cmd = new SqlCommand("", conn);

            cmd.CommandText = "INSERT INTO dish(title, quantily, cafe_idcafe) VALUES(@_title, @_quantily, @_cafe_idcafe)";
            //string values = "VALUES(@id_dish, @_title, @_quantily";
            //cmd.Parameters.AddWithValue("id_dish", dish.iddish);
            cmd.Parameters.AddWithValue("_title", dish.title);
            cmd.Parameters.AddWithValue("_quantily", dish.quantily);
            cmd.Parameters.AddWithValue("_cafe_idcafe", dish.cafe.idcafe);
            //cmd.CommandText += ") " + values + ");";

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

            cmd.CommandText = @"DELETE FROM dish
                                WHERE iddish = @id";
            cmd.Parameters.AddWithValue("id", id);

            //conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void Update(int id, Dish newDish)
        {
            ConnectionString str = new ConnectionString();
            SqlConnection conn = new SqlConnection();
            str.Open(conn);
            SqlCommand cmd = new SqlCommand("", conn);

            cmd.CommandText = "Update dish SET title = @_title, quantily = @_quantily, cafe_idcafe = @_cafe_idcafe";
            cmd.Parameters.AddWithValue("_title", newDish.title);
            cmd.Parameters.AddWithValue("_quantily", newDish.quantily);
            cmd.Parameters.AddWithValue("_cafe_idcafe", newDish.cafe.idcafe);

            cmd.CommandText += " WHERE iddish = @id";
            cmd.Parameters.AddWithValue("id", id);

            //conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

       
    }
}
