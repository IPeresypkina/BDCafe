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
    public partial class FormChangeComposition : Form
    {
        List<Composition> compositionList;
        List<Dish> dishList;
        List<Ingredient> ingredientList;
        List<SaveComposition> saveList;//для сохранения изначальной формы

        private int dishId;
        private int cafeId;
        bool f = false;

        public FormChangeComposition(int dishId, int cafeId)//при изменении
        {
            this.Text = "Изменение";
            f = true;
            InitializeComponent();
            this.dishId = dishId;
            this.cafeId = cafeId;
        }

        public FormChangeComposition(int cafeId)//при добавлении
        {
            this.Text = "Добавление";
            InitializeComponent();
            this.cafeId = cafeId;
        }

        private void FormChangeComposition_Load(object sender, EventArgs e)
        {
            comChangeDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (f) comChangeDGV_FirstReload();
            else comChangeDGV_SecondReload();
            Save();//сохраняем форму


        }
        //double
        private void KeyPressed3(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }
        private bool GetComDish(Composition composition, Dish dish)//по id вывести строку блюда
        {
            if (composition.dish.iddish == dish.iddish && textBoxDishChange.Text == dish.title)
                return true;
            return false;
        }

        private string GetComIng(Composition composition, Ingredient ingredient)//по id вывести строку ингредиента
        {
            if (composition.ingredient.idingredient == ingredient.idingredient)
                return ingredient.product;
            return "0";
        }

        private void comChangeDGV_FirstReload()//при запуске формы "изменить" открываем состав принадлежавший определенному блюду
        {
            comChangeDGV.Rows.Clear();
            comboBoxIngChange.Items.Clear();
            int k;
            dishList = Dish.Get();
            ingredientList = Ingredient.Get();
            compositionList = Composition.Get();
            int j = 0;
            while (dishId != dishList[j].iddish)
                ++j;
            textBoxDishChange.Text = dishList[j].title;
            foreach (Composition composition in compositionList)
            {
                k = 0;
                foreach (Dish dish in dishList)
                {
                    if (GetComDish(composition, dish) && k == 0)
                    {
                        foreach (Ingredient ingredient in ingredientList)
                        {
                            if ((GetComIng(composition, ingredient) != "0") && k == 0)
                            {
                                comChangeDGV.Rows.Add(composition.idcomposition, composition.ingredient.idingredient, dish.iddish, ingredient.product, composition.numingredient);
                                ++k;
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < comChangeDGV.RowCount; ++i)
            {
                comChangeDGV.Rows[i].Selected = false;
            }

            foreach (Ingredient ingredient in ingredientList)//ингредиенты в комбобокс
            {
                comboBoxIngChange.Items.Add(ingredient.product);
            }
            textBoxNumDishChange.Text = dishList[j].quantily.ToString();

        }

        private void comDGV_SecondReload()//просто добавлем в таблицу продукты и их количество
        {
            ingredientList = Ingredient.Get();
            if (comboBoxIngChange.Text == "" || textBoxIngNumChange.Text == "")
                ErrorlabelCom.Text = "Поля для ингредиентов обязательны для заполнения";
            else
            {
                comChangeDGV.Rows.Add("", "", "", comboBoxIngChange.Text, textBoxIngNumChange.Text);

                for (int i = 0; i < comChangeDGV.RowCount; ++i)
                {
                    comChangeDGV.Rows[i].Selected = false;
                }
                //очищаем
                textBoxIngNumChange.Text = "";
                comboBoxIngChange.SelectedIndex = -1;
            }
        }
        private bool GetComIngChange(Composition composition, Ingredient ingredient)//по id вывести строку ингредиента
        {
            if (composition.idcomposition == (int)comChangeDGV.SelectedRows[0].Cells["idcomposition"].Value && ingredient.product == comboBoxIngChange.Text && composition.dish.iddish == dishId)
                return true;
            return false;
        }

        private void comChangeDGV_FirstReloadChang()//если в таблице изменяем данные
        {

            int k;
            dishList = Dish.Get();
            ingredientList = Ingredient.Get();
            compositionList = Composition.Get();

            if (dishId > 0)
            {
                foreach (Composition composition in compositionList)
                {
                    k = 0;

                    foreach (Ingredient ingredient in ingredientList)
                    {
                        if ((GetComIngChange(composition, ingredient) != false) && k == 0)
                        {
                            comChangeDGV.SelectedRows[0].Cells["idingredient"].Value = ingredient.idingredient;
                            comChangeDGV.SelectedRows[0].Cells["iddish"].Value = dishId;
                            comChangeDGV.SelectedRows[0].Cells["ingredient"].Value = comboBoxIngChange.Text;
                            comChangeDGV.SelectedRows[0].Cells["numingredient"].Value = textBoxIngNumChange.Text;
                            ++k;
                        }
                    }
                }
            }
            else
            {
                comChangeDGV.SelectedRows[0].Cells["ingredient"].Value = comboBoxIngChange.Text;
                comChangeDGV.SelectedRows[0].Cells["numingredient"].Value = textBoxIngNumChange.Text;
            }
            for (int i = 0; i < comChangeDGV.RowCount; ++i)
            {
                comChangeDGV.Rows[i].Selected = false;
            }
        }

        private void comChangeDGV_SecondReload()//инициализируем комбобокс и очищаем таблицу при добавлении 
        {
            comChangeDGV.Rows.Clear();
            comboBoxIngChange.Items.Clear();

            ingredientList = Ingredient.Get();

            for (int i = 0; i < comChangeDGV.RowCount; ++i)
            {
                comChangeDGV.Rows[i].Selected = false;
            }
            foreach (Ingredient ingredient in ingredientList)//ингредиенты в комбобокс
            {
                comboBoxIngChange.Items.Add(ingredient.product);
            }
        }

        private Composition comGetFromForm()//для состава
        {
            Composition newCom = new Composition();
            dishList = Dish.Get();

            if (string.IsNullOrWhiteSpace(textBoxIngNumChange.Text) || string.IsNullOrEmpty(textBoxIngNumChange.Text))
            {
                ErrorlabelCom.Text = "Ошибка:\r\nПоле \"Количество ингредиентов\" должно быть обязательно заполнено.";
                throw new System.ArgumentNullException();
            }
            else
            {
                newCom.numingredient = Convert.ToInt32(textBoxIngNumChange.Text);
            }

            int i = 0, j = 0;

            if (string.IsNullOrWhiteSpace(comboBoxIngChange.Text) || string.IsNullOrEmpty(comboBoxIngChange.Text))
            {
                ErrorlabelCom.Text = "Ошибка:\r\nПоле \"Ингредиенты\" должно быть обязательно заполнено.";
                throw new System.ArgumentNullException();
            }
            else
            {
                while (comboBoxIngChange.Text != ingredientList[i].product)
                    ++i;
                newCom.ingredient = Ingredient.Get(ingredientList[i].idingredient);
            }
            return newCom;
        }

        private Dish dishGetFromForm()//при внесении новых блюд изменяем БД
        {
            Dish newDish = new Dish();

            
            if (string.IsNullOrWhiteSpace(textBoxDishChange.Text) || string.IsNullOrEmpty(textBoxDishChange.Text))
            {
                ErrorlabelCom.Text = "Ошибка:\r\nПоле \"Название блюда\" должно быть обязательно заполнено.";
                throw new System.ArgumentNullException();
            }
            else
            {
                newDish.title = textBoxDishChange.Text;
            }

            if (string.IsNullOrWhiteSpace(textBoxNumDishChange.Text) || string.IsNullOrEmpty(textBoxNumDishChange.Text))
            {
                ErrorlabelCom.Text = "Ошибка:\r\nПоле \"Цена блюда\" должно быть обязательно заполнено.";
                throw new System.ArgumentNullException();
            }
            else
            {
                newDish.quantily = Convert.ToInt32(textBoxNumDishChange.Text);
            }
            newDish.cafe = Cafe.Get(cafeId);
            return newDish;
        }

        private void comChangeDGV_CellClick(object sender, DataGridViewCellEventArgs e)//по клику на строку таблицы данные отображаются в ячейках
        {
            for (int i = 0; i < comChangeDGV.RowCount; ++i)
            {
                if (comChangeDGV.Rows[i].Selected)
                {
                    textBoxIngNumChange.Text = comChangeDGV[4, i].Value.ToString();
                    comboBoxIngChange.Text = (string)comChangeDGV[3, i].Value;
                    return;
                }
            }
            textBoxIngNumChange.Text = "";
            comboBoxIngChange.Text = null;
        }


        private void ButtonDeleteMenu_Click(object sender, EventArgs e) //кнопка удаления состава ингредиент блюда
        {
            ErrorlabelCom.Text = "";
            bool changed = false;
            int j = 0;
            for (int i = 0; i < comChangeDGV.Rows.Count; ++i)
            {
                if (comChangeDGV.Rows[i].Selected)
                {
                    DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить ингредиент " + comChangeDGV[3, i].Value.ToString() + " ?", "Предупреждение!", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            comChangeDGV.Rows.RemoveAt(i);
                        }
                        catch (System.Data.SqlClient.SqlException)
                        {
                            ErrorlabelCom.Text = "Ошибка:\r\nУдаление данной записи невозможно, поскольку на неё ссылаются другие записи.";

                        }
                        changed = true;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            if (!changed) ErrorlabelCom.Text = "Ошибка:\r\nНе выбрано ни одной действительной записи.";
            //comChangeDGV_FirstReload();
            //else
            //  ErrorlabelCom.Text = "Ошибка:\r\nНе выбрано ни одной действительной записи.";
        }

        private void ButtonChangeMenu_Click(object sender, EventArgs e) //кнопка изменения состава ингредиентов в рамках памяти
        {

            ErrorlabelCom.Text = "";
            comChangeDGV_FirstReloadChang();
        }

        private void ButtonAddMenu_Click(object sender, EventArgs e)//добавить ингредиент
        {
            ErrorlabelCom.Text = "";
            comDGV_SecondReload();
        }

        private void No_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save()
        {
            saveList = new List<SaveComposition>();
            //считаем всю информацию
            for (int i = 0; i < comChangeDGV.Rows.Count; ++i)
            {
                SaveComposition newSave = new SaveComposition();
                newSave.idcomposition = Convert.ToInt32(comChangeDGV[0, i].Value);
                newSave.idingredient = Convert.ToInt32(comChangeDGV[1, i].Value);
                newSave.iddish = Convert.ToInt32(comChangeDGV[2, i].Value);
                newSave.ingredient = comChangeDGV[3, i].Value.ToString();
                newSave.numingredient = Convert.ToInt32(comChangeDGV[4, i].Value);
                saveList.Add(newSave);
            }
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            ErrorlabelCom.Text = "";
            Composition newCom = new Composition();
            int k, j = 0, n = 1, m = 0;
            bool f = false;
            string flag = " ";
            int cnt = comChangeDGV.Rows.Count;//количество строк в дгв

            try
            {
                if (dishId > 0)//если блюдо уже есть то смотрим все ли у него инегрдиенты
                {
                    //Сначала смотрим по id состава удалил ли пользователь какой нибудь ингредиент
                    for (int i = 0; i < saveList.Count; ++i)
                    {
                        if (i < cnt)
                        {
                            k = 0;
                            if (comChangeDGV[0, i].Value.ToString() != "")//если id ингредиента "" (т.е. это добавленный ингредиент)
                            {
                                if (saveList[j].idcomposition != Convert.ToInt32(comChangeDGV[0, i].Value))
                                {
                                    while (saveList[j].idcomposition != compositionList[k].idcomposition)
                                        ++k;
                                    Composition.Delete(compositionList[k].idcomposition);
                                    f = true;
                                }
                            }
                            else
                            {
                                while (saveList[j].idcomposition != compositionList[k].idcomposition)
                                    ++k;
                                Composition.Delete(compositionList[k].idcomposition);
                                f = true;
                            }
                            ++j;
                        }
                        else
                        {
                            k = 0;
                            while (saveList[j].idcomposition != compositionList[k].idcomposition)
                                ++k;
                            Composition.Delete(compositionList[k].idcomposition);
                            f = true;
                            ++j;
                        }

                    }

                    //Потом смотрим изменял ли он что то 
                    if (comboBoxIngChange.Text == "" && textBoxIngNumChange.Text == "")
                    {
                        Dish.Update(dishId, dishGetFromForm());//изменяем блюдо в бд
                        f = true;
                    }
                    else
                    {
                        cnt = comChangeDGV.Rows.Count;//количество строк в дгв
                        Dish.Update(dishId, dishGetFromForm());//изменяем блюдо в бд
                        j = 0;

                        for (int i = 0; i < compositionList.Count - 1; ++i)
                        {
                            while (n == 1 && comChangeDGV[0, j].Value.ToString() != "")
                            {
                                if (compositionList[i].idcomposition == (int)comChangeDGV[0, j].Value)
                                {
                                    if (j + 1 == cnt || i == compositionList.Count - 1)//если это последняя строка ДГВ или таблицы бд
                                    {
                                        n = 0;

                                        newCom.dish = Dish.Get(dishId);
                                        newCom.numingredient = Convert.ToInt32(comChangeDGV[4, j].Value);
                                        newCom.ingredient = Ingredient.Get(Convert.ToInt32(comChangeDGV[1, j].Value));
                                        Composition.Update(compositionList[i].idcomposition, newCom);
                                        f = true;
                                    }
                                    else
                                    {
                                        newCom.dish = Dish.Get(dishId);
                                        newCom.numingredient = Convert.ToInt32(comChangeDGV[4, j].Value);
                                        newCom.ingredient = Ingredient.Get(Convert.ToInt32(comChangeDGV[1, j].Value));
                                        Composition.Update(compositionList[i].idcomposition, newCom);
                                        ++j;
                                        f = true;
                                    }
                                }
                                ++i;
                            }
                        }
                    }
                    //и смотрим добавленные
                    j = 0;
                    while (j < cnt)
                    {
                        if (comChangeDGV[0, j].Value.ToString() != "")
                            ++m;
                        ++j;
                    }
                    for (int i = m; i < cnt; ++i)
                    {
                        j = 0;
                        newCom.dish = Dish.Get(dishId);
                        newCom.numingredient = Convert.ToInt32(comChangeDGV[4, i].Value);
                        while (comChangeDGV[3, i].Value.ToString() != ingredientList[j].product)
                            ++j;
                        newCom.ingredient = Ingredient.Get(ingredientList[j].idingredient);
                        Composition.Insert(newCom);
                        f = true;
                    }

                    if (f)
                        flag = "База данных была обновлена.";
                    else
                        flag = "Вы ничего не изменили ";
                }
                else
                {
                    //если нет то добавляем новое со всеми ингредиентами
                    j = 0;
                    Dish.Insert(dishGetFromForm());//добавляем блюдо в бд
                    dishList = Dish.Get();
                    while (textBoxDishChange.Text != dishList[j].title)
                        ++j;
                    newCom.dish = Dish.Get(dishList[j].iddish);//в таблицу состав добавляем id блюда
                    j = 0;

                    for (int i = 0; i < comChangeDGV.Rows.Count; ++i)
                    {

                        newCom.numingredient = Convert.ToInt32(comChangeDGV[4, i].Value);
                        while ((string)comChangeDGV[3, i].Value != ingredientList[j].product)
                            ++j;
                        newCom.ingredient = Ingredient.Get(ingredientList[j].idingredient);
                        Composition.Insert(newCom);
                        f = true;
                        j = 0;
                    }
                    if (f)
                        flag = "База данных была обновлена.";
                    else
                        flag = "Вы ничего не изменили ";
                }
            }

            catch (System.ArgumentNullException)
            {
                return;
            }
            DialogResult dialogResult = MessageBox.Show(flag, "Сообщение", MessageBoxButtons.OK);
            if (dialogResult == DialogResult.OK)
            {
                this.Close();
            }

        }
    }
}
