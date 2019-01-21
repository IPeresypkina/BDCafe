using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CafeLibrary
{
    public class Post
    {
        //static private string connString = "Data Source=DESKTOP-5E5L14V;Initial Catalog=cafe;Integrated Security=True";
        public int idpost { get; set; }
        public string title { get; set; }
        public int salary { get; set; }
        public Serve serve { get; set; }

        private static Post Read(SqlDataReader postReader)
        {
            Post newOne = new Post();
            newOne.idpost = postReader.GetInt32(0);
            newOne.title = postReader.GetString(1);
            newOne.salary = postReader.GetInt32(2);
            try
            {
                newOne.serve = Serve.Get(postReader.GetInt32(3));
                //newOne.serve_idserve = postReader.GetInt32(3);
            }
            catch(System.Data.SqlTypes.SqlNullValueException)
            {
                newOne.serve = null;
            }
            return newOne;
        }
        public static List<Post> Get()
        {
            ConnectionString str = new ConnectionString();
            SqlConnection conn = new SqlConnection();
            str.Open(conn);
            SqlCommand cmd = new SqlCommand("SELECT * FROM post", conn);

            //conn.Open();
            SqlDataReader postReader = cmd.ExecuteReader();
            List<Post> posts = new List<Post>();
            while (postReader.Read())
            {
                posts.Add(Read(postReader));
            }
            postReader.Close();
            conn.Close();

            return posts;
        }

        public static void Insert(Post post)
        {
            ConnectionString str = new ConnectionString();
            SqlConnection conn = new SqlConnection();
            str.Open(conn);
            SqlCommand cmd = new SqlCommand("", conn);

            cmd.CommandText = "INSERT INTO post( title, salary, serve_idserve ";
            string values = "VALUES( @_title, @_salary, @_serve_idserve";
            cmd.Parameters.AddWithValue("_title", post.title);
            cmd.Parameters.AddWithValue("_salary", post.salary);
            cmd.Parameters.AddWithValue("_serve_idserve", post.serve.idserve);
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

            cmd.CommandText = @"DELETE FROM post
                                WHERE idpost = @id";
            cmd.Parameters.AddWithValue("id", id);

            //conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void Update(int id, Post newPost)
        {
            ConnectionString str = new ConnectionString();
            SqlConnection conn = new SqlConnection();
            str.Open(conn);
            SqlCommand cmd = new SqlCommand("", conn);

            cmd.CommandText = "Update post SET title = @_title, salary = @_salary, serve_idserve = @_serve_idserve";
            cmd.Parameters.AddWithValue("_title", newPost.title);
            cmd.Parameters.AddWithValue("_salary", newPost.salary);
            cmd.Parameters.AddWithValue("_serve_idserve", newPost.serve.idserve);
            cmd.CommandText += " WHERE idpost = @id";
            cmd.Parameters.AddWithValue("id", id);

            //conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
