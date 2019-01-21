using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CafeLibrary
{
    public class Supplier
    {
        //static private string connString = "Data Source=DESKTOP-5E5L14V;Initial Catalog=cafe;Integrated Security=True";
        public int idsupplier { get; set; }
        public string title { get; set; }
        public string product { get; set; }
        public int? FrequencyOfDeliveries { get; set; }
        public int? VolumeOfDeliveries { get; set; }
        public Cafe cafe { get; set; }

        private static Supplier Read(SqlDataReader supReader)
        {
            Supplier newOne = new Supplier();
            newOne.idsupplier = supReader.GetInt32(0);
            newOne.title = supReader.GetString(1);
            newOne.product = supReader.GetString(2);
            try
            {
                newOne.FrequencyOfDeliveries = supReader.GetInt32(3);
            }
            catch (System.Data.SqlTypes.SqlNullValueException)
            {
                newOne.FrequencyOfDeliveries = null;
            }
            try
            {
                newOne.VolumeOfDeliveries = supReader.GetInt32(4);
            }
            catch (System.Data.SqlTypes.SqlNullValueException)
            {
                newOne.VolumeOfDeliveries = null;
            }
            newOne.cafe = Cafe.Get(supReader.GetInt32(5));
            //newOne.cafe_idcafe = supReader.GetInt32(5);
            
            return newOne;
        }
        public static List<Supplier> Get()
        {
            ConnectionString str = new ConnectionString();
            SqlConnection conn = new SqlConnection();
            str.Open(conn);
            SqlCommand cmd = new SqlCommand("SELECT * FROM supplier", conn);

            //conn.Open();
            SqlDataReader supReader = cmd.ExecuteReader();
            List<Supplier> suppliers = new List<Supplier>();
            while (supReader.Read())
            {
                suppliers.Add(Read(supReader));
            }
            supReader.Close();
            conn.Close();

            return suppliers;
        }
        
        public static void Insert(Supplier supplier)
        {
            ConnectionString str = new ConnectionString();
            SqlConnection conn = new SqlConnection();
            str.Open(conn);
            SqlCommand cmd = new SqlCommand("", conn);

            cmd.CommandText = "INSERT INTO supplier( title, product, cafe_idcafe";
            string values = "VALUES( @_title, @_product, @_cafe_idcafe";
            cmd.Parameters.AddWithValue("_title", supplier.title);
            cmd.Parameters.AddWithValue("_product", supplier.product);
            cmd.Parameters.AddWithValue("_cafe_idcafe", supplier.cafe.idcafe);
            if (supplier.FrequencyOfDeliveries != null)
            {
                cmd.CommandText += ", FrequencyOfDeliveries";
                values += ", @_FrequencyOfDeliveries";
                cmd.Parameters.AddWithValue("_FrequencyOfDeliveries", supplier.FrequencyOfDeliveries);
            }
            if (supplier.VolumeOfDeliveries != null)
            {
                cmd.CommandText += ", VolumeOfDeliveries";
                values += ", @_VolumeOfDeliveries";
                cmd.Parameters.AddWithValue("_VolumeOfDeliveries", supplier.VolumeOfDeliveries);
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

            cmd.CommandText = @"DELETE FROM supplier
                                WHERE idsupplier = @id";
            cmd.Parameters.AddWithValue("id", id);

            //conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void Update(int id, Supplier newSupplier)
        {
            ConnectionString str = new ConnectionString();
            SqlConnection conn = new SqlConnection();
            str.Open(conn);
            SqlCommand cmd = new SqlCommand("", conn);

            cmd.CommandText = "Update supplier SET title = @_title, product = @_product, cafe_idcafe = @_cafe_idcafe";
            cmd.Parameters.AddWithValue("_title", newSupplier.title);
            cmd.Parameters.AddWithValue("_product", newSupplier.product);
            cmd.Parameters.AddWithValue("_cafe_idcafe", newSupplier.cafe.idcafe);
            if (newSupplier.FrequencyOfDeliveries != null)
            {
                cmd.CommandText += ", FrequencyOfDeliveries = @_FrequencyOfDeliveries";
                cmd.Parameters.AddWithValue("_FrequencyOfDeliveries", newSupplier.FrequencyOfDeliveries);
            }
            else
            {
                cmd.CommandText += ", FrequencyOfDeliveries = NULL";
            }
            if (newSupplier.VolumeOfDeliveries != null)
            {
                cmd.CommandText += ", VolumeOfDeliveries = @_VolumeOfDeliveries";
                cmd.Parameters.AddWithValue("_VolumeOfDeliveries", newSupplier.VolumeOfDeliveries);
            }
            else
            {
                cmd.CommandText += ", VolumeOfDeliveries = NULL";
            }
     
            cmd.CommandText += " WHERE idsupplier = @id";
            cmd.Parameters.AddWithValue("id", id);

            //conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        //--------------------ФУНКЦИИ ДЛЯ ИМПОРТА--------------------------------------
        public void change(int id, Supplier newSupplier)
        {
            ConnectionString str = new ConnectionString();
            SqlConnection conn = new SqlConnection();
            str.Open(conn);
            SqlCommand cmd = new SqlCommand("", conn);

            cmd.CommandText = "Update supplier SET title = @_title, product = @_product, cafe_idcafe = @_cafe_idcafe";
            cmd.Parameters.AddWithValue("_title", newSupplier.title);
            cmd.Parameters.AddWithValue("_product", newSupplier.product);
            cmd.Parameters.AddWithValue("_cafe_idcafe", newSupplier.cafe.idcafe);
            if (newSupplier.FrequencyOfDeliveries != null)
            {
                cmd.CommandText += ", FrequencyOfDeliveries = @_FrequencyOfDeliveries";
                cmd.Parameters.AddWithValue("_FrequencyOfDeliveries", newSupplier.FrequencyOfDeliveries);
            }
            else
            {
                cmd.CommandText += ", FrequencyOfDeliveries = NULL";
            }
            if (newSupplier.VolumeOfDeliveries != null)
            {
                cmd.CommandText += ", VolumeOfDeliveries = @_VolumeOfDeliveries";
                cmd.Parameters.AddWithValue("_VolumeOfDeliveries", newSupplier.VolumeOfDeliveries);
            }
            else
            {
                cmd.CommandText += ", VolumeOfDeliveries = NULL";
            }

            cmd.CommandText += " WHERE idsupplier = @id";
            cmd.Parameters.AddWithValue("id", id);

            //conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void add(Supplier supplier)
        {
            ConnectionString str = new ConnectionString();
            SqlConnection conn = new SqlConnection();
            str.Open(conn);
            SqlCommand cmd = new SqlCommand("", conn);

            cmd.CommandText = "INSERT INTO supplier( title, product, cafe_idcafe";
            string values = "VALUES( @_title, @_product, @_cafe_idcafe";
            cmd.Parameters.AddWithValue("_title", supplier.title);
            cmd.Parameters.AddWithValue("_product", supplier.product);
            cmd.Parameters.AddWithValue("_cafe_idcafe", supplier.cafe.idcafe);
            if (supplier.FrequencyOfDeliveries != null)
            {
                cmd.CommandText += ", FrequencyOfDeliveries";
                values += ", @_FrequencyOfDeliveries";
                cmd.Parameters.AddWithValue("_FrequencyOfDeliveries", supplier.FrequencyOfDeliveries);
            }
            if (supplier.VolumeOfDeliveries != null)
            {
                cmd.CommandText += ", VolumeOfDeliveries";
                values += ", @_VolumeOfDeliveries";
                cmd.Parameters.AddWithValue("_VolumeOfDeliveries", supplier.VolumeOfDeliveries);
            }
            cmd.CommandText += ") " + values + ");";

            //conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public Supplier search(string title)
        {
            ConnectionString str = new ConnectionString();
            SqlConnection conn = new SqlConnection();
            str.Open(conn);
            SqlCommand cmd = new SqlCommand("SELECT * FROM supplier WHERE supplier.title = @title ", conn);
            cmd.Parameters.AddWithValue("title", title);

            //conn.Open();
            SqlDataReader supReader = cmd.ExecuteReader();
            if (supReader.Read())
            {
                return Read(supReader);
            }
            else
                return null;
        }
    }
}
