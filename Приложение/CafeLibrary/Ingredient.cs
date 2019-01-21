using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CafeLibrary
{
    public class Ingredient
    {
        //static private string connString = "Data Source=DESKTOP-5E5L14V;Initial Catalog=cafe;Integrated Security=True";
        public int idingredient { get; set; }
        public string product { get; set; }

        private static Ingredient Read(SqlDataReader ingReader)
        {
            Ingredient newOne = new Ingredient();
            newOne.idingredient = ingReader.GetInt32(0);
            newOne.product = ingReader.GetString(1);
            return newOne;
        }
        public static List<Ingredient> Get()
        {
            ConnectionString str = new ConnectionString();
            SqlConnection conn = new SqlConnection();
            str.Open(conn);
            SqlCommand cmd = new SqlCommand("SELECT idingredient, product FROM ingredient", conn);

            //conn.Open();
            SqlDataReader ingReader = cmd.ExecuteReader();
            List<Ingredient> ingredient = new List<Ingredient>();
            while (ingReader.Read())
            {
                ingredient.Add(Read(ingReader));
            }
            ingReader.Close();
            conn.Close();

            return ingredient;
        }
        public static Ingredient Get(int ingredientId)
        {
            ConnectionString str = new ConnectionString();
            SqlConnection conn = new SqlConnection();
            str.Open(conn);
            SqlCommand cmd = new SqlCommand("SELECT * FROM ingredient", conn);
            Ingredient ingredient;

            //conn.Open();
            SqlDataReader ingredientReader = cmd.ExecuteReader();

            while (ingredientReader.Read())
            {
                int currID = ingredientReader.GetInt32(0);
                if (currID != ingredientId)
                    continue;
                ingredient = Read(ingredientReader);
                ingredientReader.Close();
                conn.Close();
                return ingredient;
            }
            ingredientReader.Close();
            conn.Close();
            throw new System.MissingMemberException();
        }
        public static void Insert(Ingredient ingredient)
        {
            ConnectionString str = new ConnectionString();
            SqlConnection conn = new SqlConnection();
            str.Open(conn);
            SqlCommand cmd = new SqlCommand("", conn);

            cmd.CommandText = "INSERT INTO ingredient(product";
            string values = "VALUES( @_product";
            cmd.Parameters.AddWithValue("_product", ingredient.product);
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

            cmd.CommandText = @"DELETE FROM ingredient
                                WHERE idingredient = @id";
            cmd.Parameters.AddWithValue("id", id);

            //conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void Update(int id, Ingredient newIngredient)
        {
            ConnectionString str = new ConnectionString();
            SqlConnection conn = new SqlConnection();
            str.Open(conn);
            SqlCommand cmd = new SqlCommand("", conn);

            cmd.CommandText = "Update ingredient SET product = @_product";
            cmd.Parameters.AddWithValue("_product", newIngredient.product);
            cmd.CommandText += " WHERE idingredient = @id";
            cmd.Parameters.AddWithValue("id", id);
            //conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
