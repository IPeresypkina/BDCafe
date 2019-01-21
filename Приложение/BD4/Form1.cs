using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using CafeLibrary;


namespace BD4
{
    public partial class Form1 : Form
    {
        List<Cafe> cafeList;
        List<Supplier> supList;
        List<Dish> dishList;
        List<Serve> serveList;
        

        int choosenIndexCafe = -1;
        int choosenIndexSupplier = -1;
        int choosenIndexDish = -1;
        int choosenIndexServe = -1;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cafeDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            supDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            menuDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            servDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            cafeDGV_FirstReload();
            supDGV_FirstReload();
            menuDGV_SecondReload();
            servDGV_FirstReload();

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

        //double
        private void KeyPressed3(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }


        //string and number
        private void KeyPressed5(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //-------------------------------CAFE TABLE-------------------------------
        private void cafeDGV_FirstReload()
        {
            cafeDGV.Rows.Clear();

            cafeList = Cafe.Get();
            foreach (Cafe cafe in cafeList)
            {
                cafeDGV.Rows.Add(cafe.idcafe, cafe.owner, cafe.title, cafe.address, cafe.phone, cafe.rating);
            }

            for (int i = 0; i < cafeDGV.RowCount; ++i)
            {
                cafeDGV.Rows[i].Selected = false;
            }
            

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";


            choosenIndexCafe = -1;
        }

        private void cafeDGV_Reload()
        {
            cafeDGV_FirstReload();
        }
        private Cafe cafeGetFromForm()
        {
            Cafe newCafe = new Cafe();
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrEmpty(textBox1.Text))
            {
                ErrorlabelCafe.Text = "Ошибка:\r\nПоле \"Владелец ФИО\" должно быть обязательно заполнено.";
                throw new System.ArgumentNullException();
            }
            else
            {
                newCafe.owner = textBox1.Text;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                ErrorlabelCafe.Text = "Ошибка:\r\nПоле \"Название\" должно быть обязательно заполнено.";
                throw new System.ArgumentNullException();
            }
            else
            {
                newCafe.title = textBox2.Text;
            }
            if (string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                ErrorlabelCafe.Text = "Ошибка:\r\nПоле \"Адрес\" должно быть обязательно заполнено.";
                throw new System.ArgumentNullException();
            }
            else
            {
                newCafe.address = textBox3.Text;
            }
            newCafe.address = textBox3.Text;
            newCafe.phone = Convert.ToInt32(textBox4.Text);
            newCafe.rating = Convert.ToInt32(textBox5.Text);
            return newCafe;
        }
        private void cafeAddButton_Click(object sender, EventArgs e)
        {
            ErrorlabelCafe.Text = "";
            try
            {
                Cafe.Insert(cafeGetFromForm());
            }
            catch (System.ArgumentNullException)
            {
                return;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ErrorlabelCafe.Text = "Невозможно добавить запись с таким же именем.";
                return;
            }
            cafeDGV_Reload();
            supDGV_Reload();//в случае изменения адреса что бы он изменился во вкладке поставщиков
            servDGV_FirstReload();//в случае изменения адреса что бы он изменился во вкладке сотрудников
            menuDGV_SecondReload();
        }
        private void cafeDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < cafeDGV.RowCount; ++i)
            {
                if (cafeDGV.Rows[i].Selected)
                {
                    textBox1.Text = cafeList[i].owner;
                    textBox2.Text = cafeList[i].title;
                    textBox3.Text = cafeList[i].address;
                    textBox4.Text = cafeList[i].phone.ToString();
                    textBox5.Text = cafeList[i].rating.ToString();
                    choosenIndexCafe = i;
                    return;
                }
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void cafeDeleteButton_Click(object sender, EventArgs e)
        {
            

            ErrorlabelCafe.Text = "";
            bool changed = false;
            for (int i = 0; i < cafeDGV.Rows.Count; ++i)
            {
                if (cafeDGV.Rows[i].Selected)
                {
                    DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить кафе по адресу " + cafeDGV[3,i].Value.ToString() + " ?", "Предупреждение!", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {                       
                        try
                        {
                            Cafe.Delete(cafeList[i].idcafe);
                        }
                        catch (System.Data.SqlClient.SqlException)
                        {
                            ErrorlabelServe.Text = "Ошибка:\r\nУдаление данной записи невозможно, поскольку на неё ссылаются другие записи.";

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
            {
                cafeDGV_Reload();
                supDGV_Reload();//в случае изменения адреса что бы он изменился во вкладке поставщиков
                servDGV_FirstReload();//в случае изменения адреса что бы он изменился во вкладке сотрудников
                menuDGV_SecondReload();
            }
            else
                ErrorlabelCafe.Text = "Ошибка:\r\nНе выбрано ни одной действительной записи.";
        }

        private void cafeChangeButton_Click(object sender, EventArgs e)
        {
            if (choosenIndexCafe == -1)
            {
                ErrorlabelCafe.Text = "Ошибка:\r\nНе выбрано ни одной действительной записи.";
                return;
            }
            ErrorlabelCafe.Text = "";
            try
            {
                Cafe.Update(cafeList[choosenIndexCafe].idcafe, cafeGetFromForm());
            }
            catch (System.ArgumentNullException)
            {
                return;
            }
            cafeDGV_Reload();
            supDGV_Reload();//в случае изменения адреса что бы он изменился во вкладке поставщиков
            servDGV_FirstReload();//в случае изменения адреса что бы он изменился во вкладке сотрудников
            menuDGV_SecondReload();       }
        private void buttonClearDataCafe_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            ErrorlabelCafe.Text = "";
        }

        //-------------------------------SUPPLIER TABLE-------------------------------
        private string GetCafeSup(Cafe cafe, Supplier supplier)
        {
            if (cafe.idcafe == supplier.cafe.idcafe)
                return cafe.address;
            return "0";
        }

        private void supDGV_FirstReload()
        {
            supDGV.Rows.Clear();
            
            cafeList = Cafe.Get();
            supList = Supplier.Get();
            comboBoxSupCafe.Items.Clear();
            

            foreach (Supplier supplier in supList)
            {
                foreach (Cafe cafe in cafeList)
                {
                    if(GetCafeSup(cafe, supplier) != "0")
                        supDGV.Rows.Add(supplier.idsupplier, supplier.title, supplier.product, supplier.FrequencyOfDeliveries, supplier.VolumeOfDeliveries, cafe.address);
                }
            }

            for (int i = 0; i < supDGV.RowCount; ++i)
            {
                supDGV.Rows[i].Selected = false;
            }
            foreach (Cafe cafe in cafeList)
            {
                comboBoxSupCafe.Items.Add(cafe.address);
            }
            comboBoxSupCafe.SelectedIndex = -1;

            

            textBoxSupTitle.Text = "";
            textBoxSupProduct.Text = "";
            textBoxSupFOD.Text = "";
            textBoxSupVOD.Text = "";
            comboBoxSupCafe.Text = null;
            
            choosenIndexSupplier = -1;
        }

        private void supDGV_Reload()
        {
            supDGV_FirstReload();
        }
        private Supplier supGetFromForm()
        {
            int i = 0;
            Supplier newSupplier = new Supplier();
            if (string.IsNullOrWhiteSpace(textBoxSupTitle.Text) || string.IsNullOrEmpty(textBoxSupTitle.Text))
            {
                ErrorlabelSup.Text = "Ошибка:\r\nПоле \"Название фирмы\" должно быть обязательно заполнено.";
                throw new System.ArgumentNullException();
            }
            else
            {
                newSupplier.title = textBoxSupTitle.Text;
            }

            if (string.IsNullOrWhiteSpace(textBoxSupProduct.Text) || string.IsNullOrEmpty(textBoxSupProduct.Text))
            {
                ErrorlabelSup.Text = "Ошибка:\r\nПоле \"Поставляемая продукция\" должно быть обязательно заполнено.";
                throw new System.ArgumentNullException();
            }
            else
            {
                newSupplier.product = textBoxSupProduct.Text;
            }

            newSupplier.FrequencyOfDeliveries = Convert.ToInt32(textBoxSupFOD.Text);
            newSupplier.VolumeOfDeliveries = Convert.ToInt32(textBoxSupVOD.Text);

            while (comboBoxSupCafe.Text != cafeList[i].address)
                ++i;
            newSupplier.cafe = Cafe.Get(cafeList[i].idcafe);

            return newSupplier;
        }
        private void supAddButton_Click(object sender, EventArgs e)
        {
            ErrorlabelSup.Text = "";
            try
            {
                Supplier.Insert(supGetFromForm());
            }
            catch (System.ArgumentNullException)
            {
                return;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ErrorlabelSup.Text = "Невозможно добавить запись с таким же именем.";
                return;
            }
            supDGV_Reload();
        }
        private void supDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int j = 0;
            for (int i = 0; i < supDGV.RowCount; ++i)
            {
                if (supDGV.Rows[i].Selected)
                {
                    textBoxSupTitle.Text = supList[i].title;
                    textBoxSupProduct.Text = supList[i].product;
                    textBoxSupFOD.Text = supList[i].FrequencyOfDeliveries.ToString();
                    textBoxSupVOD.Text = supList[i].VolumeOfDeliveries.ToString();
                    while (supList[i].cafe.idcafe != cafeList[j].idcafe)
                        ++j;
                    comboBoxSupCafe.Text = cafeList[j].address;
                    choosenIndexSupplier = i;
                    return;
                }
            }
            textBoxSupTitle.Text = "";
            textBoxSupProduct.Text = "";
            textBoxSupFOD.Text = "";
            textBoxSupVOD.Text = "";
            comboBoxSupCafe.Text = null;
        }

        private void supDeleteButton_Click(object sender, EventArgs e)
        {
            ErrorlabelSup.Text = "";
            bool changed = false;
            for (int i = 0; i < supDGV.Rows.Count; ++i)
            {
                if (supDGV.Rows[i].Selected)
                {
                    DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить поставщика " + supDGV[1, i].Value.ToString() + " ?", "Предупреждение!", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            Supplier.Delete(supList[i].idsupplier);
                        }
                        catch (System.Data.SqlClient.SqlException)
                        {
                            ErrorlabelServe.Text = "Ошибка:\r\nУдаление данной записи невозможно, поскольку на неё ссылаются другие записи.";

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
                supDGV_Reload();
            else
                ErrorlabelSup.Text = "Ошибка:\r\nНе выбрано ни одной действительной записи.";
        }

        private void supChangeButton_Click(object sender, EventArgs e)
        {
            if (choosenIndexSupplier == -1)
            {
                ErrorlabelSup.Text = "Ошибка:\r\nНе выбрано ни одной действительной записи.";
                return;
            }
            ErrorlabelSup.Text = "";
            try
            {
                Supplier.Update(supList[choosenIndexSupplier].idsupplier, supGetFromForm());
            }
            catch (System.ArgumentNullException)
            {
                return;
            }
            supDGV_Reload();
        }

        private void buttonClearDataSup_Click(object sender, EventArgs e)
        {
            textBoxSupTitle.Text = "";
            textBoxSupProduct.Text = "";
            textBoxSupFOD.Text = "";
            textBoxSupVOD.Text = "";
            comboBoxSupCafe.Text = null;
            ErrorlabelSup.Text = "";
        }
        //-------------------------------MENU TABLE-------------------------------
        private string GetCafeDish(Cafe cafe, Dish dish)
        {
            if (cafe.idcafe == dish.cafe.idcafe)
                return cafe.address;
            return "0";
        }
        
        public void menuDGV_Reload()//фуекция вызывает функцию заполнения таблицы меню
        {
                menuDGV_FirstReload();
        }
        
        public void menuDGV_FirstReload()//заполняем таблицу блюдами
        {
            int k = 0;
            menuDGV.Rows.Clear();
            Cafe tmp = new Cafe();
            dishList = Dish.Get();
            cafeList = Cafe.Get();
            
            while (comboBoxCafe.Text != cafeList[k].address)
                ++k;
            tmp.idcafe = cafeList[k].idcafe;
            foreach (Dish dish in dishList)
            {
                if (GetCafeDish(tmp, dish) != "0")
                    menuDGV.Rows.Add(dish.iddish, tmp.idcafe, dish.title, dish.quantily);
            }

            for (int i = 0; i < menuDGV.RowCount; ++i)
            {
                menuDGV.Rows[i].Selected = false;
            }
            choosenIndexDish = -1;
        }

        private void comboBoxCafe_SelectedIndexChanged(object sender, EventArgs e)
        {
            menuDGV_FirstReload();
        }

        public void menuDGV_SecondReload()//заполняем таблицу блюдами
        {
            comboBoxCafe.Items.Clear();
            menuDGV.Rows.Clear();
            foreach (Cafe cafe in cafeList)
            {
                comboBoxCafe.Items.Add(cafe.address);
            }
            for (int i = 0; i < menuDGV.RowCount; ++i)
            {
                menuDGV.Rows[i].Selected = false;
            }
            choosenIndexDish = -1;
            comboBoxCafe.SelectedIndex = -1;
        }

        private void ButtonChangeAdd_Click(object sender, EventArgs e)
        {
            FormChangeComposition winArray;
            try
            {
                if (menuDGV.SelectedRows.Count > 0)
                {
                    winArray = new FormChangeComposition((int)menuDGV.SelectedRows[0].Cells["Column16"].Value, (int)menuDGV.SelectedRows[0].Cells["cafe_idcafe"].Value);
                    winArray.Show();
                    menuDGV_FirstReload();
                }
                else
                {
                    int k = 0;
                    cafeList = Cafe.Get();
                    while (comboBoxCafe.Text != cafeList[k].address)
                        ++k;
                    winArray = new FormChangeComposition(cafeList[k].idcafe);
                    winArray.Show();
                    menuDGV_FirstReload();
                }
                
            }
            catch
            {
                ErrorlabelMenu.Text = "Ошибка:\r\nВы не выбрали кафе.";
            }
            
        }

        private void menuDGV_CellClick(object sender, DataGridViewCellEventArgs e)//при клике данной строчки, ее данные будут в текстбоксах
        {
            for (int i = 0; i < menuDGV.RowCount; ++i)
            {
                if (menuDGV.Rows[i].Selected)
                {
                    //if (f)
                    //textBoxDishTitle.Text = dishList[i].title;
                    //textBoxDisshQuant.Text = dishList[i].quantily.ToString();
                    choosenIndexDish = i;
                    return;
                }
            }
            //textBoxDishTitle.Text = "";
            //textBoxDisshQuant.Text = "";
        }
        

        private void MenuDeleteButton_Click_1(object sender, EventArgs e)
        {
            ErrorlabelMenu.Text = "";
            bool changed = false;
            for (int i = 0; i < menuDGV.Rows.Count; ++i)
            {
                if (menuDGV.Rows[i].Selected)
                {
                    DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить блюдо " + menuDGV[2, i].Value.ToString() + " ?", "Предупреждение!", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            int j = 0;
                            while ((int)menuDGV[0, i].Value != dishList[j].iddish)
                                ++j;
                            Dish.Delete(dishList[j].iddish);
                        }
                        catch (System.Data.SqlClient.SqlException)
                        {
                            ErrorlabelMenu.Text = "Ошибка:\r\nУдаление данной записи невозможно, поскольку на неё ссылаются другие записи.";

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
                menuDGV_Reload();
            else
                ErrorlabelMenu.Text = "Ошибка:\r\nНе выбрано ни одной действительной записи.";

        }

        //private void MenuChangeButton_Click_1(object sender, EventArgs e)
        //{
        //    if (choosenIndexDish == -1)
        //    {
        //        ErrorlabelMenu.Text = "Ошибка:\r\nНе выбрано ни одной действительной записи.";
        //        return;
        //    }
        //    ErrorlabelMenu.Text = "";
        //    try
        //    {
        //        Dish.Update(dishList[choosenIndexDish].iddish, dishGetFromForm());
        //    }
        //    catch (System.ArgumentNullException)
        //    {
        //        return;
        //    }
        //    menuDGV_Reload();
        //}
        /*
        private void ButtonUpdateTableMenu_Click(object sender, EventArgs e)//обновление таблицы меню
        {
            menuDGV_FirstReload();
        }
        */
        private void ButtonIngredient_Click_1(object sender, EventArgs e)//кнопка ингредиентов
        {
            FormIngredient winArray;
            winArray = new FormIngredient();
            winArray.Show();
        }

        //---------------------------------------------SERVE TABLE--------------------------------------------------------------
        private string GetCafeServe(Cafe cafe, Serve serve)
        {
            if (cafe.idcafe == serve.cafe.idcafe)
                return cafe.address;
            return "0";
        }

        private void servDGV_FirstReload()
        {
            servDGV.Rows.Clear();
            cafeList = Cafe.Get();
            serveList = Serve.Get();
            
            comboBoxServeCafe.Items.Clear();
            foreach (Serve serve in serveList)
            {
                foreach (Cafe cafe in cafeList)
                {
                    if (GetCafeServe(cafe, serve) != "0")
                        servDGV.Rows.Add(serve.idserve, serve.name, serve.passport, serve.education, serve.experience, cafe.address);
                }
            }

            for (int i = 0; i < servDGV.RowCount; ++i)
            {
                servDGV.Rows[i].Selected = false;
            }
            foreach (Cafe cafe in cafeList)
            {
                comboBoxServeCafe.Items.Add(cafe.address);
            }
            comboBoxServeCafe.SelectedIndex = -1;

            textBoxName.Text = "";
            textBoxPassport.Text = "";
            textBoxEducation.Text = "";
            textBoxExperience.Text = "";
            comboBoxServeCafe.Text = null;

            choosenIndexServe = -1;
        }
        private void servDGV_Reload()
        {
            servDGV_FirstReload();
        }
        private Serve serveGetFromForm()
        {
            int i = 0;
            Serve newServe = new Serve();
            if (string.IsNullOrWhiteSpace(textBoxName.Text) || string.IsNullOrEmpty(textBoxName.Text))
            {
                ErrorlabelServe.Text = "Ошибка:\r\nПоле \"ФИО сотрудника\" должно быть обязательно заполнено.";
                throw new System.ArgumentNullException();
            }
            else
            {
                newServe.name = textBoxName.Text;
            }

            if (string.IsNullOrWhiteSpace(textBoxPassport.Text) || string.IsNullOrEmpty(textBoxPassport.Text))
            {
                ErrorlabelServe.Text = "Ошибка:\r\nПоле \"Паспортные данные\" должно быть обязательно заполнено.";
                throw new System.ArgumentNullException();
            }
            else
            {
                newServe.passport = Convert.ToInt32(textBoxPassport.Text);
            }
            
            newServe.education = textBoxEducation.Text;

            if (string.IsNullOrWhiteSpace(textBoxExperience.Text) || string.IsNullOrEmpty(textBoxExperience.Text))
            {
                ErrorlabelServe.Text = "Ошибка:\r\nПоле \"Опыт работы\" должно быть обязательно заполнено.";
                throw new System.ArgumentNullException();
            }
            else
            {
                newServe.experience = Convert.ToInt32(textBoxExperience.Text);
            }
            if (string.IsNullOrWhiteSpace(comboBoxServeCafe.Text) || string.IsNullOrEmpty(comboBoxServeCafe.Text))
            {
                ErrorlabelServe.Text = "Ошибка:\r\nПоле \"Адрес кофейни\" должно быть обязательно заполнено.";
                throw new System.ArgumentNullException();
            }
            else
            {
                while (comboBoxServeCafe.Text != cafeList[i].address)
                    ++i;
                newServe.cafe = Cafe.Get(cafeList[i].idcafe);
            }

            return newServe;
        }
        private void servAddButton_Click(object sender, EventArgs e)
        {
            ErrorlabelServe.Text = "";
            try
            {
                Serve.Insert(serveGetFromForm());
            }
            catch (System.ArgumentNullException)
            {
                return;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ErrorlabelServe.Text = "Невозможно добавить запись с таким же именем.";
                return;
            }
            servDGV_Reload();
        }
        private void servDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int j = 0;
            for (int i = 0; i < servDGV.RowCount; ++i)
            {
                if (servDGV.Rows[i].Selected)
                {
                    textBoxName.Text = serveList[i].name;
                    textBoxPassport.Text = serveList[i].passport.ToString();
                    textBoxEducation.Text = serveList[i].education;
                    textBoxExperience.Text = serveList[i].experience.ToString();
                    while (serveList[i].cafe.idcafe != cafeList[j].idcafe)
                        ++j;
                    comboBoxServeCafe.Text = cafeList[j].address;
                    choosenIndexServe = i;
                    return;
                }
            }
            textBoxName.Text = "";
            textBoxPassport.Text = "";
            textBoxEducation.Text = "";
            textBoxExperience.Text = "";
            comboBoxServeCafe.Text = null;
        }

        private void servDeleteButton_Click(object sender, EventArgs e)
        {
            ErrorlabelServe.Text = "";
            bool changed = false;
            for (int i = 0; i < servDGV.Rows.Count; ++i)
            {
                if (servDGV.Rows[i].Selected)
                {
                    DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить сотрудника " + servDGV[1, i].Value.ToString() + " ?", "Предупреждение!", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            Serve.Delete(serveList[i].idserve);
                        }
                        catch (System.Data.SqlClient.SqlException)
                        {
                            ErrorlabelServe.Text = "Ошибка:\r\nУдаление данной записи невозможно, поскольку на неё ссылаются другие записи.";
                            
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
                servDGV_Reload();
            else
                ErrorlabelServe.Text = "Ошибка:\r\nНе выбрано ни одной действительной записи.";
        }

        private void servChangeButton_Click(object sender, EventArgs e)
        {
            if (choosenIndexServe == -1)
            {
                ErrorlabelServe.Text = "Ошибка:\r\nНе выбрано ни одной действительной записи.";
                return;
            }
            ErrorlabelServe.Text = "";
            try
            {
                Serve.Update(serveList[choosenIndexServe].idserve, serveGetFromForm());
            }
            catch (System.ArgumentNullException)
            {
                return;
            }
            servDGV_Reload();
        }

        private void buttonClearDataServe_Click(object sender, EventArgs e)
        {
            textBoxName.Text = "";
            textBoxPassport.Text = "";
            textBoxEducation.Text = "";
            textBoxExperience.Text = "";
            comboBoxServeCafe.Text = null;
            ErrorlabelServe.Text = "";
        }

        private void ButtonPost_Click(object sender, EventArgs e)
        {
            FormPost winArray;
            winArray = new FormPost();
            winArray.Show();
        }

        private void buttonServeInCafe_Click(object sender, EventArgs e)
        {

            CountServeInCafe winArray;
            try
            {
                winArray = new CountServeInCafe();
                winArray.Show();
            }
            catch
            {
                ErrorlabelServe.Text = "Ошибка:\r\nВы не наз";
                return;
            }
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            FileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "XML FILE|*.xml";
            saveFileDialog1.Title = "Сохранить как";
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string s = saveFileDialog1.FileName;
                XML.export(s);

            }

        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            FileDialog openFileDialog1 = new OpenFileDialog();

            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string s = openFileDialog1.FileName;
                XML.import(s);
            }
            //обновим таблицы
            cafeDGV_Reload();
            supDGV_Reload();
            menuDGV_Reload();
            servDGV_Reload();
        }

        private void ButtonUpdateTableMenu_Click(object sender, EventArgs e)
        {
            menuDGV_FirstReload();
        }
    }
}
