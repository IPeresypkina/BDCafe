using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CafeLibrary;

namespace BD4
{
    public partial class FormPost : Form
    {
        List<Post> postList;
        List<Serve> serveList;

        int choosenIndexPost = -1;

        public FormPost()
        {
            InitializeComponent();
        }

        private void FormPost_Load(object sender, EventArgs e)
        {
            postDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            postDGV_FirstReload();
        }
        //-------------------------------ИСКЛЮЧЕНИЯ---------------------------------------------------------------
        //string
        private void KeyPressed1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
        //int
        private void KeyPressed2(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        private string GetPostServe(Post post, Serve serve)
        {
            if (post.serve.idserve == serve.idserve)
                return serve.name;
            return "0";
        }

        private void postDGV_FirstReload()
        {
            postDGV.Rows.Clear();
            serveList = Serve.Get();
            postList = Post.Get();
            comboBoxServe.Items.Clear();
            foreach (Post post in postList)
            {
                foreach (Serve serve in serveList)
                {
                    if (GetPostServe(post, serve) != "0")
                        postDGV.Rows.Add(post.idpost, post.title, post.salary, serve.name);
                }
            }

            for (int i = 0; i < postDGV.RowCount; ++i)
            {
                postDGV.Rows[i].Selected = false;
            }
            foreach (Serve serve in serveList)
            {
                comboBoxServe.Items.Add(serve.name);
            }
            comboBoxServe.SelectedIndex = -1;

            textBoxPost.Text = "";
            textBoxSalary.Text = "";
            comboBoxServe.Text = null;

            choosenIndexPost = -1;
        }
        private void postDGV_Reload()
        {
            postDGV_FirstReload();
        }
        private Post postGetFromForm()
        {
            int i = 0;
            Post newPost = new Post();
            if (string.IsNullOrWhiteSpace(textBoxPost.Text) || string.IsNullOrEmpty(textBoxPost.Text))
            {
                ErrorlabelPost.Text = "Ошибка:\r\nПоле \"Должность\" должно быть обязательно заполнено.";
                throw new System.ArgumentNullException();
            }
            else
            {
                newPost.title = textBoxPost.Text;
            }
            if (string.IsNullOrWhiteSpace(textBoxSalary.Text) || string.IsNullOrEmpty(textBoxSalary.Text))
            {
                ErrorlabelPost.Text = "Ошибка:\r\nПоле \"Зарплата\" должно быть обязательно заполнено.";
                throw new System.ArgumentNullException();
            }
            else
            {
                newPost.salary = Convert.ToInt32(textBoxSalary.Text);
            }
            if (string.IsNullOrWhiteSpace(comboBoxServe.Text) || string.IsNullOrEmpty(comboBoxServe.Text))
            {
                ErrorlabelPost.Text = "Ошибка:\r\nПоле \"Сотрудник\" должно быть обязательно заполнено.";
                throw new System.ArgumentNullException();
            }
            else
            {
                while (comboBoxServe.Text != serveList[i].name)
                    ++i;
                newPost.serve = Serve.Get(serveList[i].idserve);
            }
            return newPost;
        }
        private void postAddButton_Click(object sender, EventArgs e)
        {
            ErrorlabelPost.Text = "";
            try
            {
                Post.Insert(postGetFromForm());
            }
            catch (System.ArgumentNullException)
            {
                return;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ErrorlabelPost.Text = "Невозможно добавить запись с таким же именем.";
                return;
            }
            postDGV_Reload();
        }
        private void postDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int j = 0;
            for (int i = 0; i < postDGV.RowCount; ++i)
            {
                if (postDGV.Rows[i].Selected)
                {
                    textBoxPost.Text = postList[i].title;
                    textBoxSalary.Text = postList[i].salary.ToString();
                    while (postList[i].serve.idserve != serveList[j].idserve)
                        ++j;
                    comboBoxServe.Text = serveList[j].name;
                    choosenIndexPost = i;
                    return;
                }
            }
            textBoxPost.Text = "";
            textBoxSalary.Text = "";
            comboBoxServe.Text = null;
        }

        private void postDeleteButton_Click(object sender, EventArgs e)
        {
            ErrorlabelPost.Text = "";
            bool changed = false;
            for (int i = 0; i < postDGV.Rows.Count; ++i)
            {
                if (postDGV.Rows[i].Selected)
                {
                    DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить должность " + postDGV[1, i].Value.ToString() + " ?", "Предупреждение!", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            Post.Delete(postList[i].idpost);
                        }
                        catch (System.Data.SqlClient.SqlException)
                        {
                            ErrorlabelPost.Text = "Ошибка:\r\nУдаление данной записи невозможно, поскольку на неё ссылаются другие записи.";

                        }
                        changed = true;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            if (changed)
                postDGV_Reload(); 
            else
                ErrorlabelPost.Text = "Ошибка:\r\nНе выбрано ни одной действительной записи.";
        }

        private void postChangeButton_Click(object sender, EventArgs e)
        {
            if (choosenIndexPost == -1)
            {
                ErrorlabelPost.Text = "Ошибка:\r\nНе выбрано ни одной действительной записи.";
                return;
            }
            ErrorlabelPost.Text = "";
            try
            {
                Post.Update(postList[choosenIndexPost].idpost, postGetFromForm());
            }
            catch (System.ArgumentNullException)
            {
                return;
            }
            postDGV_Reload();
        }

        private void buttonClearDataPost_Click(object sender, EventArgs e)
        {
            textBoxPost.Text = "";
            textBoxSalary.Text = "";
            comboBoxServe.Text = null;
            ErrorlabelPost.Text = "";
        }
    }
}
