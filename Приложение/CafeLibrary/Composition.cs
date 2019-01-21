using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CafeLibrary
{
    public class Composition
    {
        //static private string connString = "Data Source=DESKTOP-5E5L14V;Initial Catalog=cafe;Integrated Security=True";
        public int idcomposition { get; set; }
        public int numingredient { get; set; }
        public Ingredient ingredient { get; set; }
        public Dish dish { get; set; }
        

        private static Composition Read(SqlDataReader comReader)
        {
            Composition newOne = new Composition();
            newOne.idcomposition = comReader.GetInt32(0);
            newOne.numingredient = comReader.GetInt32(1);
            newOne.ingredient = Ingredient.Get(comReader.GetInt32(2));
            newOne.dish = Dish.Get(comReader.GetInt32(3));
            return newOne;
        }
        public static List<Composition> Get()
        {
            ConnectionString str = new ConnectionString();
            SqlConnection conn = new SqlConnection();
            str.Open(conn);
            SqlCommand cmd = new SqlCommand("SELECT idcomposition, numingredient, ingredient_idingredient, dish_iddish FROM composition", conn);

            //conn.Open();
            SqlDataReader comReader = cmd.ExecuteReader();
            List<Composition> composition = new List<Composition>();
            while (comReader.Read())
            {
                composition.Add(Read(comReader));
            }
            comReader.Close();
            conn.Close();

            return composition;
        }
        
        public static void Insert(Composition composition)
        {
            ConnectionString str = new ConnectionString();
            SqlConnection conn = new SqlConnection();
            str.Open(conn);
            SqlCommand cmd = new SqlCommand("", conn);

            cmd.CommandText = "INSERT INTO composition(numingredient, ingredient_idingredient, dish_iddish";
            string values = "VALUES( @_numingredient, @_ingredient_idingredient, @_dish_iddish";
            cmd.Parameters.AddWithValue("_numingredient", composition.numingredient);
            cmd.Parameters.AddWithValue("_ingredient_idingredient", composition.ingredient.idingredient);
            cmd.Parameters.AddWithValue("_dish_iddish", composition.dish.iddish);
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

            cmd.CommandText = @"DELETE FROM composition
                                WHERE idcomposition = @id";
            cmd.Parameters.AddWithValue("id", id);

            //conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void Update(int id, Composition newComposition)
        {

            ConnectionString str = new ConnectionString();
            SqlConnection conn = new SqlConnection();
            str.Open(conn);
            SqlCommand cmd = new SqlCommand("", conn);

            cmd.CommandText = "Update composition SET numingredient = @_numingredient, ingredient_idingredient = @_ingredient_idingredient, dish_iddish = @_dish_iddish";
            cmd.Parameters.AddWithValue("_numingredient", newComposition.numingredient);
            cmd.Parameters.AddWithValue("_ingredient_idingredient", newComposition.ingredient.idingredient);
            cmd.Parameters.AddWithValue("_dish_iddish", newComposition.dish.iddish);
            cmd.CommandText += " WHERE idcomposition = @id";
            cmd.Parameters.AddWithValue("id", id);
            //conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
