namespace BD4
{
    partial class FormChangeComposition
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comChangeDGV = new System.Windows.Forms.DataGridView();
            this.idcomposition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idingredient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iddish = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ingredient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numingredient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxNumDishChange = new System.Windows.Forms.TextBox();
            this.textBoxIngNumChange = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxIngChange = new System.Windows.Forms.ComboBox();
            this.ButtonChangeMenu = new System.Windows.Forms.Button();
            this.ButtonDeleteMenu = new System.Windows.Forms.Button();
            this.ErrorlabelCom = new System.Windows.Forms.Label();
            this.ButtonAddMenu = new System.Windows.Forms.Button();
            this.textBoxDishChange = new System.Windows.Forms.TextBox();
            this.No = new System.Windows.Forms.Button();
            this.ButtonOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.comChangeDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // comChangeDGV
            // 
            this.comChangeDGV.AllowUserToAddRows = false;
            this.comChangeDGV.AllowUserToDeleteRows = false;
            this.comChangeDGV.AllowUserToResizeColumns = false;
            this.comChangeDGV.AllowUserToResizeRows = false;
            this.comChangeDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.comChangeDGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.comChangeDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.comChangeDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idcomposition,
            this.idingredient,
            this.iddish,
            this.ingredient,
            this.numingredient});
            this.comChangeDGV.Dock = System.Windows.Forms.DockStyle.Top;
            this.comChangeDGV.Location = new System.Drawing.Point(0, 0);
            this.comChangeDGV.Name = "comChangeDGV";
            this.comChangeDGV.ReadOnly = true;
            this.comChangeDGV.RowHeadersVisible = false;
            this.comChangeDGV.Size = new System.Drawing.Size(525, 170);
            this.comChangeDGV.TabIndex = 0;
            this.comChangeDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.comChangeDGV_CellClick);
            // 
            // idcomposition
            // 
            this.idcomposition.HeaderText = "idcomposition";
            this.idcomposition.Name = "idcomposition";
            this.idcomposition.ReadOnly = true;
            this.idcomposition.Visible = false;
            // 
            // idingredient
            // 
            this.idingredient.HeaderText = "idingredient";
            this.idingredient.Name = "idingredient";
            this.idingredient.ReadOnly = true;
            this.idingredient.Visible = false;
            // 
            // iddish
            // 
            this.iddish.HeaderText = "iddish";
            this.iddish.Name = "iddish";
            this.iddish.ReadOnly = true;
            this.iddish.Visible = false;
            // 
            // ingredient
            // 
            this.ingredient.HeaderText = "Ингредиенты";
            this.ingredient.Name = "ingredient";
            this.ingredient.ReadOnly = true;
            // 
            // numingredient
            // 
            this.numingredient.HeaderText = "Количество ингредиентов";
            this.numingredient.Name = "numingredient";
            this.numingredient.ReadOnly = true;
            // 
            // textBoxNumDishChange
            // 
            this.textBoxNumDishChange.Location = new System.Drawing.Point(16, 276);
            this.textBoxNumDishChange.Name = "textBoxNumDishChange";
            this.textBoxNumDishChange.Size = new System.Drawing.Size(121, 20);
            this.textBoxNumDishChange.TabIndex = 2;
            this.textBoxNumDishChange.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressed3);
            // 
            // textBoxIngNumChange
            // 
            this.textBoxIngNumChange.Location = new System.Drawing.Point(163, 276);
            this.textBoxIngNumChange.Name = "textBoxIngNumChange";
            this.textBoxIngNumChange.Size = new System.Drawing.Size(121, 20);
            this.textBoxIngNumChange.TabIndex = 4;
            this.textBoxIngNumChange.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressed3);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Блюдо";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 257);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Цена блюда";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(160, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ингредиенты";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(160, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Количество ингредиентов";
            // 
            // comboBoxIngChange
            // 
            this.comboBoxIngChange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIngChange.FormattingEnabled = true;
            this.comboBoxIngChange.Location = new System.Drawing.Point(163, 233);
            this.comboBoxIngChange.Name = "comboBoxIngChange";
            this.comboBoxIngChange.Size = new System.Drawing.Size(121, 21);
            this.comboBoxIngChange.TabIndex = 9;
            // 
            // ButtonChangeMenu
            // 
            this.ButtonChangeMenu.Location = new System.Drawing.Point(438, 177);
            this.ButtonChangeMenu.Name = "ButtonChangeMenu";
            this.ButtonChangeMenu.Size = new System.Drawing.Size(75, 35);
            this.ButtonChangeMenu.TabIndex = 10;
            this.ButtonChangeMenu.Text = "Изменить ";
            this.ButtonChangeMenu.UseVisualStyleBackColor = true;
            this.ButtonChangeMenu.Click += new System.EventHandler(this.ButtonChangeMenu_Click);
            // 
            // ButtonDeleteMenu
            // 
            this.ButtonDeleteMenu.Location = new System.Drawing.Point(438, 218);
            this.ButtonDeleteMenu.Name = "ButtonDeleteMenu";
            this.ButtonDeleteMenu.Size = new System.Drawing.Size(75, 36);
            this.ButtonDeleteMenu.TabIndex = 11;
            this.ButtonDeleteMenu.Text = "Удалить ";
            this.ButtonDeleteMenu.UseVisualStyleBackColor = true;
            this.ButtonDeleteMenu.Click += new System.EventHandler(this.ButtonDeleteMenu_Click);
            // 
            // ErrorlabelCom
            // 
            this.ErrorlabelCom.AutoSize = true;
            this.ErrorlabelCom.Location = new System.Drawing.Point(13, 177);
            this.ErrorlabelCom.Name = "ErrorlabelCom";
            this.ErrorlabelCom.Size = new System.Drawing.Size(0, 13);
            this.ErrorlabelCom.TabIndex = 13;
            // 
            // ButtonAddMenu
            // 
            this.ButtonAddMenu.Location = new System.Drawing.Point(438, 260);
            this.ButtonAddMenu.Name = "ButtonAddMenu";
            this.ButtonAddMenu.Size = new System.Drawing.Size(75, 36);
            this.ButtonAddMenu.TabIndex = 16;
            this.ButtonAddMenu.Text = "Добавить ";
            this.ButtonAddMenu.UseVisualStyleBackColor = true;
            this.ButtonAddMenu.Click += new System.EventHandler(this.ButtonAddMenu_Click);
            // 
            // textBoxDishChange
            // 
            this.textBoxDishChange.Location = new System.Drawing.Point(16, 234);
            this.textBoxDishChange.Name = "textBoxDishChange";
            this.textBoxDishChange.Size = new System.Drawing.Size(121, 20);
            this.textBoxDishChange.TabIndex = 17;
            // 
            // No
            // 
            this.No.Location = new System.Drawing.Point(438, 319);
            this.No.Name = "No";
            this.No.Size = new System.Drawing.Size(75, 23);
            this.No.TabIndex = 19;
            this.No.Text = "Закрыть";
            this.No.UseVisualStyleBackColor = true;
            this.No.Click += new System.EventHandler(this.No_Click);
            // 
            // ButtonOk
            // 
            this.ButtonOk.Location = new System.Drawing.Point(329, 319);
            this.ButtonOk.Name = "ButtonOk";
            this.ButtonOk.Size = new System.Drawing.Size(75, 23);
            this.ButtonOk.TabIndex = 22;
            this.ButtonOk.Text = "Ok";
            this.ButtonOk.UseVisualStyleBackColor = true;
            this.ButtonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // FormChangeComposition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 350);
            this.Controls.Add(this.ButtonOk);
            this.Controls.Add(this.No);
            this.Controls.Add(this.textBoxDishChange);
            this.Controls.Add(this.ButtonAddMenu);
            this.Controls.Add(this.ErrorlabelCom);
            this.Controls.Add(this.ButtonDeleteMenu);
            this.Controls.Add(this.ButtonChangeMenu);
            this.Controls.Add(this.comboBoxIngChange);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxIngNumChange);
            this.Controls.Add(this.textBoxNumDishChange);
            this.Controls.Add(this.comChangeDGV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormChangeComposition";
            this.Load += new System.EventHandler(this.FormChangeComposition_Load);
            ((System.ComponentModel.ISupportInitialize)(this.comChangeDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView comChangeDGV;
        private System.Windows.Forms.TextBox textBoxNumDishChange;
        private System.Windows.Forms.TextBox textBoxIngNumChange;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxIngChange;
        private System.Windows.Forms.Button ButtonChangeMenu;
        private System.Windows.Forms.Button ButtonDeleteMenu;
        private System.Windows.Forms.Label ErrorlabelCom;
        private System.Windows.Forms.Button ButtonAddMenu;
        private System.Windows.Forms.TextBox textBoxDishChange;
        private System.Windows.Forms.Button No;
        private System.Windows.Forms.Button ButtonOk;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcomposition;
        private System.Windows.Forms.DataGridViewTextBoxColumn idingredient;
        private System.Windows.Forms.DataGridViewTextBoxColumn iddish;
        private System.Windows.Forms.DataGridViewTextBoxColumn ingredient;
        private System.Windows.Forms.DataGridViewTextBoxColumn numingredient;
    }
}