namespace BD4
{
    partial class FormIngredient
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
            this.IngDGV = new System.Windows.Forms.DataGridView();
            this.idingredient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ingredient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IngredientAddButton = new System.Windows.Forms.Button();
            this.IngredientDeleteButton = new System.Windows.Forms.Button();
            this.textBoxIngredient = new System.Windows.Forms.TextBox();
            this.labelIngredient = new System.Windows.Forms.Label();
            this.buttonClearDataIng = new System.Windows.Forms.Button();
            this.ErrorlabelIng = new System.Windows.Forms.Label();
            this.IngredientChangeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.IngDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // IngDGV
            // 
            this.IngDGV.AllowUserToAddRows = false;
            this.IngDGV.AllowUserToDeleteRows = false;
            this.IngDGV.AllowUserToResizeColumns = false;
            this.IngDGV.AllowUserToResizeRows = false;
            this.IngDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.IngDGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.IngDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.IngDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idingredient,
            this.ingredient});
            this.IngDGV.Dock = System.Windows.Forms.DockStyle.Top;
            this.IngDGV.Location = new System.Drawing.Point(0, 0);
            this.IngDGV.MultiSelect = false;
            this.IngDGV.Name = "IngDGV";
            this.IngDGV.RowHeadersVisible = false;
            this.IngDGV.Size = new System.Drawing.Size(318, 125);
            this.IngDGV.TabIndex = 0;
            this.IngDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.IngDGV_CellClick);
            // 
            // idingredient
            // 
            this.idingredient.HeaderText = "idingredient";
            this.idingredient.Name = "idingredient";
            this.idingredient.Visible = false;
            // 
            // ingredient
            // 
            this.ingredient.HeaderText = "Ингредиент";
            this.ingredient.Name = "ingredient";
            // 
            // IngredientAddButton
            // 
            this.IngredientAddButton.Location = new System.Drawing.Point(231, 181);
            this.IngredientAddButton.Name = "IngredientAddButton";
            this.IngredientAddButton.Size = new System.Drawing.Size(75, 26);
            this.IngredientAddButton.TabIndex = 1;
            this.IngredientAddButton.Text = "Добавить";
            this.IngredientAddButton.UseVisualStyleBackColor = true;
            this.IngredientAddButton.Click += new System.EventHandler(this.IngredientAddButton_Click);
            // 
            // IngredientDeleteButton
            // 
            this.IngredientDeleteButton.Location = new System.Drawing.Point(231, 213);
            this.IngredientDeleteButton.Name = "IngredientDeleteButton";
            this.IngredientDeleteButton.Size = new System.Drawing.Size(75, 22);
            this.IngredientDeleteButton.TabIndex = 3;
            this.IngredientDeleteButton.Text = "Удалить ";
            this.IngredientDeleteButton.UseVisualStyleBackColor = true;
            this.IngredientDeleteButton.Click += new System.EventHandler(this.IngredientDeleteButton_Click);
            // 
            // textBoxIngredient
            // 
            this.textBoxIngredient.Location = new System.Drawing.Point(94, 197);
            this.textBoxIngredient.Name = "textBoxIngredient";
            this.textBoxIngredient.Size = new System.Drawing.Size(121, 20);
            this.textBoxIngredient.TabIndex = 4;
            this.textBoxIngredient.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressed1);
            // 
            // labelIngredient
            // 
            this.labelIngredient.AutoSize = true;
            this.labelIngredient.Location = new System.Drawing.Point(13, 204);
            this.labelIngredient.Name = "labelIngredient";
            this.labelIngredient.Size = new System.Drawing.Size(67, 13);
            this.labelIngredient.TabIndex = 6;
            this.labelIngredient.Text = "Ингредиент";
            // 
            // buttonClearDataIng
            // 
            this.buttonClearDataIng.Location = new System.Drawing.Point(16, 168);
            this.buttonClearDataIng.Name = "buttonClearDataIng";
            this.buttonClearDataIng.Size = new System.Drawing.Size(180, 23);
            this.buttonClearDataIng.TabIndex = 7;
            this.buttonClearDataIng.Text = "Очистить поле ввода";
            this.buttonClearDataIng.UseVisualStyleBackColor = true;
            this.buttonClearDataIng.Click += new System.EventHandler(this.buttonClearDataIng_Click);
            // 
            // ErrorlabelIng
            // 
            this.ErrorlabelIng.AutoSize = true;
            this.ErrorlabelIng.Location = new System.Drawing.Point(13, 132);
            this.ErrorlabelIng.Name = "ErrorlabelIng";
            this.ErrorlabelIng.Size = new System.Drawing.Size(0, 13);
            this.ErrorlabelIng.TabIndex = 8;
            // 
            // IngredientChangeButton
            // 
            this.IngredientChangeButton.Location = new System.Drawing.Point(231, 150);
            this.IngredientChangeButton.Name = "IngredientChangeButton";
            this.IngredientChangeButton.Size = new System.Drawing.Size(75, 23);
            this.IngredientChangeButton.TabIndex = 11;
            this.IngredientChangeButton.Text = "Изменить";
            this.IngredientChangeButton.UseVisualStyleBackColor = true;
            this.IngredientChangeButton.Click += new System.EventHandler(this.IngredientChangeButton_Click);
            // 
            // FormIngredient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 247);
            this.Controls.Add(this.IngredientChangeButton);
            this.Controls.Add(this.ErrorlabelIng);
            this.Controls.Add(this.buttonClearDataIng);
            this.Controls.Add(this.labelIngredient);
            this.Controls.Add(this.textBoxIngredient);
            this.Controls.Add(this.IngredientDeleteButton);
            this.Controls.Add(this.IngredientAddButton);
            this.Controls.Add(this.IngDGV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormIngredient";
            this.Text = "Ингредиенты";
            this.Load += new System.EventHandler(this.FormIngredient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.IngDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView IngDGV;
        private System.Windows.Forms.Button IngredientAddButton;
        private System.Windows.Forms.Button IngredientDeleteButton;
        private System.Windows.Forms.TextBox textBoxIngredient;
        private System.Windows.Forms.Label labelIngredient;
        private System.Windows.Forms.Button buttonClearDataIng;
        private System.Windows.Forms.Label ErrorlabelIng;
        private System.Windows.Forms.Button IngredientChangeButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn idingredient;
        private System.Windows.Forms.DataGridViewTextBoxColumn ingredient;
    }
}