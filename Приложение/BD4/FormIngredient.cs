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
    
    public partial class FormIngredient : Form
    {
        List<Ingredient> ingredientList;

        int choosenIndexIngredient = -1;

        public FormIngredient()
        {
            InitializeComponent();
        }

        private void FormIngredient_Load(object sender, EventArgs e)
        {
            IngDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            IngDGV_FirstReload();
        }

        //string
        private void KeyPressed1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void IngDGV_FirstReload()
        {
            IngDGV.Rows.Clear();

            ingredientList = Ingredient.Get();
            foreach (Ingredient ingredient in ingredientList)
            {
                IngDGV.Rows.Add(ingredient.idingredient, ingredient.product);
            }
           
            for (int i = 0; i < IngDGV.RowCount; ++i)
            {
                IngDGV.Rows[i].Selected = false;
            }

            textBoxIngredient.Text = "";
            choosenIndexIngredient = -1;
        }

        private void IngDGV_Reload()
        {
            IngDGV_FirstReload();
        }
        private Ingredient IngredintGetFromForm()
        {
            Ingredient newIngredient = new Ingredient();
            if (string.IsNullOrWhiteSpace(textBoxIngredient.Text) || string.IsNullOrEmpty(textBoxIngredient.Text))
            {
                ErrorlabelIng.Text = "Ошибка:\r\nПоле \"Ингредиент\" должно быть \nобязательно заполнено.";
                throw new System.ArgumentNullException();
            }
            else
            {
                newIngredient.product = textBoxIngredient.Text;
            }
            return newIngredient;
        }

        private void IngredientAddButton_Click(object sender, EventArgs e)
        {
            ErrorlabelIng.Text = "";
            try
            {
                Ingredient.Insert(IngredintGetFromForm());
            }
            catch (System.ArgumentNullException)
            {
                return;
            }

            IngDGV_Reload();
        }
        private void IngDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < IngDGV.RowCount; ++i)
            {
                if (IngDGV.Rows[i].Selected)
                {
                    textBoxIngredient.Text = ingredientList[i].product;
                    choosenIndexIngredient = i;
                    return;
                }
            }
            textBoxIngredient.Text = "";
        }

        private void IngredientDeleteButton_Click(object sender, EventArgs e)
        {
            ErrorlabelIng.Text = "";
            bool changed = false;
            for (int i = 0; i < IngDGV.Rows.Count; ++i)
            {
                if (IngDGV.Rows[i].Selected)
                {
                    DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить ингредиент " + IngDGV[1, i].Value.ToString() + " ?", "Предупреждение!", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            Ingredient.Delete(ingredientList[i].idingredient);
                        }
                        catch (System.Data.SqlClient.SqlException)
                        {
                            ErrorlabelIng.Text = "Ошибка:\r\nУдаление данной записи невозможно, поскольку на неё ссылаются другие записи.";

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
                IngDGV_Reload();
            else
                ErrorlabelIng.Text = "Ошибка:\r\nНе выбрано ни одной \nдействительной записи.";
        }

        private void IngredientChangeButton_Click(object sender, EventArgs e)
        {
            if (choosenIndexIngredient == -1)
            {
                ErrorlabelIng.Text = "Ошибка:\r\nНе выбрано ни одной действительной записи.";
                return;
            }
            ErrorlabelIng.Text = "";
            try
            {
                Ingredient.Update(ingredientList[choosenIndexIngredient].idingredient, IngredintGetFromForm());
            }
            catch (System.ArgumentNullException)
            {
                return;
            }
            IngDGV_Reload();
        }

        private void buttonClearDataIng_Click(object sender, EventArgs e)
        {
            textBoxIngredient.Text = "";
            ErrorlabelIng.Text = "";
        }

    }
}
